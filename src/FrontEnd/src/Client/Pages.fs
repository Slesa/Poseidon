module Client.Pages

open Elmish.Browser.UrlParser

[<RequireQualifiedAccess>]
type Page =
  | About
  | Login
  | WaiterList

let toHash =
  function
  | Page.About -> "#about"
  | Page.Login -> "#login"
  | Page.WaiterList -> "#waiterlist"

let pageParser : Parser<Page -> Page,_> =
  oneOf
    [ map Page.About (s "about")
      map Page.Login (s "login")
      map Page.WaiterList (s "waiterlist") ]

let urlParser location = parseHash pageParser location
