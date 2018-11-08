
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
let boardtest1 = [|0; 0; 0; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest2 = [|1; 0; 0; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest3 = [|0; 0; 3; 3; 3; 3; 10; 0; 0; 0; 0; 0; 0; 0;|]


(*TESTING AF printBoard  INCOMPLETE! *)
printfn "Whitebox testing of the function printBoard:"
printfn "Branch 1: Exp. output: Board is printed:"
printBoard boardtest2



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

(*TESTING AF getMove*)
printfn "Whitebox testing of the function getMove:"
printfn "Branch 1: if 1<n<6. Player1  Exp. output: 0         - %b" (getMove boardtest2 Player1 "1" = 0)
printfn "Branch 1: if 1<n<6. Player2  Exp. output: 7         - %b" (getMove boardtest2 Player2 "1" = 7)
printfn "Branch 1: if 1<n<6 is empty  Exp. output: Try again - %b" (getMove boardtest2 Player1 "2" = "This pit is empty. Try again.")
printfn "Branch 2: else n>6           Exp. output: Try again - %b\n" (getMove boardtest2 Player1 "9" = "This is not a valid input. Try again.")

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

(*TESTING AF turnr*)
printfn "Whitebox testing of the function turn:"
printfn "Branch 1: Player1 Exp. output: Player1 - %b" (turn boardtest1 Player1 = [|0; 0; 0; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|])


// let turn (b : board) (p : player) : board =
//   let rec repeat (b: board) (p: player) (n: int) : board =
//     printBoard b
//     let str =
//       if n = 0 then
//         sprintf "%A's move. " p
//       else
//         "Again "
//     let i = getMove b p str
//     let (newB, finalPitsPlayer, finalPit)= distribute b p i
//     if not (isHome b finalPitsPlayer finalPit)
//        || (isGameOver b) then
//       newB
//     else
//       repeat newB p (n + 1)
//   repeat b p 0
