open Awari

let initPlayer1Side = List.init 6 (fun i -> {pit.cell = i+1; amount = 3})
let initPlayer2Side = List.init 6 (fun i -> {pit.cell = 6-i; amount = 3})

let myBoard = {board.Player1Side = initPlayer1Side; Player2Side = initPlayer2Side; score = ({pit.cell = -1; amount = 0},{pit.cell = -2; amount = 0})}
printBoard myBoard

printfn "%b" (isHome myBoard Player2 (fst myBoard.score))
printfn "%b" (isHome myBoard Player2 (snd myBoard.score))

let gameOverPlayerSide = List.init 6 (fun i -> {pit.cell = i+1; amount = 0})
let gameOverBoard = {board.Player1Side = gameOverPlayerSide; Player2Side = initPlayer2Side; score = ({pit.cell = -1; amount = 0},{pit.cell = -2; amount = 0})}
printBoard gameOverBoard
printfn "%b" (isGameOver gameOverBoard)

printfn "%i" (getMove gameOverBoard Player1 "5").amount

let chosenPit = getMove myBoard Player1 "6"
distribute myBoard Player1 chosenPit
printBoard myBoard

let chosenPit2 = getMove myBoard Player2 "5"
distribute myBoard Player2 chosenPit2
printBoard myBoard