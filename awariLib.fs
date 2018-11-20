module Awari
type pit = {cell : int; mutable amount : int}
type board = {Player1Side : pit list; Player2Side : pit list; score : pit * pit}
type player = Player1 | Player2

// intentionally many missing implementations and additions

let printBoard (b : board) : unit = //BAD! should use string.Concat or something else.
  let mutable str = "   "
  List.iter (fun x -> str <- str + sprintf "%3i" x.amount) b.Player2Side
  str <- str + sprintf "\n%3i" (snd b.score).amount + "                  " + sprintf "%3i\n   " (fst b.score).amount
  List.iter (fun x -> str <- str + sprintf "%3i" x.amount) b.Player1Side
  printfn "%s" str

let isHome (b : board) (p : player) (i : pit) : bool = 
  match p with
  | Player1 -> 
    match i with 
    | i when i.cell = 7 -> true
    | _ -> false
  | Player2 -> 
    match i with 
    | i when i.cell = 14 -> true
    | _ -> false

let isGameOver (b : board) : bool =
  List.forall (fun x -> x.amount = 0) b.Player1Side || List.forall (fun x -> x.amount = 0) b.Player2Side
  
let rec getMove (b : board) (p : player) (q : string) : pit =
  let num = int q
  match p with
  | Player1 -> 
    match num with 
    | num when num > 0 && num < 7 -> 
      if b.Player1Side.[num-1].amount = 0 then 
        System.Console.WriteLine "Please choose a pit with beans in it"
        let input = System.Console.ReadLine()
        getMove b p input
      else b.Player1Side.[num-1]
    | _ ->
      printfn "Please give a valid input: 1-6"
      let input = System.Console.ReadLine()
      getMove b p input
  | Player2 ->
    match num with
    | num when num > 0 && num < 7 ->
      if b.Player2Side.[6-num].amount = 0 then
        System.Console.WriteLine "Please choose a pit with beans in it"
        let input = System.Console.ReadLine()
        getMove b p input
      else b.Player2Side.[6-num]
    | _ -> 
      System.Console.WriteLine "Please give a valid input: 1-6"
      let input = System.Console.ReadLine()
      getMove b p input

let distribute (b : board) (p : player) (i : pit) : board * player * pit =
  let mutable opponentSide = false
  let mutable cellNum = i.cell % 7
  let mutable lastPit = i
  match p with 
  | Player1 -> 
    while i.amount <> 0 do
      if cellNum = 0 then 
        if not opponentSide then (fst b.score).amount <- (fst b.score).amount + 1; i.amount <- i.amount - 1; lastPit <- (fst b.score)
        cellNum <- (cellNum + 1) % 7
        opponentSide <- not opponentSide
      elif opponentSide then
        b.Player2Side.[6-cellNum].amount <- b.Player2Side.[6-cellNum].amount + 1; lastPit <- b.Player2Side.[6-cellNum]
        cellNum <- (cellNum + 1) % 7
        i.amount <- i.amount - 1
      else
        b.Player1Side.[cellNum-1].amount <- b.Player1Side.[cellNum-1].amount + 1; lastPit <- b.Player1Side.[cellNum-1] 
        cellNum <- (cellNum + 1) % 7
        i.amount <- i.amount - 1
  | Player2 -> 
    while i.amount <> 0 do
      if cellNum = 0 then 
        if not opponentSide then (snd b.score).amount <- (snd b.score).amount + 1; i.amount <- i.amount - 1; lastPit <- (snd b.score)
        cellNum <- (cellNum + 1) % 7
        opponentSide <- not opponentSide
      elif opponentSide then
        b.Player1Side.[cellNum-1].amount <- b.Player1Side.[cellNum-1].amount + 1; lastPit <- b.Player1Side.[cellNum-1]
        cellNum <- (cellNum + 1) % 7
        i.amount <- i.amount - 1
      else
        b.Player2Side.[6-cellNum].amount <- b.Player2Side.[6-cellNum].amount + 1; lastPit <- b.Player2Side.[6-cellNum]
        cellNum <- (cellNum + 1) % 7
        i.amount <- i.amount - 1
  
  let lsc = lastPit.cell % 7
  //DEBUG:
  //printfn "cell = %d lastPit.amount = %d (not (isHome b p lastPit))) = %b" lastPit.cell lastPit.amount (not (isHome b p lastPit))
  
  if (lastPit.amount = 1 && (not (isHome b p lastPit))) then 
    match p with 
    | Player1 when not opponentSide -> 
      if (b.Player1Side.[lsc-1].amount + b.Player2Side.[lsc-1].amount) <> 1 then
        (fst b.score).amount <- (fst b.score).amount + (b.Player1Side.[lsc-1].amount + b.Player2Side.[lsc-1].amount)
        b.Player1Side.[lsc-1].amount <- 0
        b.Player2Side.[lsc-1].amount <- 0
    | Player1 when opponentSide -> 
      if (b.Player1Side.[6-lsc].amount + b.Player2Side.[6-lsc].amount) <> 1 then
        (snd b.score).amount <- (snd b.score).amount + (b.Player1Side.[6-lsc].amount + b.Player2Side.[6-lsc].amount)
        b.Player1Side.[6-lsc].amount <- 0
        b.Player2Side.[6-lsc].amount <- 0
    | Player2 when not opponentSide -> 
      if (b.Player1Side.[6-lsc].amount + b.Player2Side.[6-lsc].amount) <> 1 then
        (snd b.score).amount <- (snd b.score).amount + (b.Player1Side.[6-lsc].amount + b.Player2Side.[6-lsc].amount)
        b.Player1Side.[6-lsc].amount <- 0
        b.Player2Side.[6-lsc].amount <- 0
    | Player2 when opponentSide -> 
      if (b.Player1Side.[lsc-1].amount + b.Player2Side.[lsc-1].amount) <> 1 then
        (fst b.score).amount <- (fst b.score).amount + (b.Player1Side.[lsc-1].amount + b.Player2Side.[lsc-1].amount)
        b.Player1Side.[lsc-1].amount <- 0
        b.Player2Side.[lsc-1].amount <- 0
  
  //DEBUG:
  //printfn "lsc = %d, 7-lsc = %d" lsc (7-lsc)

  (b, p, lastPit)

let turn (b : board) (p : player) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str =
      if n = 0 then
        sprintf "%A's move" p
      else 
        sprintf "%A's move again" p
    printfn "%s" str
    let input = System.Console.ReadLine()
    let i = getMove b p input
    let (newB, finalPitsPlayer, finalPit)= distribute b p i
    if not (isHome b finalPitsPlayer finalPit) 
       || (isGameOver b) then
      newB
    else
      repeat newB p (n + 1)
  repeat b p 0 

let rec play (b : board) (p : player) : board =
  if isGameOver b then
    printBoard b
    if (fst b.score).amount > (snd b.score).amount then printfn "Player1 wins"
    else printfn "Player2 wins"
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP
