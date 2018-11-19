#load "awariLib.fs"
open Awari

let initPlayer1Side = List.init 6 (fun i -> {pit.cell = i+1; amount = 3})
let initPlayer2Side = List.init 6 (fun i -> {pit.cell = 6-i; amount = 3})
let board = {board.Player1Side = initPlayer1Side; Player2Side = initPlayer2Side; score = ({pit.cell = 7; amount = 0},{pit.cell = 14; amount = 0})}

play board Player1