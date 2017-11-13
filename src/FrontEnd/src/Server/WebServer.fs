module ServerCode.WebServer

open System.IO
open Suave
open Suave.Logging
open Suave.Filters
open Suave.Operators
open Suave.RequestErrors
open System.Net
open ServerCode

let start databaseType clientPath port =
    let startupTime = System.DateTime.UtcNow
    if not (Directory.Exists clientPath) then
        failwithf "Client-HomePath '%s' doesn't exist." clientPath

    let logger = Logging.Targets.create Logging.Info [| "Suave" |]
    let serverConfig =
        { defaultConfig with
            logger = Targets.create LogLevel.Debug [| "ServerCode"; "Server" |]
            homeFolder = Some clientPath
            bindings = [ HttpBinding.create HTTP (IPAddress.Parse "0.0.0.0") port] }

    let db = Database.getDatabase logger databaseType startupTime

    let app =
        choose [
            GET >=> choose [
                path "/" >=> Files.browseFileHome "index.html"
                pathRegex @"/(public|js|css|Images)/(.*)\.(css|png|gif|jpg|js|map)" >=> Files.browseHome
                path ServerUrls.WaiterList >=> WaiterList.getWaiterList db.LoadWaiterList
                path ServerUrls.ResetTime >=> WaiterList.getResetTime db.GetLastResetTime 
                ]

            POST >=> choose [
                path ServerUrls.Login >=> Auth.login
                //path ServerUrls.WaiterList >=> WaiterList.postWaiterList db.SaveWaiterList
                ]

            NOT_FOUND "Page not found."
            
        ] >=> logWithLevelStructured Logging.Info logger logFormatStructured

    startWebServer serverConfig app