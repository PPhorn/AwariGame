
let board2 = [|0; 0; 4; 0; 0; 0; 10; 3; 3; 4; 0; 3; 3; 20;|]
type player = Player1 | Player2
type board = int array
type pit = int


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


(*DOCUMENTATION OF distribute*)
/// <summary>
/// Distributing beans counter clockwise, capturing when relevant
/// </summary>
/// <param name="b">The present status of the board</param>
/// <param name="p">The player, whos beans to distribute</param>
/// <param name="i">The regular pit to distribute</param>
/// <returns>A new board after the beans of pit i has been distributed, and which player's pit the last bean landed in</returns>
//val distribute : b:board -> p:player -> i:pit -> board * player * pit

let rec distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let j = i + 1
  let finalPit = i + b.[i]
  let Opps = (b.Length - 2) - finalPit
  for j = j to i + b.[i] do
    b.[j] <- (b.[j] + 1)
  if (checkOpp b finalPit) && b.[finalPit] = 1 then
    match p with
    | Player1 -> b.[6] <- b.[6] + b.[Opps] + b.[finalPit]
    | Player2 -> b.[13] <- b.[13] + b.[Opps] + b.[finalPit]
    b.[finalPit] <- 0
    b.[Opps] <- 0
  b.[i] <- 0
  (b, (finalPitPlayer finalPit), finalPit)


printfn "%A" (distribute board2 Player2 )