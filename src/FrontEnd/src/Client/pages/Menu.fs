module Client.Menu

open Elmish
open Fable.Helpers.React
open Client.Style
open Client.Pages

type UserData =
  { UserName : string
    Token : ServerCode.Domain.JWT }

type Model = {
   User : UserData option
 }

type Msg =
  | Logout
  

let init () = { User = Utils.load "user" }, Cmd.none


let update (msg:Msg) model : Model*Cmd<Msg> =
  match msg with
  | Logout ->
      model, Cmd.none


let view (model:Model) dispatch =
  div [ centerStyle "row" ] [
     yield viewLink Page.Home "Home"
     if model.User <> None then
      yield viewLink Page.WaiterList "Waiters"
     if model.User = None then
      yield viewLink Page.Login "login"
     else
      yield buttonLink "logout" (fun _ -> dispatch Logout) [ str "Logout" ]
  ]
  