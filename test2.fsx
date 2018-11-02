
let board2 = [|0; 0; 3; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|]
type player = Player1 | Player2
type board = int array
type pit = int


//Checks pit opposit of finalPit
let checkOpp (b:board) (i: pit) : bool =
    let Opps = (b.Length - 2) - i
    (b.[Opps] <> 0)


let rec distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let j = i + 1
  let Opps = (b.Length - 2) - i
  for j = j to i + b.[i] do
    b.[j] <- (b.[j] + 1)
  if (checkOpp b i) then
    match p with
    | Player1 -> b.[6] <- b.[6] + b.[Opps] + b.[i+b.[i]]
    | Player2 -> b.[13] <- b.[13] + b.[Opps] + b.[i+b.[i]]
  b.[i+b.[i]] <- 0
  b.[Opps] <- 0
  b.[i] <- 0
  (b, p, i)


printfn "%A" (distribute board2 Player1 2)
