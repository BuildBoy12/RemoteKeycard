// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace RemoteKeycard
{
    using System;
    using Exiled.API.Features;

    /// <summary>
    /// The plugin's core class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <summary>
        /// Gets the only instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc/>
        public override string Author => "Build";

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Instance = this;
            eventHandlers = new EventHandlers(Config);
            eventHandlers.Subscribe();
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            eventHandlers.Unsubscribe();
            eventHandlers = null;
            Instance = null;
            base.OnDisabled();
        }
    }
}
