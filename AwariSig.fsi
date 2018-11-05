module Awari
///  Each player has a set of regular pits and one home pit. A pit holds zero or more beans
type pit = int
/// A board consists of pits.
type board = int array
/// A game is played between two players
type player = Player1 | Player2

val printBoard : b:board -> unit

val isHome : b:board -> p:player -> i:pit -> bool

val isGameOver : b:board -> bool

val getMove : b:board -> p:player -> q:string -> pit

val checkOpp : b:board -> i: pit -> int

(*DOCUMENTATION OF distribute*)
/// <summary>
/// Distributing beans counter clockwise, capturing when relevant
/// </summary>
/// <param name="b">The present statu of the board</param>
/// <param name="p">The player, whos beans to distribute</param>
/// <param name="i">The regular pit to distribute</param>
/// <returns>A new board after the beans of pit i has been distributed, and which player's pit the last bean landed in</returns>
val distribute : b:board -> p:player -> i:pit -> board * player * pit

(*DOCUMENTATION OF turn*)
/// <summary>
/// Interact with the user through getMove to perform a possibly repeated turn of a player
/// </summary>
/// <param name="b">The present state of the board</param>
/// <param name="p">The player, whose turn it is</param>
/// <returns>A new board after the player's turn</returns>
val turn : b:board -> p:player -> board

(*DOCUMENTATION OF turn*)
/// <summary>
/// Play game until one side is empty
/// </summary>
/// <param name="b">The initial board</param>
/// <param name="p">The player who starts</param>
/// <returns>A new board after one player has won</returns>
val play : b:board -> p:player -> board
