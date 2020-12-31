# CommsHackEvents (The plugin is confirmed not to work. Fix pending.)
You can use VirtualBrightPlayz's CommsHack with Events! All the events that are compatible are found in here!
This plugin allows you to use premade functions, broadcasts, Cassie Announcements, audio files at specific events!


## P and S (used below, in compatible events.)
What does P and S mean?

P means player. This means that you can also use %playerName (S), %playerDisplayName (S), %playerRank (S), %playerRankColor (S), %playerRole (S), %playerSide (S)

Attempting to use %player will be changed to nothing, and be erased, instead, use one of the strings of text instead above.

You can also use %serverName, or %playerListTitle

S means string. This means that it is just text.

## Functions (DOES NOT WORK AT THE MOMENT)
You can use premade functions. These are the ones you can use:
```
MakeSCPAnnouncement - Announces what SCPs are in the game, and how many
ScanFacility - Scans the facility, detects how many Class-D, Scientists, NTF, CI and SCPs.
```

# Compatible events
**OnJoined** - %player P

**OnLeft** - %player P

**OnRestartingRound**

**OnEndingRound**

**OnRoundStarting**

**OnInsertingGeneratorTablet** - %player P

**OnEjectingGeneratorTablet** - %player P

**OnDying** - %player P | %attackerName S | %cause S | %damage S

**OnHurting** - %player P | %attackerName S | %cause S | %damage S

**OnEnteringFemurBreaker** - %player P

**OnActivatingWarheadPanel** - %player P 

**OnKicked** - %player P | %reason S

**OnBanned** - %player P | %moderator S | %reason S

**OnEscapingPocketDimension** - %player P

**OnFailingEscapePocketDimension** - %player P

**OnDetonating** - %player P

**OnRespawningTeam** - %team S | %numberOfPlayers S

**OnRespawningMTF** - %numberOfPlayers S

**OnRespawningCI** - %numberOfPlayers S

Planned features: 
OnRespawningSH (Serpent's Hand)
OnEscaping
OnTriggeringTeslaGates

More functions

# Example of use
```
Events_Broadcast:

    OnPlayerJoin: %playerName (<color=%playerRankColor>%playerRank</color) has joined %serverName!

Events_Cassie:

    OnRespawningCI: Chaos Insurgency has entered the facility
    OnDetonating: Facility has been detonated

Events_Sounds:
    OnRoundEnded: BRUUUUUUUUUUUUUUUUUUUUHHHHH.mp3
 
Events_Functions:
    OnRoundStarted: MakeSCPAnnouncement
```

# Warnings
For Events_Sounds to function, you will need VirtualBrightPlayz's CommsHack plugin, which can be found in releases/in it's original repo.
Functions do not work at the moment
