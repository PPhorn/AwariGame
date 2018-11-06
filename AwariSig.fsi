module Awari

type pit = int

type board = int array

type player = Player1 | Player2

val printBoard : b:board -> unit

val isHome : b:board -> p:player -> i:pit -> bool

val isGameOver : b:board -> bool

val getMove : b:board -> p:player -> q:string -> pit

val checkOpp : b:board -> i:pit -> bool

val finalPitPlayer : i:pit -> player

//val terminateGame : b:board -> string

val distribute : b:board -> p:player -> i:pit -> board * player * pit

val turn : b:board -> p:player -> board

val play : b:board -> p:player -> board
