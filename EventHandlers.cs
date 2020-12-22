using Exiled.Events.EventArgs;
using Exiled.API.Features;
using System.Collections.Generic;
using CommsHack;
using Exiled.API.Enums;


namespace CommsHackEvents
{
    class EventHandlers
    {
        public static Dictionary<string, string> eventsS = CommsHackEvents.Instance.Config.EventsSounds;
        public static Dictionary<string, string> eventsC = CommsHackEvents.Instance.Config.EventsCassie;
        public static Dictionary<string, string> eventsBc = CommsHackEvents.Instance.Config.EventsBroadcast;
        public static Dictionary<string, string> eventsF = CommsHackEvents.Instance.Config.EventsFunctions;

        public static List<string> workingFunctions = new List<string>() { "SCPAnnouncement", "ScanFacility" };

        public string FilterString(string toFilter, Player player, DamageTypes.DamageType cause = null, int NumberOfRespawns = 0, string killerName = null, Respawning.SpawnableTeamType spawnableTeam = Respawning.SpawnableTeamType.None, string reason = null)
        {
            var filteredString = toFilter;

            Dictionary<string, string> filterablesReturns = new Dictionary<string, string>() {
                { "%playerName", player.Nickname },
                { "%playerDisplayNickname", player.DisplayNickname },
                { "%playerRank", player.RankName },
                { "%playerRankColor", player.RankColor },
                { "%playerRole", player.Role.ToString() },
                { "%playerSide", player.Side.ToString() },
                { "%serverName", Server.Name },
                { "%playerListTitle", PlayerList.Title.ToString() },
                { "%team", spawnableTeam.ToString() },
                { "%reason", reason },
                { "%attacker", killerName },
                { "%numberOfSpawns", NumberOfRespawns.ToString() },
                { "%cause", cause.ToString() },
                { "%player", " " }
            };

            foreach (string key in filterablesReturns.Keys)
            {
                filteredString.Replace(key, filterablesReturns[key]);
            }

            return filteredString;
        }

        public void CheckForEvent(string EventName, bool HasPlayerParam, bool HasExtraParam, Player player = null, DamageTypes.DamageType cause = null, int NumberOfRespawns = 0, string killerName = null, Respawning.SpawnableTeamType spawnableTeam = Respawning.SpawnableTeamType.None, string reason = null)
        {
            var config = CommsHackEvents.Instance.Config;
            if (eventsS.ContainsKey(EventName))
            {
                AudioAPI.API.PlayFile(eventsS[EventName], CommsHackEvents.Instance.Config.Volume);
            }
            if (eventsBc.ContainsKey(EventName))
            {
                if (HasPlayerParam)
                {
                    if (HasExtraParam)
                    {
                        Map.Broadcast(config.Duration, FilterString(eventsBc[EventName], player, cause, NumberOfRespawns, killerName, spawnableTeam, reason));
                    }
                    Map.Broadcast(config.Duration, FilterString(eventsBc[EventName], player));
                }
            }
            if (eventsC.ContainsKey(EventName))
            {
                if (HasExtraParam)
                {
                    Cassie.Message(FilterString(eventsC[EventName], player, cause, NumberOfRespawns, killerName, spawnableTeam, reason));
                }
                Cassie.Message(FilterString(eventsC[EventName], player));
            }
            if (eventsF.ContainsKey(EventName))
            {
                Map.Broadcast(5, "Please contact a server admin: CommsHackEvents functions is not supported yet.");
            }
        }

        public void OnJoined(JoinedEventArgs ev)
        {
            CheckForEvent("OnJoined", true, false, ev.Player);
        }

        public void OnLeft(LeftEventArgs ev)
        {
            CheckForEvent("OnLeft", true, false, ev.Player);
        }

        public void OnHurting(HurtingEventArgs ev)
        {
            CheckForEvent("OnHurting", true, true, ev.Target, killerName: ev.Attacker.Nickname, cause: ev.DamageType);
        }

        public void OnDying (DyingEventArgs ev)
        {
            CheckForEvent("OnDying", true, true, ev.Target, killerName: ev.Killer.Nickname, cause: ev.HitInformation.GetDamageType());
        }


        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
            {
                CheckForEvent("OnRespawningCI", false, true, NumberOfRespawns: ev.MaximumRespawnAmount);
            } else
            {
                CheckForEvent("OnRespawningMTF", false, true, NumberOfRespawns: ev.MaximumRespawnAmount);
            }
            CheckForEvent("OnRespawningTeam", false, true, spawnableTeam: ev.NextKnownTeam, NumberOfRespawns: ev.MaximumRespawnAmount);
        }

        public void OnFailingEscapePocketDimension(FailingEscapePocketDimensionEventArgs ev)
        {
            CheckForEvent("OnFailingEscapePocketDimension", true, false, ev.Player);
        }

        public void OnEscapingPocketDimension(EscapingPocketDimensionEventArgs ev)
        {
            CheckForEvent("OnEscapingPocketDimension", true, false, ev.Player);
        }

        public void OnEscaping(EscapingEventArgs ev)
        {
            CheckForEvent("OnEscaping", true, false, ev.Player);
        }

        public void OnKicked(KickedEventArgs ev)
        {
            CheckForEvent("OnKicked", true, true, ev.Target, reason: ev.Reason);
        }

        public void OnBanned(BannedEventArgs ev)
        {
            CheckForEvent("OnBanned", true, true, ev.Target, reason: ev.Details.Reason);
        }

        public void OnEndingRound()
        {
            CheckForEvent("OnEndingRound", false, false);
        }

        public void OnWaitingForPlayers()
        {
            CheckForEvent("OnWaitingForPlayers", false, false);
        }

        public void OnRoundStarting()
        {
            CheckForEvent("OnRoundStarting", false, false);
        }

        public void OnInsertingGeneratorTablet(InsertingGeneratorTabletEventArgs ev)
        {
            CheckForEvent("OnRoundStarting", true, false, ev.Player);
        }

        public void OnEjectingGeneratorTablet(EjectingGeneratorTabletEventArgs ev)
        {
            CheckForEvent("OnRoundStarting", true, false, ev.Player);
        }

        public void OnEnteringFemurBreaker(EnteringFemurBreakerEventArgs ev)
        {
            CheckForEvent("OnEnteringFemurBreaker", true, false, ev.Player);
        }

        public void OnActivatingWarheadPanel(ActivatingWarheadPanelEventArgs ev)
        {
            CheckForEvent("OnActivatingWarheadPanel", true, false, ev.Player);
        }

        public void OnDetonating()
        {
            CheckForEvent("OnDetonating", false, false);
        }
    }
}