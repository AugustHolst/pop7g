# pop7g

test: fsharpc -a awariLib.fs && fsharpc -r awariLib.dll test.fsx && mono test.exe
game: fsharpc -a awariLib.fs && fsharpc -r awariLib.dll game.fsx && mono game.exe`

## spillet
Player1 starter altid.
Man vælger et felt mellem 1-6.
Når Player1 vælger er det tal stigende fra venstre til højre.
Når Player2 vælger er det aftagende.
