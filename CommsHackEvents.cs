using Exiled.API.Features;
using Exiled.API.Enums;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using Warhead = Exiled.Events.Handlers.Warhead;

using System;

namespace CommsHackEvents
{
    public class CommsHackEvents : Plugin<Config>
    {
        private static readonly Lazy<CommsHackEvents> LazyInstance = new Lazy<CommsHackEvents>(valueFactory: () => new CommsHackEvents());
        public static CommsHackEvents Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.First;

        private EventHandlers events;

        private CommsHackEvents()
        {
        }

        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            events = new EventHandlers();
            Server.WaitingForPlayers += events.OnWaitingForPlayers;
            Server.RoundStarted += events.OnRoundStarted;
            Server.EndingRound += events.OnEndingRound;
            Server.RestartingRound += events.OnRestartingRound;
            Server.RespawningTeam += events.OnRespawningTeam;

            Player.Joined += events.OnJoined;
            Player.Left += events.OnLeft;
            Player.EnteringFemurBreaker += events.OnEnteringFemurBreaker;
            Player.Dying += events.OnDying;
            Player.Hurting += events.OnHurting;
            Player.ActivatingWarheadPanel += events.OnActivatingWarheadPanel;
            Player.InsertingGeneratorTablet += events.OnInsertingGeneratorTablet;
            Player.EjectingGeneratorTablet += events.OnEjectingGeneratorTablet;
            Player.FailingEscapePocketDimension += events.OnFailingEscapePocketDimension;
            Player.EscapingPocketDimension += events.OnEscapingPocketDimension;
            Player.Escaping += events.OnEscaping;
            Player.Kicked += events.OnKicked;
            Player.Banned += events.OnBanned;

            Warhead.Detonated += events.OnDetonating;
        }

        public void UnregisterEvents()
        {
            Server.WaitingForPlayers -= events.OnWaitingForPlayers;
            Server.RoundStarted -= events.OnRoundStarted;
            Server.EndingRound -= events.OnEndingRound;
            Server.RestartingRound -= events.OnRestartingRound;
            Server.RespawningTeam -= events.OnRespawningTeam;

            Player.Joined -= events.OnJoined;
            Player.Left -= events.OnLeft;
            Player.EnteringFemurBreaker -= events.OnEnteringFemurBreaker;
            Player.Dying -= events.OnDying;
            Player.Hurting -= events.OnHurting;
            Player.ActivatingWarheadPanel -= events.OnActivatingWarheadPanel;
            Player.InsertingGeneratorTablet -= events.OnInsertingGeneratorTablet;
            Player.EjectingGeneratorTablet -= events.OnEjectingGeneratorTablet;
            Player.FailingEscapePocketDimension -= events.OnFailingEscapePocketDimension;
            Player.EscapingPocketDimension -= events.OnEscapingPocketDimension;
            Player.Escaping -= events.OnEscaping;
            Player.Kicked -= events.OnKicked;
            Player.Banned -= events.OnBanned;

            Warhead.Detonated -= events.OnDetonating;
            events = null;
        }
    }
}
