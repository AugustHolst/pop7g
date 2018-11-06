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
    | i when i.cell = -1 -> true
    | _ -> false
  | Player2 -> 
    match i with 
    | i when i.cell = -2 -> true
    | _ -> false

let isGameOver (b : board) : bool =
  List.forall (fun x -> x.amount = 0) b.Player1Side || List.forall (fun x -> x.amount = 0) b.Player2Side

let getMove (b : board) (p : player) (q : string) : pit =
  match p with
  | Player1 -> 
    match q with 
    | "1" -> b.Player1Side.[0]
    | "2" -> b.Player1Side.[1]
    | "3" -> b.Player1Side.[2]
    | "4" -> b.Player1Side.[3]
    | "5" -> b.Player1Side.[4]
    | "6" -> b.Player1Side.[5]
  | Player2 ->
    match q with
    | "1" -> b.Player2Side.[0]
    | "2" -> b.Player2Side.[1]
    | "3" -> b.Player2Side.[2]
    | "4" -> b.Player2Side.[3]
    | "5" -> b.Player2Side.[4]
    | "6" -> b.Player2Side.[5]

let turn (b : board) (p : player) : board =
  let rec repeat (b: board) (p: player) (n: int) : board =
    printBoard b
    let str =
      if n = 0 then
        sprintf "Player %A's move? " p
      else 
        "Again? "
    let i = getMove b p str
    let (newB, finalPitsPlayer, finalPit)= distribute b p i
    if not (isHome b finalPitsPlayer finalPit) 
       || (isGameOver b) then
      newB
    else
      repeat newB p (n + 1)
  repeat b p 0 

let rec play (b : board) (p : player) : board =
  if isGameOver b then
    b
  else
    let newB = turn b p
    let nextP =
      if p = Player1 then
        Player2
      else
        Player1
    play newB nextP
