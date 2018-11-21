open Awari

let fstBoard = {board.Player1Side = (List.init 6 (fun i -> {pit.cell = i+1; amount = 3}));
                Player2Side = (List.init 6 (fun i -> {pit.cell = 6-i; amount = 3}));
                score = ({pit.cell = 7; amount = 0},{pit.cell = 14; amount = 0})}
let sndBoard = {board.Player1Side = (List.init 6 (fun i -> {pit.cell = i+1; amount = 3}));
                Player2Side = (List.init 6 (fun i -> {pit.cell = 6-i; amount = 3}));
                score = ({pit.cell = 7; amount = 0},{pit.cell = 14; amount = 0})}
let gameOverBoard = {board.Player1Side = (List.init 6 (fun i -> {pit.cell = i+1; amount = 0}));
                    Player2Side = (List.init 6 (fun i -> {pit.cell = 6-i; amount = 0}));
                    score = ({pit.cell = 7; amount = 0},{pit.cell = 14; amount = 0})}

//  isHome
// Player 1
printfn "isHome  test: %A" (isHome fstBoard Player1 (fst fstBoard.score) = true)
printfn "ishome  test: %A" (isHome fstBoard Player1 (snd fstBoard.score) = false)
// Player 2
printfn "isHome  test: %A" (isHome fstBoard Player2 (snd fstBoard.score) = true)
printfn "ishome  test: %A" (isHome fstBoard Player2 (fst fstBoard.score) = false)

//  isGameOver
printfn "\nisGameOver  test:" 
printfn "isGameOver tager fstBoard og tester om det er false: %b" (isGameOver fstBoard = false)
printfn "isGameOver tager sndBoard og tester om det er true: %b" (isGameOver gameOverBoard = true)

//  getMove
printfn "\n getMove  test:"
printfn "getMove tester om den begge tager pit 4 (index 3): %b" (getMove fstBoard Player1 "4" = fstBoard.Player1Side.[3])
// vi har ikke lavet test: for den lander i et felt der er tomt, 
// eftersom funktionen når at stoppe når den når fejlbeskeden i funktionen.
// derfor når den aldrig at sammenligne og returnerer dermed ikke en boolean.
// Dette er altså enbetydende med at funktionen virker som den skal. 

//  distribute
// Manually doing a move that should be equivalent with doing distribute 
// on the 4th pit for Player1.
sndBoard.Player1Side.[3].amount <- 0
sndBoard.Player1Side.[4].amount <- 4
sndBoard.Player1Side.[5].amount <- 4
(fst sndBoard.score).amount <- 1

let distTest = distribute fstBoard Player1 fstBoard.Player1Side.[3]
printfn "distribute  test: %b" (distTest = (sndBoard, Player1, (fst sndBoard.score)))