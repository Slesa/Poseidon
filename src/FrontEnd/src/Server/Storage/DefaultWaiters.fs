module ServerCode.Storage.Defaults

open ServerCode.Domain

let defaultWaiterList userName =
  { UserName = userName
    Waiters =
      [ { Id = 1L
          Name = "Captain Jean Luc Picard"
          Group = 1L }
        { Id = 2L
          Name = "Lt Commander Riker"
          Group = 1L }
      ]}

let defaultWaiterGroupList userName =
  { UserName = userName
    Groups =
      [ { Id = 1L
          Name = "Enterprise 1701D" }
        { Id = 2L
          Name = "Enterprise 1701" }
      ]}