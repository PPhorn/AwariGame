

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



(*TESTING AF printBoard*)

  //Test cases to whitebox testing

printfn "Whitebox testing of the function printBoard:"
printfn "Branch 1: lst = [],            Exp. output: 0.0   - %b" (cfra2float [] = 0.0)
printfn "Branch 2: lst = [1],           Exp. output: 1.0   - %b" (cfra2float [1] = 1.0)
printfn "Branch 3: lst = [3; 4; 12; 4], Exp. output: 3.245 - %b\n" (cfra2float [3; 4; 12; 4] = 3.245)
