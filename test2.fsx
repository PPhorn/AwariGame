
let board2 = [|0;  4;  4;  0;  0;  0; 10;  2;  3;  3;  4;  0;  2; 20;|]
let indexnumber = [|0;  1;  2;  3;  4;  5;  6;  7;  8;  9; 10; 11; 12; 13|]
type player = Player1 | Player2
type board = int array
type pit = int


let boardtest5 = [|0; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest6 = [|1; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest4 = [|0; 0; 3; 3; 3; 3; 0; 0; 0; 0; 0; 0; 0; 0;|]
let boardtest7 = [|0; 0; 3; 3; 0; 0; 0; 1; 0; 0; 0; 0; 0; 0;|]
let boardtest8 = [|3; 3; 3; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest9 = [|0; 0; 3; 3; 3; 3; 0; 3; 0; 0; 0; 0; 0; 0;|]

//Checks pit opposit of finalPit
let checkOpp (b:board) (i: pit) : bool =
    if i = 13 then false
    elif i = 6 then false
    else
      let Opps = (b.Length - 2) - i
      (b.[Opps] <> 0)

let finalPitPlayer (i: pit) : player =
  match i with
  | i when i <= 6 -> Player1
  | i -> Player2


let rec distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let mutable j = i + 1
  ///Let k be the number of pits to distribute
  let mutable k = b.[i]
  while k > 0 do
    if (j <= 13) then
      b.[j] <- (b.[j] + 1)
      k <- k - 1
    if (j > 13) then
      j <- 0
    elif k = 0 then
      j <- j
    else
      j <- j + 1
  let finalPit = j
  if (checkOpp b finalPit) && (finalPitPlayer finalPit) = p && b.[finalPit] = 1 then
    let Opps = (b.Length - 2) - finalPit
    match p with
    | Player1 -> b.[6] <- b.[6] + b.[Opps] + b.[finalPit]
    | Player2 -> b.[13] <- b.[13] + b.[Opps] + b.[finalPit]
    b.[finalPit] <- 0
    b.[Opps] <- 0
  b.[i] <- 0
  (b, (finalPitPlayer finalPit), finalPit)

(*TESTING AF distribute*)
printfn "\nWhitebox testing of the function distribute:\n"
printfn "Test of Player1's move reaching into Player2's field:"
printfn "Branch 1.0:  b = [|0; 0; 3; 3; 3; 3; 0; 0; 0; 0; 0; 0; 0; 0|] p = Player1 i = 5."
printfn "Exp. output: b = [|3; 3; 3; 3; 3; 0; 1; 4; 4; 3; 3; 3; 3; 0|], finalPlayer = Player2, finalPit = 8 - %b\n" (distribute boardtest4 Player1 5 = ([|0; 0; 3; 3; 3; 0; 1; 1; 1; 0; 0; 0; 0; 0|], Player2, 8))
printfn "Test of Player2's move reaching into Player1's field:"
printfn "Branch 2.1:  b = [|0; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0|] p = Player2 i = 12."
printfn "Exp. output: b = [|1; 1; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 0; 1|], finalPlayer = Player1, finalPit = 1 - %b\n" (distribute boardtest5 Player2 12 = ([|1; 1; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 0; 1|], Player1, 1))
printfn "Test of beans in chosen pit = 0:"
printfn "Branch 2.2:  b = [|1; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0|] p = Player1 i = 2."
printfn "Exp. output: b = [|1; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0|], finalPlayer = Player1, finalPit = 3 - %b\n" (distribute boardtest6 Player1 2 = ([|1; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0|], Player1, 3))
printfn "Test of k = 1 e.g one runthrough of While-loop:"
printfn "Branch 2.3:  b = [|0; 0; 3; 3; 0; 0; 0; 1; 0; 0; 0; 0; 0; 0|] p = Player2 i = 7."
printfn "Exp. output: b = [|0; 0; 3; 3; 0; 0; 0; 0; 1; 0; 0; 0; 0; 0|], finalPlayer = Player2, finalPit = 8 - %b\n" (distribute boardtest7 Player2 7 = ([|0; 0; 3; 3; 0; 0; 0; 0; 1; 0; 0; 0; 0; 0|], Player2, 8))
printfn "Test of Player1 capturing Player2's opposite beans:"
printfn "Branch 3.0:  b = [|3; 3; 3; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0|] p = Player1 i = 0."
printfn "Exp. output: b = [|0; 4; 4; 0; 0; 0; 4; 3; 3; 0; 3; 3; 3; 0|], finalPlayer = Player1, finalPit = 3 - %b\n" (distribute boardtest8 Player1 0 = ([|0; 4; 4; 0; 0; 0; 4; 3; 3; 0; 3; 3; 3; 0|], Player1, 3))
printfn "Test of Player2 capturing Player1's opposite beans:"
printfn "Branch 3.0:  b = [|0; 0; 3; 3; 3; 3; 0; 3; 0; 0; 0; 0; 0; 0|] p = Player2 i = 7."
printfn "Exp. output: b = [|0; 0; 0; 3; 3; 3; 0; 0; 1; 1; 0; 0; 0; 4|], finalPlayer = Player2, finalPit = 10 - %b" (distribute boardtest9 Player2 7 = ([|0; 0; 0; 3; 3; 3; 0; 0; 1; 1; 0; 0; 0; 4|], Player2, 10))
