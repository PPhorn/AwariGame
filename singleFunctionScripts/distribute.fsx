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
