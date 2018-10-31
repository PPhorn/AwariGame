
let board = [|3; 3; 3; 3; 3; 3; 0; 3; 3; 3; 3; 3; 3; 0;|]

let printBoard (b: int array) =
    //System.Console.Clear ()
    for i = 12 downto 7 do
        printf "%4i" b.[i]
    printfn ""
    printf "%i %25i\n" b.[6] b.[13]
    for i = 0 to 5 do
        printf "%4i" b.[i]
    printfn ""

printBoard board

type player = Player1 | Player2
type board = int array
type pit = int
let player = Player1


let isHome (b: board) (p: player) (i: pit) : bool =
    match p with
    | Player1 when i = 6 -> true
    | Player2 when i = 13 -> true
    | _ -> false

let isHomePit (b: board) (p: player) (i: pit) : bool =
    match i with
    | 6 when player = Player1 -> true
    | 13 when player = Player2 -> true
    | _ -> false
printfn "%A" (isHomePit board Player1 13)