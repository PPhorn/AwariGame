
open Awari
(* Whitebox testing*)
printfn "\nWhitebox Testing of Awari functions:"
printfn "Unit: printBoard"
printfn "Unit: isHome"
printfn "Unit: isGameOver"
printfn "Unit: getMove"
printfn "Unit: checkOpp"
printfn "Unit: finalPitPlayer"
printfn "Unit: distribute"
printfn "Unit: turn"
printfn "Unit: play\n"


(*Test data*)
let boardtest0 = [|0; 0; 0; 0; 0; 0; 18; 0; 0; 0; 0; 0; 0; 18;|]
let boardtest1 = [|0; 0; 0; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest2 = [|1; 0; 0; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest3 = [|0; 0; 3; 3; 3; 3; 10; 0; 0; 0; 0; 0; 0; 0;|]
let boardtest4 = [|0; 0; 3; 3; 3; 3; 0; 0; 0; 0; 0; 0; 0; 0;|]
let boardtest5 = [|0; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest6 = [|1; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest7 = [|0; 0; 3; 3; 0; 0; 0; 1; 0; 0; 0; 0; 0; 0;|]
let boardtest8 = [|3; 3; 3; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest9 = [|0; 0; 3; 3; 3; 3; 0; 3; 0; 0; 0; 0; 0; 0;|]
let boardtest10 = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest11 = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|]

let esc = string (char 0x1B)


(*TESTING AF printBoard  INCOMPLETE! *)
printfn "Whitebox testing of the function printBoard:"
printfn "Branch 1: Exp. output: Board is printed:"
printBoard boardtest2

(*TESTING AF makeSpaces*)
printfn "\nWhitebox testing of the function makeSpaces:"
printfn "Branch 1: i = -1 Exp. output:\"\" - %b" (makeSpaces -1 = "")
printfn "Branch 1: i = 0 Exp. output:\"\" - %b" (makeSpaces 0 = "")
printfn "Branch 1: i = 4 Exp. output:\"    \" - %b" (makeSpaces 4 = "    ")
printfn "Branch 1: i = 20 Exp. output:\"                    \" - %b" (makeSpaces 20 = "                    ")

(*TESTING AF addColor*)
printfn "\nWhitebox testing of the function addColor:"
printfn "Branch 1: m = \"Player1\" c = 12 Exp. output:\"Player1\" writen in the color blue - %b" (addColor "Player1" 12 = (sprintf "%s[38;5;%dm%s%s[0m" esc 12 "Player1" esc))
printfn "Branch 1: m = \"Player2\" c = 10 Exp. output:\"Player2\" writen in the color green - %b" (addColor "Player2" 10 = (sprintf "%s[38;5;%dm%s%s[0m" esc 10 "Player2" esc))
printfn "Branch 1: m = \"1\"       c = 8 Exp. output:\"1\" writen in the color grey - %b" (addColor "1" 8 = (sprintf "%s[38;5;%dm%s%s[0m" esc 8 "1" esc))
printfn "Branch 1: m = \"Game over. The winner is Player 1\" c = 9 Exp. output:\"Game over. The winner is Player 1\" writen in the color green - %b" (addColor "Game over. The winner is Player 1" 9 = (sprintf "%s[38;5;%dm%s%s[0m" esc 9 "Game over. The winner is Player 1" esc))

(*TESTING AF makeP1PitNumbers*)
printfn "\nWhitebox testing of the function makeP1PitNumbers:"
printfn "Branch 1: Exp. output:\"Pits     1   2   3   4   5   6\" - %b" (makeP1PitNumbers = "Pits     1   2   3   4   5   6")

(*TESTING AF makeP2PitNumbers*)
printfn "\nWhitebox testing of the function makeP2PitNumbers:"
printfn "Branch 1: Exp. output:\"Pits     6   5   4   3   2   1\" - %b" (makeP2PitNumbers = "Pits     6   5   4   3   2   1")

(*TESTING AF isHome*)
printfn "\nWhitebox testing of the function isHome:"
printfn "Branch 1: pit = 6.  Player1. Exp. output: true  - %b" (isHome boardtest1 Player1 6 = true)
printfn "Branch 1: pit = 6.  Player2. Exp. output: false - %b" (isHome boardtest1 Player2 6 = false)
printfn "Branch 2: pit = 13. Player1. Exp. output: false - %b" (isHome boardtest1 Player1 13 = false)
printfn "Branch 2: pit = 13. Player2. Exp. output: true  - %b" (isHome boardtest1 Player2 13 = true)
printfn "Branch 3: pit = 7.  Player2. Exp. output: false - %b\n" (isHome boardtest1 Player2 7 = false)

(*TESTING AF isGameOver*)
printfn "Whitebox testing of the function isGameOver:"
printfn "Branch 1: b.[0..5] have 0 beans.  Exp. output: true  - %b" (isGameOver boardtest1 = true)
printfn "Branch 1: b.[0..5] have beans .   Exp. output: false - %b" (isGameOver boardtest2 = false)
printfn "Branch 2: b.[7..12] have 0 beans. Exp. output: true  - %b" (isGameOver boardtest3 = true)
printfn "Branch 2: b.[7..12] have beans.   Exp. output: false - %b\n" (isGameOver boardtest2 = false)

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

(*TESTING AF getMove*)
//printfn "Whitebox testing of the function getMove:"
//printfn "Branch 1: if 1<n<6. Player1  Exp. output: 0         - %b" (getMove boardtest2 Player1 "1" = 0)
//printfn "Branch 1: if 1<n<6. Player2  Exp. output: 7         - %b" (getMove boardtest2 Player2 "1" = 7)
//printfn "Branch 1: if 1<n<6 is empty  Exp. output: Try again - %b" (getMove boardtest2 Player1 "2" = "This pit is empty. Try again.")
//printfn "Branch 2: else n>6           Exp. output: Try again - %b\n" (getMove boardtest2 Player1 "9" = "This is not a valid input. Try again.")

(*TESTING AF checkOpp*)
printfn "Whitebox testing of the function checkOpp:"
printfn "Branch 1: if i = 13 Exp. output: false - %b" (checkOpp boardtest2 13 = false)
printfn "Branch 2: if i = 6  Exp. output: false - %b" (checkOpp boardtest2 6 = false)
printfn "Branch 3: if i = 2  Exp. output: true  - %b" (checkOpp boardtest2 1 = true)
printfn "Branch 3: if i = 1  Exp. output: false - %b\n" (checkOpp boardtest3 1 = false)

(*TESTING AF finalPitPlayer*)
printfn "Whitebox testing of the function finalPitPlayer:"
printfn "Branch 1: if i = 4 Exp. output: Player1 - %b" (finalPitPlayer 4 = Player1)
printfn "Branch 2: if i > 6 Exp. output: Player2 - %b\n" (finalPitPlayer 7 = Player2)

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
