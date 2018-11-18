# pop7g

#test
fsharpc -a awariLib.fs && fsharpc -r awariLib.dll test.fsx && mono test.exe

#game
fsharpc -a awariLib.fs && fsharpc -r awariLib.dll game.fsx && mono game.exe