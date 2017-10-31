module ServerCode.Auth

open Suave
open Suave.RequestErrors

let login (ctx: HttpContext) = async {
  let login =
    ctx.request.rawForm
    |> System.Text.Encoding.UTF8.GetString
    |> FableJson.ofJson<Domain.Login>

  try
    if (login.UserName <> "test" || login.Password <> "test") then
      return! failwithf "Could not authenticate %s" login.UserName
    let user : ServerTypes.UserRights = { UserName = login.UserName }
    let token = JsonWebToken.encode user

    return! Successful.OK  token ctx

  with
  | _ -> return! UNAUTHORIZED (sprintf "User '%s' can't be logged in." login.UserName) ctx
}

let useToken ctx f = async {
  match ctx.request.header "Authorization" with 
  | Choice1Of2 accesstoken when accesstoken.StartsWith "Bearer " ->
      let jwt = accesstoken.Replace("Bearer ", "")
      match JsonWebToken.isValid jwt with
      | None -> return! FORBIDDEN "Accessing this API is not allowed." ctx
      | Some token -> return! f token
  | _ -> return! BAD_REQUEST "Request doesn't contain a JSON Web Token" ctx
}
