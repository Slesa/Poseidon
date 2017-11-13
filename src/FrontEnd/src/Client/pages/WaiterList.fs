module Client.WaiterList

open Fable.Core
open Fable.Import
open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open ServerCode.Domain
open Style
open System
open Fable.Core.JsInterop
open Fable.PowerPack
open Fable.PowerPack.Fetch.Fetch_types
open ServerCode

type Model =
  { WaiterList : WaiterList
    Token : string
    ResetTime : DateTime option
    ErrorMsg : string option }
    
type Msg =
  | FetchedWaiterList of WaiterList
  | FetchedResetTime of DateTime
  | FetchError of exn


let getWaiterList token =
  promise {
    let url = ServerUrls.WaiterList
    let props = 
      [ Fetch.requestHeaders [
          HttpRequestHeaders.Authorization ("Bearer " + token) ]]
    return! Fable.PowerPack.Fetch.fetchAs<WaiterList> url props
  }    

  
let getResetTime token =
  promise {
    let url = ServerUrls.ResetTime
    let props = 
      [ Fetch.requestHeaders [
          HttpRequestHeaders.Authorization ("Bearer " + token) ]]
    let! details = Fable.PowerPack.Fetch.fetchAs<ServerCode.Domain.WaiterListResetDetails> url props
    return details.Time
  } 

let loadWaiterListCmd token =
  Cmd.ofPromise getWaiterList token FetchedWaiterList FetchError
  
let loadResetTimeCmd token =
  Cmd.ofPromise getResetTime token FetchedResetTime FetchError
  

let init (user:Menu.WaiterData) =
  { WaiterList = WaiterList.New user.Name
    Token = user.Token
    ResetTime = None
    ErrorMsg = None },
      Cmd.batch [
        loadWaiterListCmd user.Token
        loadResetTimeCmd user.Token ]

let update (msg:Msg) model : Model*Cmd<Msg> =
  match msg with
  | FetchedWaiterList waiterList ->
      let waiterList = { waiterList with Waiters = waiterList.Waiters |> List.sortBy (fun w -> w.Id) }
      { model with WaiterList = waiterList }, Cmd.none
   
  | FetchedResetTime datetime ->
      { model with ResetTime = Some datetime }, Cmd.none
      
  | FetchError e ->
      { model with ErrorMsg = Some e.Message }, Cmd.none


let view (model:Model) (dispatch: Msg -> unit) =
  div [] [
    h4 [] [
      let time = model.ResetTime |> Option.map (fun t -> " - last database reset time at "+ t.ToString("yyyy-MM-dd HH:mm") + "UTC") |> Option.defaultValue ""
      yield str (sprintf "Waiterlist for %s%s" model.WaiterList.UserName time) ]
    table [ClassName "table table-striped table-hover"] [
      thead [] [
        tr [] [
          th [] [str "Title"]
          th [] [str "Authors"]
        ]
      ]
      tbody [] [
        for waiter in model.WaiterList.Waiters do
          yield
            tr [] [
              td [] [ str (waiter.Id |> sprintf "%d") ]
              td [] [ str waiter.Name ]
            ]
      ]
    ]
  ]
         