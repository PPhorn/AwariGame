
let board2 = [|0; 0; 3; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|]
type player = Player1 | Player2
type board = int array
type pit = int
let player = Player2

let rec getMove (b:board) (p:player) (q:string) : pit =
    printfn "Vælg et felt fra 1-6"
    let n = int (System.Console.ReadLine ())
    if (1 <= n && n <= 6) then
      match p with
      | Player1 -> n-1
      | Player2 -> n+6
    else
      getMove b p ""
printfn "%A" (getMove board2 Player2 "")
