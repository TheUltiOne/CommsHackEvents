using Exiled.API.Features;
using Exiled.API.Enums;

using Server = Exiled.Events.Handlers.Server;

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
            
        }

        public void UnregisterEvents()
        {
            events = null;
        }
    }
}