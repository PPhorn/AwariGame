/// Checks pit opposit of finalPit
let checkOpp (b:board) (i: pit) : int =
  let Opps = (b.Length - 2) - i
  b.[Opps]


  type board = int array
  type pit = int
  let board = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|]

printfn "%A" (checkOpp board 5)
