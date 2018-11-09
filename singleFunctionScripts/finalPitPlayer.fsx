let finalPitPlayer (i: pit) : player =
  match i with
  | i when i <= 6 -> Player1
  | i -> Player2
