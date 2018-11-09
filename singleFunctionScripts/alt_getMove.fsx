type board = int array
type pit = int
type player = Player1 | Player2
let board = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 20;|]

(*
let rec getMove (b:board) (p:player) (q:string) : pit =
  printfn "%s choose a pit between 1-6" q
  let r =
      try
          let n = System.Console.ReadLine();
          int32(n)
      with
          | :? System.FormatException -> printfn "Invalid input!"
                                         0
  if (1 <= r && r <= 6) then
    match p with
    | Player1 when not (b.[r-1] = 0) -> r-1
    | Player2 when not (b.[r+6] = 0) -> r+6
    | _ -> printfn "This pit is empty. Try again."
    getMove b p q
  else
    printfn "Try again."
    getMove b p ""
*)

let rec getMove (b:board) (p:player) (q:string) : pit =
  printfn "%s Choose a pit between 1-6" q
  let r =
      try
          let n = System.Console.ReadLine();
          int32(n)
      with
          | :? System.FormatException -> printfn "Invalid input!"
                                         0
  if (1 <= r && r <= 6) then
    match p with
    | Player1 when not (b.[r-1] = 0) -> r-1
    | Player2 when not (b.[r+6] = 0) -> r+6
    | _ -> printfn "This pit is empty. Try again."
           getMove b p q
  else
    printfn "Try again."
    getMove b p ""

(*
printfn "choose a pit between 1-6"
let r =
    try
        let n = System.Console.ReadLine();
        int32(n)
    with
        | :? System.FormatException -> printfn "Invalid input!"
                                       0
*)
printfn "%A" (getMove board Player1 "Hey")
