let isHome (b: board) (p: player) (i: pit) : bool =
  match i with
  | 6 when p = Player1 -> true
  | 13 when p = Player2 -> true
  | _ -> false
