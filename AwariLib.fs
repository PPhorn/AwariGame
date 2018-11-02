/// Prints the board
let printBoard (b: board) =
    //System.Console.Clear ()
    for i = 12 downto 7 do
        printf "%4i" b.[i]
    printfn ""
    printf "%i %25i\n" b.[6] b.[13]
    for i = 0 to 5 do
        printf "%4i" b.[i]
    printfn ""

/// Checks whether pit is player's home
let isHome (b: board) (p: player) (i: pit) : bool =
    match i with
    | 6 when player = Player1 -> true
    | 13 when player = Player2 -> true
    | _ -> false

/// Checks whether the game is over. True when over.
let isGameOver (b: board) : bool =
  match b with
  | b when Array.forall (fun b -> (b = 0)) board2.[0..5] -> true
  | b when Array.forall (fun b -> (b = 0)) board2.[7..12] -> true
  | b -> false
printfn "%A" (test2 board2)

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


let turn (b : board) (p : player) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str =
      if n = 0 then
        sprintf "Player %A's move? " p
      else
        "Again? "
    let i = getMove b p str
    let (newB, finalPitsPlayer, finalPit)= distribute b p i
    if not (isHome b finalPitsPlayer finalPit)
       || (isGameOver b) then
      newB
    else
      repeat newB p (n + 1)
  repeat b p 0

let rec play (b : board) (p : player) : board =
  if isGameOver b then
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP
