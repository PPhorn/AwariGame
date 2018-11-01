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
    | [|_; _; _; _; _; _; _; 0; 0; 0; 0; 0; 0; _;|] -> true
    | [|0; 0; 0; 0; 0; 0; _; _; _; _; _; _; _; _;|] -> true
    | _ -> false

/// Gets chosen pit from pressed key
let rec getMove (b:board) (p:player) (q:string) : pit =
    printfn "Vælg et felt fra 1-6"
    match System.Console.ReadLine () with
    | "1" -> match player with
            | player1 -> 0
            | player2 -> 7
    | "2" -> match player with
            | player1 -> 1
            | player2 -> 8
    | "3" -> match player with
            | player1 -> 2
            | player2 -> 9
    | "4" -> match player with
            | player1 -> 3
            | player2 -> 10
    | "5" -> match player with
            | player1 -> 4
            | player2 -> 11
    | "6" -> match player with
            | player1 -> 5
            | player2 -> 12
    | _ -> printfn "Det var ikke et felt. Prøv igen."


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
