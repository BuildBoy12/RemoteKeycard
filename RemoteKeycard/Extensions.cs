// -----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace RemoteKeycard
{
    using System.Linq;
    using CustomPlayerEffects;
    using Exiled.API.Features;
    using Exiled.API.Features.Items;
    using Interactables.Interobjects.DoorUtils;

    /// <summary>
    /// A set of extensions used in this plugin.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Checks whether the player has a keycard of a specific permission.
        /// </summary>
        /// <param name="player"><see cref="Player"/> trying to interact.</param>
        /// <param name="permissions">The permission that's gonna be searched for.</param>
        /// <param name="requiresAllPermissions">Whether all permissions are required.</param>
        /// <returns>Whether the player has the required keycard.</returns>
        public static bool HasKeycardPermission(this Player player, KeycardPermissions permissions, bool requiresAllPermissions = false)
        {
            if (Plugin.Instance.Config.AmnesiaMatters && player.GetEffectActive<Amnesia>())
                return false;

            return requiresAllPermissions ?
                player.Items.Any(item => item is Keycard keycard && keycard.Base.Permissions.HasFlagFast(permissions))
                : player.Items.Any(item => item is Keycard keycard && (keycard.Base.Permissions & permissions) != 0);
        }
    }
}
