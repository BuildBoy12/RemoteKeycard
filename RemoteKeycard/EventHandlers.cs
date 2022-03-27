// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace RemoteKeycard
{
    using Exiled.Events.EventArgs;
    using Interactables.Interobjects.DoorUtils;
    using PlayerHandlers = Exiled.Events.Handlers.Player;

    /// <summary>
    /// Handles all the events this plugin needs to function.
    /// </summary>
    public class EventHandlers
    {
        private readonly Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="config">The <see cref="Config"/> settings that will be used.</param>
        public EventHandlers(Config config) => this.config = config;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void Subscribe()
        {
            PlayerHandlers.InteractingDoor += OnDoorInteract;
            PlayerHandlers.UnlockingGenerator += OnGeneratorUnlock;
            PlayerHandlers.InteractingLocker += OnLockerInteract;
            PlayerHandlers.ActivatingWarheadPanel += OnWarheadUnlock;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            PlayerHandlers.InteractingDoor -= OnDoorInteract;
            PlayerHandlers.UnlockingGenerator -= OnGeneratorUnlock;
            PlayerHandlers.InteractingLocker -= OnLockerInteract;
            PlayerHandlers.ActivatingWarheadPanel -= OnWarheadUnlock;
        }

        private void OnDoorInteract(InteractingDoorEventArgs ev)
        {
            if (!config.AffectDoors)
                return;

            if (!ev.IsAllowed && ev.Player.HasKeycardPermission(ev.Door.RequiredPermissions.RequiredPermissions))
            {
                ev.IsAllowed = true;
            }
        }

        private void OnWarheadUnlock(ActivatingWarheadPanelEventArgs ev)
        {
            if (!config.AffectWarheadPanel)
                return;

            if (!ev.IsAllowed && ev.Player.HasKeycardPermission(KeycardPermissions.AlphaWarhead))
            {
                ev.IsAllowed = true;
            }
        }

        private void OnGeneratorUnlock(UnlockingGeneratorEventArgs ev)
        {
            if (!config.AffectGenerators)
                    return;

            if (!ev.IsAllowed && ev.Player.HasKeycardPermission(ev.Generator.Base._requiredPermission))
            {
                ev.IsAllowed = true;
            }
        }

        private void OnLockerInteract(InteractingLockerEventArgs ev)
        {
            if (!config.AffectScpLockers)
                return;

            if (!ev.IsAllowed && ev.Chamber != null && ev.Player.HasKeycardPermission(ev.Chamber.RequiredPermissions, true))
            {
                ev.IsAllowed = true;
            }
        }
    }
}