open Awari

let initPlayerSide = List.init 6 (fun i -> {pit.cell = i+1; amount = 3})

let myBoard = {board.Player1Side = initPlayerSide; Player2Side = initPlayerSide; score = ({pit.cell = -1; amount = 0},{pit.cell = -2; amount = 0})}
printBoard myBoard

printfn "%b" (isHome myBoard Player2 (fst myBoard.score))
printfn "%b" (isHome myBoard Player2 (snd myBoard.score))

let gameOverPlayerSide = List.init 6 (fun i -> {pit.cell = i+1; amount = 0})
let gameOverBoard = {board.Player1Side = gameOverPlayerSide; Player2Side = initPlayerSide; score = ({pit.cell = -1; amount = 0},{pit.cell = -2; amount = 0})}
printBoard gameOverBoard
printfn "%b" (isGameOver gameOverBoard)

printfn "%i" (getMove gameOverBoard Player1 "5").amount