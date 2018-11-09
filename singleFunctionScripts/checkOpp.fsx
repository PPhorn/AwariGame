let checkOpp (b:board) (i: pit) : bool =
  if i = 13 then false
  elif i = 6 then false
  else
    let Opps = (b.Length - 2) - i
    (b.[Opps] <> 0)
