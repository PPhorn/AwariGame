let rec play (b : board) (p : player) : board =
  if isGameOver b then
    let esc = string (char 0x1B)
    if b.[6] > b.[13] then
      System.Console.WriteLine(esc + "[31;1m" + "Game over. The winner is Player 1" + esc + "[0m")
    elif b.[6] = b.[13] then
      System.Console.WriteLine(esc + "[33;1m" + "Game over. It's a tie" + esc + "[0m")
    else
      System.Console.WriteLine(esc + "[31;1m" + "Game over. The winner is Player 2" + esc + "[0m")
    //printfn "Game over."
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP
