# Shiny2-and-a-Half
Shiny2 Fork with AltWFC capabilities

Shiny2+1/2 is a slight modification of the Shiny2 source by formlesstree4/ShinyJirachi, allowing redirection to alternate servers for uploading Pokemon data to a PC or sending Pokemon to a DS.

**Shiny 2+1/2 Changelog**

1.5
- Allow redirection to alternate servers by overwriting original openDNS at runtime.
- Included a warning at bottom of run screen for users to make sure they have a full party of 6, in case they send a Pokemon without party details.
- Added credits at top right of screen.
- Other minor adjustments, particularly to UI.

[Link to Shiny2, which made this all possible.](https://archive.codeplex.com/?p=shiny2)

A *huge* thanks to ShinyJirachi, who without the original Shiny2 this wouldn't have been possible.

**Original Shiny2 Project Description and Changelog**

```A GTS spoofing system for Pokemon Diamond, Pearl, Platinum, Heart Gold, Soul Silver, Black, White, Black 2, and White 2.

Visit the thread on ProjectPokemon forums for more information.
[http://projectpokemon.org/forums/showthread.php?22310-Shiny2-Distribution-System](http://projectpokemon.org/forums/showthread.php?22310-Shiny2-Distribution-System)

Changelog:

1.4
- Fixed DNS filter

1.3
- Added "syachi2ds.available.gs.nintendowifi.net" to the allowed DNS list
- Added more information to bad DNS requests
- Fixed an issue where GTS actions failed to register
- Changed the way Pokemon are saved so that the date/time they were saved is in the file name, no more accidental overwrites (for db33)
- Changed the application's Icon to a higher resolution
- Fixed an issue where certain 5th Gen connections failed to get a result
- Added more information to the log when a user initially enters the GTS
- Added more information to the log when a user receives a Pokemon, namely the user's game generation and Pokemon received
- Changed the "Sent x bytes of data" message to only appear in Verbose mode
- Fixed an issue where the app would crash on launch when loading data from a previous instance
- Fixed an issue where the app would crash on exit when saving some data
- Added the ability to minimize to system tray

1.2
- Fixed DNS bug that would filter out ALL URLs instead of specific ones. The filtering system is currently disabled and will be activated in the next release (hopefully).

1.1
- Fixed a bug where when doing ordered distribution, the program would throw an IndexOutOfRangeException after the last Pokemon was sent.

1.0
- Initial Release ```
