open Awari

let initPlayer1Side = List.init 6 (fun i -> {pit.cell = i+1; amount = 3})
let initPlayer2Side = List.init 6 (fun i -> {pit.cell = 6-i; amount = 3})

let myBoard = {board.Player1Side = initPlayer1Side; Player2Side = initPlayer2Side; score = ({pit.cell = 7; amount = 0},{pit.cell = 14; amount = 0})}
printBoard myBoard

printfn "\n Player1 moves pit 4 and then 1"
distribute myBoard Player1 (getMove myBoard Player1 "4")
printBoard myBoard
printfn "\n"
distribute myBoard Player1 (getMove myBoard Player1 "1")
printBoard myBoard
printfn "\n"
printfn "\n Player2 moves pit 3 and then 6"
distribute myBoard Player2 (getMove myBoard Player2 "3")
printBoard myBoard
printfn "\n"
distribute myBoard Player2 (getMove myBoard Player2 "6")
printBoard myBoard
printfn "\n"