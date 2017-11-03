module Client.Pages

open Elmish.Browser.UrlParser

[<RequireQualifiedAccess>]
type Page =
  | Home
  | Login
  | WaiterList

let toHash =
  function
  | Page.Home -> "#home"
  | Page.Login -> "#login"
  | Page.WaiterList -> "#waiterlist"

let pageParser : Parser<Page -> Page,_> =
  oneOf
    [ map Page.Home (s "home")
      map Page.Login (s "login")
      map Page.WaiterList (s "waiterlist") ]

let urlParser location = parseHash pageParser location
