module ServerCode.Storage.AzureTable

open Microsoft.WindowsAzure.Storage
open Microsoft.WindowsAzure.Storage.Table
open Microsoft.WindowsAzure.Storage.Blob
open ServerCode.Domain
open System

type AzureConnection =
  AzureConnection of string

let getWaitersTable (AzureConnection connectionString) = async {
  let client = (CloudStorageAccount.Parse connectionString).CreateCloudTableClient()
  let table = client.GetTableReference "waiter"

  let rec createTableSafe() = async {
    try
    do! table.CreateIfNotExistsAsync() |> Async.AwaitTask |> Async.Ignore
    with _ ->
      do! Async.Sleep 5000
      return! createTableSafe() }

  do! createTableSafe()
  return table }

let getWaiterListFromDB connectionString userName = async {
  let! results = async {
    let! table = getWaitersTable connectionString
    let query = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userName)
    return! table.ExecuteQuerySegmentedAsync(TableQuery(FilterString = query), null) |> Async.AwaitTask }
  return 
    { UserName = userName
      Waiters =
        [ for result in results ->
            { Id = result.Properties.["Id"].Int64Value.Value
              Name = result.Properties.["Name"].StringValue
              Group = result.Properties.["Group"].Int64Value.Value }]}
}
module private StateManagement =
  let getStateBlob (AzureConnection connectionString) name = async {
    let client = (CloudStorageAccount.Parse connectionString).CreateCloudBlobClient()
    let state = client.GetContainerReference "state"
    do! state.CreateIfNotExistsAsync() |> Async.AwaitTask |> Async.Ignore
    return state.GetBlockBlobReference name }

  let resetTimeBlob connectionString = getStateBlob connectionString "resetTime"
  let storeResetTime connectionString = async {
    let! blob = resetTimeBlob connectionString
    do! blob.UploadTextAsync "" |> Async.AwaitTask |> Async.Ignore }

let getLastResetTime connectionString =
  async {
    let! blob = StateManagement.resetTimeBlob connectionString
    do! blob.FetchAttributesAsync() |> Async.AwaitTask
    return blob.Properties.LastModified |> Option.ofNullable |> Option.map (fun d -> d.UtcDateTime) }

let clearWaiterLists connectionString = async {
   let! table = getWaitersTable connectionString
   do! table.DeleteIfExistsAsync() |> Async.AwaitTask |> Async.Ignore
   //do! Defaults.defaultWaiterList "test" |> saveWaiterListToDB connectionString
   do! StateManagement.storeResetTime connectionString }