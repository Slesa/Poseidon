module ServerCode.Database

open Suave.Logging
open Microsoft.Azure.WebJobs
open ServerCode.Storage.AzureTable
open ServerCode

[<RequireQualifiedAccess>]
type DatabaseType =
  | FileSystem
  | AzureStorage of connectionString : AzureConnection

type IDatabaseFunctions =
  abstract member LoadWaiterList : string -> Async<Domain.WaiterList>
  abstract member GetLastResetTime : unit -> Async<System.DateTime>

let getDatabase (logger:Logger) databaseType startupTime =
  logger.logSimple (Message.event LogLevel.Info (sprintf "Using database %O" databaseType))
  match databaseType with
  | DatabaseType.AzureStorage connection -> 
      Storage.WebJobs.startWebJobs connection
      { new IDatabaseFunctions with
          member __.LoadWaiterList key =Storage.AzureTable.getWaiterListFromDB connection key
          member __.GetLastResetTime () = async {
            let! resetTime = Storage.AzureTable.getLastResetTime connection
            return resetTime |> Option.defaultValue startupTime } }

  | DatabaseType.FileSystem ->
      { new IDatabaseFunctions with
          member __.LoadWaiterList key = async {
            return Storage.FileSystem.getWaiterListFromDB key}
          member __.GetLastResetTime () = async { return startupTime } }