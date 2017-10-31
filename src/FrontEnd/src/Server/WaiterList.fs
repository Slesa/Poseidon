module ServerCode.WaiterList

open Suave
open Suave.Logging
open Suave.RequestErrors
open Suave.ServerErrors
open ServerCode.Domain
open Suave.Logging.Message

let logger = Log.create "Poseidon"

let getWaiterList getWaiterListFromDB (ctx: HttpContext) =
  Auth.useToken ctx (fun token -> async {
    try
      let! waiterList = getWaiterListFromDB token.UserName
      return! Successful.OK (FableJson.toJson waiterList) ctx
    with exn ->
      logger.error (eventX "SERVICE_UNAVAILABLE" >> addExn exn )
      return! SERVICE_UNAVAILABLE "Database not available" ctx
  })

let getResetTime getLastResetTime ctx = async {
  let! lastResetTime = getLastResetTime()
  return! Successful.OK (FableJson.toJson { Time = lastResetTime }) ctx
}