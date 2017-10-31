namespace ServerCode.Storage

open System.Threading.Tasks
open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Host

type WaiterListWebJobs(connectionString) =
  member __.ClearWaiterListsWebJob([<TimerTrigger "00:10:00">] timer:TimerInfo) =
    AzureTable.clearWaiterLists connectionString |> Async.StartAsTask :> Task

type WaiterListWebJobsActivator(connectionString) =
  interface IJobActivator with
    member __.CreateInstance<'T>() =
      WaiterListWebJobs connectionString |> box :?> 'T

module WebJobs =
  open ServerCode.Storage
  open ServerCode.Storage.AzureTable
  let startWebJobs azureConnection =
    let host =
      let config =
        let (AzureConnection connectionString) = azureConnection
        JobHostConfiguration(
          DashboardConnectionString = connectionString,
          StorageConnectionString = connectionString)
      config.UseTimers()
      config.JobActivator <- WaiterListWebJobsActivator azureConnection
      new JobHost(config)
    host.Start()
