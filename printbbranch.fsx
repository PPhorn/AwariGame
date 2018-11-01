
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

let board2 = [|0; 0; 0; 0; 0; 0; 10; 3; 3; 3; 3; 3; 3; 0;|]

let isGameOver (b: board) : bool =
    match b with
    | [|_; _; _; _; _; _; _; 0; 0; 0; 0; 0; 0; _;|] -> true
    | [|0; 0; 0; 0; 0; 0; _; _; _; _; _; _; _; _;|] -> true
    | _ -> false
printfn "%A" (isGameOver board2)

let test2 (b: int array) : bool =
    Array.forall (fun b -> (b = 0)) board2.[0..5]
printfn "%A" (test2 board2)

//let isGameOver (b: board) : bool =
  //if b.[0..5] = 0 then true
  //elif b.[7..12] = 0 then true
  //else false
//printfn "%A" (isGameOver board)

let rec getMove1 (b:board) (p:player) (q:string) : pit =
    printfn "Vælg et felt fra 1-6"
    match player with
    | player1 -> match System.Console.ReadLine () with
                | "1" ->  0
                | "2" ->  1
                | "3" ->  2
                | "4" ->  3
                | "5" ->  4
                | "6" ->  5
                | _ -> printfn "Det var ikke et felt. Prøv igen."
    | player2 -> match System.Console.ReadLine () with
                | "1" ->  7
                | "2" ->  8
                | "3" ->  9
                | "4" ->  10
                | "5" ->  11
                | "6" ->  12
                | _ -> printfn "Det var ikke et felt. Prøv igen."
printfn "%A" getMove ()


let rec getMove (b:board) (p:player) (q:string) : pit =
    printfn "Vælg et felt fra 1-6"
    match System.Console.ReadLine () with
    | "1" -> match player with
            | player1 -> 0
            | player2 -> 7
    | "2" -> match player with
            | player1 -> 1
            | player2 -> 8
    | "3" -> match player with
            | player1 -> 2
            | player2 -> 9
    | "4" -> match player with
            | player1 -> 3
            | player2 -> 10
    | "5" -> match player with
            | player1 -> 4
            | player2 -> 11
    | "6" -> match player with
            | player1 -> 5
            | player2 -> 12
    | _ -> printfn "Det var ikke et felt. Prøv igen."
