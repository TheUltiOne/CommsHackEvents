using System.ComponentModel;
using Exiled.API.Interfaces;
using System.Collections.Generic;

namespace CommsHackEvents
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Sets the events where the soundfile can be used. Usage: EventName -> File name | Compatible events can be found in the README")]
        public Dictionary<string, string> EventsSounds = new Dictionary<string, string>() { { "OnJoined", "example.mp3" }, { "OnLeft", "example2.mp3" }, { "OnWaitingForPlayers", "example.mp3" } };

        [Description("Sets the volume of sounds played")]
        public int Volume = 5;

        [Description("Sets the events where Cassie can talk. Usage: EventName -> Message to say | Compatible events can be found in the README")]
        public Dictionary<string, string> EventsCassie = new Dictionary<string, string>() { { "OnInsertingGeneratorTablet", "GENERATOR ENGAGED IN T-MINUS 90 SECONDS" }, { "OnEjectingGeneratorTablet", "GENERATOR CANCELLED"} };

        [Description("Sets the events where a broadcast is sent. Usage: EventName -> Message to say | Compatible events can be found in the README")]
        public Dictionary<string, string> EventsBroadcast = new Dictionary<string, string>() { { "OnActivatingWarheadPanel", "%playerName has activated the Alpha Warhead Panel!" }, { "OnDying", "%playerName (%playerClass) has died (%deathCause)"} };

        [Description("Sets the duration of broadcasts")]
        public ushort Duration = 5;

        [Description("Sets the events where a broadcast is sent. Usage: EventName -> Funtion | Functions can be found in the README")]
        public Dictionary<string, string> EventsFunctions = new Dictionary<string, string>() { { "OnRoundStarted", "SCPAnnouncement" }, { "OnRespawningTeam", "ScanFacilityDelayed" } };
    }
}
