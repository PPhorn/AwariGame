let rec getMove (b:board) (p:player) (q:string) : pit =
  printfn "%s Choose a pit between 1-6" q
  let n = int (System.Console.ReadLine ())
  if (1 <= n && n <= 6) then
    match p with
    | Player1 when not (b.[n-1] = 0) -> n-1
    | Player2 when not (b.[n+6] = 0) -> n+6
    | _ -> printfn "This pit is empty. Try again."
           getMove b p q
  else
    printfn "This is not a valid input. Try again."
    getMove b p ""
