module ServerCode.Storage.FileSystem

open System.IO
open ServerCode
open ServerCode.Domain

let getJSONFileName userName = sprintf "./temp/db/%s.json" userName

let getWaiterListFromDB userName =
  let fi = FileInfo(getJSONFileName userName)
  if not fi.Exists then Defaults.defaultWaiterList userName
  else
    File.ReadAllText(fi.FullName)
    |> FableJson.ofJson<WaiterList>
