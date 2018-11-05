

open Awari
let board = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|]
type player = Player1 | Player2
type board = int array
type pit = int


/// play the game
play board Player1
