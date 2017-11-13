module Client.Menu

open Elmish
open Fable.Helpers.React
open Client.Style
open Client.Pages
open System

type WaiterData =
  { Name: string
    Token: ServerCode.Domain.JWT }

type Model = {
   Waiter: WaiterData option
   Table: Int64
   Party: Int32
}

let readValue key defValue =
  match Utils.load key with
  | None -> defValue
  | Some value -> value

let createModel = {
    Waiter = Utils.load "user"
    Table = readValue "table" 0L
    Party = readValue "party" 0
}

type Msg =
  | Logout
  

let init () = createModel, Cmd.none


let update (msg:Msg) model : Model*Cmd<Msg> =
  match msg with
  | Logout ->
      model, Cmd.none


let view (model:Model) dispatch =
  div [ centerStyle "row" ] [

    match model.Waiter with
    | None -> yield viewLink Page.Login "login"
    | Some waiter -> yield buttonLink waiter.Name (fun _ -> dispatch Logout) [ str waiter.Name ]

    if model.Waiter = None then
      yield viewLink Page.About "About"
    else
      let tableText = if model.Table = 0L then "Table" else (sprintf "Table %i" model.Table)
      yield buttonLink tableText (fun _ -> dispatch Logout) [ str tableText ]

      let partyText = if model.Party = 0 then "Party" else (sprintf "Party %i" model.Party)
      yield buttonLink partyText (fun _ -> dispatch Logout) [ str partyText ]
//     if model.User <> None then
//      yield viewLink Page.WaiterList "Waiters"
  ]
  