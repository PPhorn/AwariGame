
let board2 = [|0; 0; 3; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|]
type player = Player1 | Player2
type board = int array
type pit = int


let rec distribute (b:board) (p:player) (i:pit) : board * player * pit =
let j = i + 1
for i = j to i + A.[i] do
  A.[j] = A.[j] + 1
  b


printfn "%A" (distribute board2 Player1 getMove)
