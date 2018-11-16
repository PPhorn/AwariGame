module Awari

/// A game is played between two players
type player = Player1 | Player2

/// A board consisting of pits.
type board = int array

/// Each player has a set of regular pits and one home pit. A pit holds zero or
/// more beans
type pit = int

let player1Color = 12 // blue
let player2Color = 10 // green
let pitNumberColor = 8 // dark grey
let gameOverColor = 9 // red


(*DOCUMENTATION OF makeSpaces*)
/// <summary>
/// Takes an int as number of spaces to make
/// </summary>
/// <param name="i"> number of given spaced</param>
/// <returns>Returns a string with i number of spaces</returns>
let makeSpaces (i: int) : string =
  if i > 0 then
    String.replicate i " "
  else
    ""

(*DOCUMENTATION OF addColor*)
/// <summary>
/// Makes use of the ANSI esc code system to color strings printed in terminal
/// </summary>
/// <param name="m"> string to be colored</param>
/// <param name="i"> ANSI color code of wished color applied to string input
//  </param>
/// <returns>Returns the string input in the color corresponding to the given
///  color code</returns>
let addColor (m: string) (c: int) : string =
  let esc = string (char 0x1B)
  sprintf "%s[38;5;%dm%s%s[0m" esc c m esc

(*DOCUMENTATION OF makeP1Field*)
/// <summary>
/// Makes player1's field of pits
/// </summary>
/// <param name="b">The current board in which the fiels is applied</param>
/// <returns>Returns a string of numbers representing player1's field colored
/// with the player1Color</returns>
let makeP1Field (b: board) : string =
  let mutable p1Field : string = ""
  p1Field <- p1Field + (makeSpaces  5) + "|"
  for i = 0 to 5 do
      p1Field <- p1Field + (addColor (sprintf "%2i" b.[i]) player1Color) + " |"
  p1Field <- p1Field + "\n"
  p1Field

(*DOCUMENTATION OF makeP2Field*)
/// <summary>
/// Makes player2's field of pits
/// </summary>
/// <param name="b">The current board in which the fiels is applied</param>
/// <returns>Returns a string of numbers representing player2's field colored
/// with the player2Color</returns>
let makeP2Field (b: board) : string =
  let mutable p2Field : string = ""
  p2Field <- p2Field + (makeSpaces  5) + "|"
  for i = 12 downto 7 do
      p2Field <- p2Field + (addColor (sprintf "%2i" b.[i]) player2Color) + " |"
  p2Field <- p2Field + "\n"
  p2Field

(*DOCUMENTATION OF makeHomes*)
/// <summary>
/// Makes the home pits of both players
/// </summary>
/// <param name="b">The current board in which the home pits are applied</param>
/// <returns>Returns a string representing both home pits of the game colored
/// respectivly to each player</returns>
let makeHomes (b: board) : string =
  let mutable pits : string = ""
  pits <- pits + "   |" + (addColor (sprintf "%2i" b.[13]) player2Color) + " |"
  pits <- pits + (makeSpaces 23)
  pits <- pits + "|" + (addColor (sprintf "%2i" b.[6]) player1Color) + " |"
  pits + "\n"

(*DOCUMENTATION OF makeP1PitNumbers*)
/// <summary>
/// Makes numbers corresponding to pits of player1
/// </summary>
/// <returns>Returns a string of numbers representing the number of each pit on
/// player1's game field</returns>
let makeP1PitNumbers : string =
  let numbers = [for i in 1 .. 6 do yield sprintf "%4d" i]
  let pitNumbers = "Pits" + (makeSpaces 2) + String.concat "" numbers
  pitNumbers

(*DOCUMENTATION OF makeP2PitNumbers*)
/// <summary>
/// Makes numbers corresponding to pits of player2
/// </summary>
/// <returns>Returns a string of numbers representing the number of each pit on
/// player2's game field</returns>
let makeP2PitNumbers : string =
  let numbers = [for i in 6 .. -1 .. 1 do yield sprintf "%4d" i]
  let pitNumbers = "Pits" + (makeSpaces 2) + String.concat "" numbers
  pitNumbers

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
  System.Console.Clear ()
  let mutable currentBoard : string = ""
  currentBoard <- currentBoard + (addColor makeP2PitNumbers pitNumberColor) + "\n"
  currentBoard <- currentBoard + (addColor "P2" player2Color) + (makeP2Field b)
  currentBoard <- currentBoard + (makeHomes b)
  currentBoard <- currentBoard + (addColor "P1" player1Color) + (makeP1Field b)
  currentBoard <- currentBoard + (addColor makeP1PitNumbers pitNumberColor) + "\n"
  printf "%s" currentBoard


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


(*DOCUMENTATION OF getMove*)
/// <summary>
/// Takes the pressed key as input and finds the pit of next move from the user.
/// </summary>
/// <param name="b">The board the player is choosing from</param>
/// <param name="p">The player, whose turn it is to choose</param>
/// <param name="q">The string to ask the player</param>
/// <returns>The indexnumber of the pit the player has chosen</returns>

let rec getMove (b:board) (p:player) (q:string) : pit =
  printfn "%sChoose a pit between 1-6" q
  let r =
      try
          let n = System.Console.ReadLine();
          int (n)
      with
          | :? System.FormatException -> printfn "Invalid input!"
                                         let n = 0
                                         n
  match p with
  | Player1 when (b.[r-1] = 0) -> getMove b Player1 "This pit is empty. Try again. "
  | Player2 when (b.[r+6] = 0) -> getMove b Player2 "This pit is empty. Try again. "
  | Player1 when (1 <= r && r <= 6) -> r-1
  | Player2 when (1 <= r && r <= 6) -> r+6
  | Player1 when r = 0 -> getMove b Player1 "Try again. "
  | Player2 when r = 0 -> getMove b Player1 "Try again. "
  | Player1 when r > 6 -> getMove b Player1 "Try again. "
  | Player2 when r > 6 -> getMove b Player1 "Try again. "
  | _ -> getMove b p q

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

(*DOCUMENTATION OF finalPitPlayer*)
/// <summary>
/// Checks whether Player1 or Player2 is the player of the final pit.
/// </summary>
/// <param name="i">The indexnumber of the finalPit of the player who just
/// played his/her turn</param>
/// <returns>Player1 or Player2</returns>

let finalPitPlayer (i: pit) : player =
  match i with
  | i when i <= 6 -> Player1
  | i -> Player2


(*DOCUMENTATION OF distribute*)
/// <summary>
/// Distributing beans counter clockwise, capturing when relevant
/// </summary>
/// <param name="b">The present status of the board</param>
/// <param name="p">The player, whos beans to distribute</param>
/// <param name="i">The regular pit to distribute</param>
/// <returns>A new board after the beans of pit i has been distributed, and which player's pit the last bean landed in</returns>
//val distribute : b:board -> p:player -> i:pit -> board * player * pit

let rec distribute (b:board) (p:player) (i:pit) : board * player * pit =
  let mutable j = i + 1
  ///Let k be the number of pits to distribute
  let mutable k = b.[i]
  while k > 0 do
    if (j <= 13) then
      b.[j] <- (b.[j] + 1)
      k <- k - 1
    if (j > 13) then
      j <- 0
    elif k = 0 then
      j <- j
    else
      j <- j + 1
  let finalPit = j
  if (checkOpp b finalPit) && (finalPitPlayer finalPit) = p && b.[finalPit] = 1 then
    let Opps = (b.Length - 2) - finalPit
    match p with
    | Player1 -> b.[6] <- b.[6] + b.[Opps] + b.[finalPit]
    | Player2 -> b.[13] <- b.[13] + b.[Opps] + b.[finalPit]
    b.[finalPit] <- 0
    b.[Opps] <- 0
  b.[i] <- 0
  (b, (finalPitPlayer finalPit), finalPit)


let playerAsString (p: player) : string =
  match p with
  | Player1 -> (addColor "Player1" player1Color)
  | Player2 -> (addColor "Player2" player2Color)

(*DOCUMENTATION OF turn*)
/// <summary>
/// Interact with the user through getMove to perform a possibly repeated turn of a player
/// </summary>
/// <param name="b">The present state of the board</param>
/// <param name="p">The player, whose turn it is</param>
/// <returns>A new board after the player's turn</returns>


let turn (b : board) (p : player) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str =
      if n = 0 then
        sprintf "%s's move. " (playerAsString p)
      else
        sprintf "%s's again. " (playerAsString p)
    let i = getMove b p str
    let (newB, finalPitsPlayer, finalPit)= distribute b p i
    if not (isHome b finalPitsPlayer finalPit)
       || (isGameOver b) then
      newB
    else
      repeat newB p (n + 1)
  repeat b p 0


(*DOCUMENTATION OF play*)
/// <summary>
/// Play game until one side is empty
/// </summary>
/// <param name="b">The initial board</param>
/// <param name="p">The player who starts</param>
/// <returns>A new board after one player has won</returns>


let rec play (b : board) (p : player) : board =
  if isGameOver b then
    System.Console.Clear ()
    printBoard b
    if b.[6] > b.[13] then
      printfn "%s" (addColor "Game over. The winner is Player 1" gameOverColor)
    elif b.[6] = b.[13] then
      printfn "%s" (addColor "Game over. It's a tie" gameOverColor)
    else
      printfn "%s" (addColor "Game over. The winner is Player 2" gameOverColor)
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP
