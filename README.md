# Nightmare
@hmthomas93 did alllllll of this

Running the Game
- The game does not run properly without EmoCore running
- After starting EmoCore and entering the session ID, then start the game
- The game can be run within Unity or as an .exe
- Building the game within Unity will result in the .exe and the data files (both are needed)

Socket Library
- The socket library is a DLL and included as a plugin within Unity
- The library shouldn't need any changing but if needed, build the library, locate the .dll, delete the current .dll in Unity, and reimport the new .dll
- The library needs to be built with .NET 3.5, not the default. Research how to build with this version of .NET
