namespace ServerCode.Domain

open System

// Json web token type
type JWT = string

// Login credentials
type Login =
  { UserName : string
    Password : string
    PasswordId : Guid }

type WaiterGroup =
  { Id : int64
    Name : string }

type WaiterGroupList =
  { UserName : string
    Groups : WaiterGroup list }

type Waiter =
  { Id : int64
    Name : string
    Group : int64 }

type WaiterList =
  { UserName : string
    Waiters : Waiter list}
    
  static member New userName =
    { UserName = userName
      Waiters = [] } 

type WaiterListResetDetails =
  { Time : DateTime }