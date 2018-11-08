open System
let board2 = [|0; 0; 0; 0; 0; 0; 11; 3; 3; 3; 3; 3; 3; 10;|]
type player = Player1 | Player2
type board = int array
type pit = int

let isGameOver (b: board) : bool =
  match b with
  | b when Array.forall (fun b -> (b = 0)) b.[0..5] -> true
  | b when Array.forall (fun b -> (b = 0)) b.[7..12] -> true
  | b -> false
isGameOver board2


Console.ForegroundColor<-ConsoleColor.Cyan

let printBoard (b: board) =
  if isGameOver b then
    match b with
    | b when b.[6] > b.[13] -> "Game over. The winner is Player 1"
    | b when b.[6] = b.[13] -> "It's a tie"
    | _ -> "Game over. The winner is Player 2"
  else
    System.Console.Clear ()
    for i = 12 downto 7 do
      "%4i" b.[i]
      ""
      "%i %25i\n" b.[13] b.[6]
    for i = 0 to 5 do
      "%4i" b.[i]
//printBoard board2
