// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace RemoteKeycard
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <summary>
    /// The plugin's main config file.
    /// </summary>
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether Amnesia affects the usage of keycards.
        /// </summary>
        [Description("Whether  Amnesia affects the usage of keycards.")]
        public bool AmnesiaMatters { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether this plugin works on generators.
        /// </summary>
        [Description("Whether this plugin works on generators.")]
        public bool AffectGenerators { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether this plugin works on Warhead's panel.
        /// </summary>
        [Description("Whether this plugin works on Warhead's panel.")]
        public bool AffectWarheadPanel { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether this plugin works on SCP lockers.
        /// </summary>
        [Description("Whether this plugin works on SCP lockers.")]
        public bool AffectScpLockers { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether this plugin works on doors.
        /// </summary>
        [Description("Whether this plugin works on doors.")]
        public bool AffectDoors { get; set; } = true;
    }
}
