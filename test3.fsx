open System
let board2 = [|0; 0; 0; 0; 0; 0; 11; 3; 3; 3; 3; 3; 3; 10;|]
type player = Player1 | Player2
type board = int array
type pit = int

let boardtest4 = [|0; 0; 3; 3; 3; 3; 0; 0; 0; 0; 0; 0; 0; 0;|]
let boardtest5 = [|0; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest6 = [|1; 0; 0; 0; 0; 0; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest7 = [|0; 0; 3; 3; 0; 0; 0; 1; 0; 0; 0; 0; 0; 0;|]
let boardtest8 = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|]
let boardtest9 = [|0; 0; 3; 3; 3; 3; 0; 3; 0; 0; 0; 0; 0; 0;|]

type testArray = int array


let rec getMove (b:board) (p:player) (q:string) : int =
  printfn "%s Choose a pit between 1-6" q
  let r = 0
  let l = "y"
      (*try
          let n = System.Console.ReadLine();
          int32(n)
      with
          | :? System.FormatException -> printfn "Invalid input! Try again."
                                         0*)
  if l = "y" then
    printf "Invalid input! Try again."
  if (1 <= r && r <= 6) then
    match p with
    | Player1 when not (b.[r-1] = 0) -> r-1
    | Player2 when not (b.[r+6] = 0) -> r+6
    | _ -> printfn "This pit is empty. Try again."
           getMove b p q
  else
    getMove b p ""

printfn "%A" (getMove boardtest8 Player1 "Player1's Move")
