let printBoard (b: board) =
  System.Console.Clear ()
  let esc = string (char 0x1B)
  printf "     |"
  for i = 12 downto 7 do
      printf "%2i |" b.[i]
  printfn ""
  printf "| %2i |                       | %i |\n" b.[13] b.[6]
  printf "     |"
  for i = 0 to 5 do
      printf "%2i |" b.[i]
  printfn ""
