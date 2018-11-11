module Awari

type pit = int

type board = int array

type player = Player1 | Player2

val player1Color : int

val player2Color : int

val pitNumberColor : int

val gameOverColor : int

val makeSpaces : i:int -> string

val addColor : m:string -> c:int -> string

val printBoard : b:board -> unit

val isHome : b:board -> p:player -> i:pit -> bool

val isGameOver : b:board -> bool

val getMove : b:board -> p:player -> q:string -> pit

val checkOpp : b:board -> i:pit -> bool

val finalPitPlayer : i:pit -> player

val distribute : b:board -> p:player -> i:pit -> board * player * pit

val turn : b:board -> p:player -> board

val play : b:board -> p:player -> board
