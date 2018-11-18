open Awari

let initPlayer1Side = List.init 6 (fun i -> {pit.cell = i+1; amount = 3})
let initPlayer2Side = List.init 6 (fun i -> {pit.cell = 6-i; amount = 3})

let myBoard = {board.Player1Side = initPlayer1Side; Player2Side = initPlayer2Side; score = ({pit.cell = 7; amount = 0},{pit.cell = 14; amount = 0})}
printBoard myBoard
(*
printfn "%b" (isHome myBoard Player2 (fst myBoard.score))
printfn "%b" (isHome myBoard Player2 (snd myBoard.score))

let gameOverPlayerSide = List.init 6 (fun i -> {pit.cell = i+1; amount = 0})
let gameOverBoard = {board.Player1Side = gameOverPlayerSide; Player2Side = initPlayer2Side; score = ({pit.cell = -1; amount = 0},{pit.cell = -2; amount = 0})}
printBoard gameOverBoard
printfn "%b" (isGameOver gameOverBoard)

printfn "%i" (getMove gameOverBoard Player1 "5").amount
*)
printfn "\n Player2 moves four times after this move 4, 3, 2, 1"

distribute myBoard Player2 (getMove myBoard Player2 "4")
printBoard myBoard
printfn "\n"

distribute myBoard Player2 (getMove myBoard Player2 "3")
printBoard myBoard
printfn "\n"

distribute myBoard Player2 (getMove myBoard Player2 "2")
printBoard myBoard
printfn "\n"

distribute myBoard Player2 (getMove myBoard Player2 "1")
printBoard myBoard
printfn "\n"

printfn "\n Player1 moves four times after this move 1, 3, 5, 6"

distribute myBoard Player1 (getMove myBoard Player1 "1")
printBoard myBoard
printfn "\n"

distribute myBoard Player1 (getMove myBoard Player1 "3")
printBoard myBoard
printfn "\n"

distribute myBoard Player1 (getMove myBoard Player1 "5")
printBoard myBoard
printfn "\n"

distribute myBoard Player1 (getMove myBoard Player1 "6")
printBoard myBoard
printfn "\n"

printfn "\n Player2 moves four times after this move 6, 5, 4, 3"

distribute myBoard Player2 (getMove myBoard Player2 "6")
printBoard myBoard
printfn "\n"

distribute myBoard Player2 (getMove myBoard Player2 "5")
printBoard myBoard
printfn "\n"

distribute myBoard Player2 (getMove myBoard Player2 "4")
printBoard myBoard
printfn "\n"

distribute myBoard Player2 (getMove myBoard Player2 "3")
printBoard myBoard
printfn "\n"