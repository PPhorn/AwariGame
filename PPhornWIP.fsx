
type board = int array
type pit = int
let board = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 20;|]
let overBoard = [|3; 3; 3; 3; 3; 3; 20; 0; 0; 0; 0; 0; 0; 10;|]

let isGameOver (b: board) : bool =
  match b with
  | b when Array.forall (fun b -> (b = 0)) b.[0..5] -> true
  | b when Array.forall (fun b -> (b = 0)) b.[7..12] -> true
  | b -> false

let printBoard (b: board) =
  let esc = string (char 0x1B)
  if isGameOver b then
    System.Console.Clear ()
    //printBoard b
    match b with
    | b when b.[6] > b.[13] -> System.Console.WriteLine(esc + "[31;1m" + "Game over. The winner is Player 1" + esc + "[0m")
    //printfn "Game over. The winner is Player 1"
    | b when b.[6] = b.[13] -> System.Console.WriteLine(esc + "[33;1m" + "Game over. It's a tie" + esc + "[0m")
    | _ -> System.Console.WriteLine(esc + "[31;1m" + "Game over. The winner is Player 2" + esc + "[0m")
  printf "     |"
  for i = 12 downto 7 do
      printf "%2i |" b.[i]
  printfn ""
  printf "| %2i |                       | %i |\n" b.[13] b.[6]
  printf "     |"
  for i = 0 to 5 do
      printf "%2i |" b.[i]
  printfn ""

printfn "%A" (printBoard overBoard)

(*
let redFont (s: string) : string =
  let esc = string (char 0x1B)
  System.Console.WriteLine(esc + "[31;1m" + "s" + esc + "[0m")

*)
(*DOCUMENTATION OF turn*)
/// <summary>
/// Interact with the user through getMove to perform a possibly repeated turn of a player
/// </summary>
/// <param name="b">The present state of the board</param>
/// <param name="p">The player, whose turn it is</param>
/// <returns>A new board after the player's turn</returns>

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
