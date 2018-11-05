module Awari
type player = Player1 | Player2
type board = int array
type pit = int

(*DOCUMENTATION OF printBoard*)
/// <summary>
/// Prints the board
/// </summary>
/// <param name="b"> A board to be printed </param>
/// <returns>() - it just prints</returns>
/// , e.g.,
/// <remarks>
/// Output is for example,
/// <code>
///      3  3  3  3  3  3
///   0                    0
///      3  3  3  3  3  3
/// </code>
/// Where player 1 is bottom row and rightmost home
/// </remarks>

let printBoard (b: board) =
    //System.Console.Clear ()
    for i = 12 downto 7 do
        printf "%4i" b.[i]
    printfn ""
    printf "%i %25i\n" b.[6] b.[13]
    for i = 0 to 5 do
        printf "%4i" b.[i]
    printfn ""


(*DOCUMENTATION OF isHome*)
/// <summary>
/// Checks whether a pit is the player's home
/// </summary>
/// <param name="b">A board to check</param>
/// <param name="p">The player, whos home to check</param>
/// <param name="i">A regular or home pit of a player</param>
/// <returns>True if either side has no beans</returns>

let isHome (b: board) (p: player) (i: pit) : bool =
    match i with
    | 6 when p = Player1 -> true
    | 13 when p = Player2 -> true
    | _ -> false

(*DOCUMENTATION OF isGameOver*)
/// <summary>
/// Checks whether the game is over
/// </summary>
/// <param name="b"> A board to check</param>
/// <returns>True if either side has no beans</returns>
let isGameOver (b: board) : bool =
  match b with
  | b when Array.forall (fun b -> (b = 0)) b.[0..5] -> true
  | b when Array.forall (fun b -> (b = 0)) b.[7..12] -> true
  | b -> false

(*DOCUMENTATION OF getMove*)
/// <summary>
/// Takes the pressed key as input and finds the pit of next move from the user.
/// </summary>
/// <param name="b">The board the player is choosing from</param>
/// <param name="p">The player, whose turn it is to choose</param>
/// <param name="q">The string to ask the player</param>
/// <returns>The indexnumber of the pit the player has chosen</returns>

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

(*DOCUMENTATION OF checkOpp*)
/// <summary>
/// Checks pit opposit of finalPit
/// </summary>
/// <param name="b"> A board to check</param>
/// <param name="i">The indexnumber of the finalPit of the player who just
/// played his/her turn</param>
/// <returns>The number of beans in the pit opposite of the finalPit</returns>

let checkOpp (b:board) (i: pit) : bool =
    if i = 13 then false
    elif i = 6 then false
    else
      let Opps = (b.Length - 2) - i
      (b.[Opps] <> 0)

let finalPitPlayer (i: pit) : player =
  match i with
  | i when i <= 6 -> Player1
  | i -> Player2

(*
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
*)

(*
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
*)
