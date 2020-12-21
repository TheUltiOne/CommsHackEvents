# CommsHackEvents
You can use VirtualBrightPlayz's CommsHack with Events! All the events that are compatible are found in here!
This plugin allows you to use premade functions, broadcasts, Cassie Announcements, audio files at specific events!


## P and S (used below, in compatible events.)
What does P and S mean?

P means player. This means that you can also use %playerName (S), %playerDisplayName (S), %playerRank (S), %playerRankColor (S), %playerRole (S), %playerSide (S)

Attempting to use %player will be changed to nothing, and be erased, instead, use one of the strings of text instead above.

You can also use %serverName, or %playerListTitle

S means string. This means that it is just text.

## Functions
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

**OnDying** - %player P | %killerName S | %deathCause S

**OnHurting** - %player P | %killerName S | %hurtCause S

**OnEnteringFemurBreaker** - %player P

**OnActivatingWarheadPanel** - %player P 

**OnKicked** - %player P | %kickerName S | %reason S

**OnBanned** - %player P | %bannerName S | %reason S

**OnEscapingPocketDimension** - %player P

**OnFailingEscapePocketDimension** - %player P

**OnDetonating** - %player P

**OnRespawningTeam** - %team S | %numberofplayers S

**OnRespawningMTF** - %numbeofplayers S

**OnRespawningCI** - %numberofplayers S

Planned feature: OnRespawningSH

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
