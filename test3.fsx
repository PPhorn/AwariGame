

let board2 = [|0; 0; 3; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|]
type player = Player1 | Player2
type board = int array
type pit = int


/// Gets chosen pit from pressed key
let rec getMove (b:board) (p:player) (q:string) : pit =
    printfn "Vælg et felt fra 1-6"
    let n = int (System.Console.ReadLine ())
    if (1 <= n && n <= 6) then
      match p with
      | Player1 when not (b.[n-1] = 0) -> n-1
      | Player2 when not (b.[n+6] = 0) -> n+6
      | _ -> printfn "Dette felt er tomt" 
             getMove b p ""
    else
      printfn "Dette felt er ikke gyldigt"
      getMove b p ""
printfn "%A" (getMove board2 Player1 "")

     // if b.[i] = 0 then
     //   printfn "Dette felt er tomt"
     //   getMove b p ""
     //  else
