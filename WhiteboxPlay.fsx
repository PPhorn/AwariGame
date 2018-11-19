
open Awari

let boardtest10 = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest11 = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest0 = [|0; 0; 0; 0; 0; 0; 18; 0; 0; 0; 0; 0; 0; 18;|]
let boardtest1 = [|0; 0; 0; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest14 = [|0; 0; 0; 0; 0; 0; 18; 5; 0; 0; 0; 0; 8; 5;|]

let printBoardAlt (b: board) =
  // System.Console.Clear ()
  let mutable currentBoard : string = ""
  currentBoard <- currentBoard + (addColor makeP2PitNumbers pitNumberColor) + "\n"
  currentBoard <- currentBoard + (addColor "P2" player2Color) + (makeP2Field b)
  currentBoard <- currentBoard + (makeHomes b)
  currentBoard <- currentBoard + (addColor "P1" player1Color) + (makeP1Field b)
  currentBoard <- currentBoard + (addColor makeP1PitNumbers pitNumberColor) + "\n"
  printf "%s" currentBoard

let rec play (b : board) (p : player) : board =
  if isGameOver b then
    // System.Console.Clear ()
    printBoardAlt b
    if b.[6] > b.[13] then
      printfn "%s" (addColor "Game over. The winner is Player 1" gameOverColor)
    elif b.[6] = b.[13] then
      printfn "%s" (addColor "Game over. It's a tie" gameOverColor)
    else
      printfn "%s" (addColor "Game over. The winner is Player 2" gameOverColor)
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP

(*TESTING AF play*)
printfn "\nWhitebox testing of the function play:"
printfn "Branch 1a: if isGameOver = true output: printBoard + The winner is Player 1 - %b" (play boardtest1 Player1 = [|0; 0; 0; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|])
printfn "Branch 1b: if isGameOver = true output: printBoard + It's a tie - %b" (play boardtest0 Player1 = [|0; 0; 0; 0; 0; 0; 18; 0; 0; 0; 0; 0; 0; 18;|])
printfn "Branch 1c: if isGameOver = true output: printBoard + The winner is Player 2 - %b" (play boardtest14 Player2 = [|0; 0; 0; 0; 0; 0; 18; 5; 0; 0; 0; 0; 8; 5;|])
printfn "Branch 2a: if isGameOver = false output: [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|] - %b" (play boardtest10 Player2 = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|])
// printfn "Branch 2b: if isGameOver = false output: printBoard + The winner is Player 2 - %b" (play  = Player1)
