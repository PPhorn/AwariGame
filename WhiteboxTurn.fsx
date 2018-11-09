open Awari

let boardtest10 = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest11 = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|]

let turn (b : board) (p : player) (move : pit) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    //printBoard b
    let str =
      if n = 0 then
        sprintf "%A's move. " p
      else
        "Again "
    let i = move - 1
    let (newB, finalPitsPlayer, finalPit)= distribute b p i
    if not (isHome b finalPitsPlayer finalPit)
       || (isGameOver b) then
      newB
    else
      repeat newB p (n + 1)
  repeat b p 0

(*TESTING AF turnr*)
printfn "Whitebox testing of the function turn:"
printfn "Branch 1: Player1, move 2 Exp. output: [|3; 0; 4; 4; 4; 3; 0; 3; 3; 3; 3; 3; 3; 0;|] - %b" (turn boardtest10 Player1 2 = [|3; 0; 4; 4; 4; 3; 0; 3; 3; 3; 3; 3; 3; 0;|])
printfn "Branch 1: Player2, move 6 Exp. output: [|4; 4; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 0; 1;|] - %b" (turn boardtest11 Player2 13 = [|4; 4; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 0; 1;|])