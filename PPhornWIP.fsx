
type board = int array
type player = Player1 | Player2
type pit = int
let board = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 20;|]
let overBoard = [|3; 3; 3; 3; 3; 3; 20; 0; 0; 0; 0; 0; 0; 10;|]

let rec getMove (b:board) (p:player) (q:string) : pit =
  printfn "%sChoose a pit between 1-6" q
  let r =
      try
          let n = System.Console.ReadLine();
          int32(n)
      with
          | :? System.FormatException -> printfn "Invalid input! Try again."
                                         7
  match p with
  | Player1 when (1 <= r && r <= 6) -> r-1
  | Player2 when (1 <= r && r <= 6) -> r+6
  | Player1 when r = 0 -> getMove b Player1 "Invalid input! Try again. "
  | Player2 when r = 0 -> getMove b Player1 "Invalid input! Try again. "
  | Player1 when (b.[r-1] = 0) -> getMove b Player1 "This pit is empty. Try again. "
  | Player2 when (b.[r+6] = 0) -> getMove b Player2 "This pit is empty. Try again. "
  | _ -> getMove b p q


printfn "%A" (getMove board Player2 "Player1's Move.")
