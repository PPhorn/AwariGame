let isGameOver (b: board) : bool =
  match b with
  | b when Array.forall (fun b -> (b = 0)) b.[0..5] -> true
  | b when Array.forall (fun b -> (b = 0)) b.[7..12] -> true
  | b -> false
