﻿using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace ContentPatcher;

/// <summary>The Content Patcher API which other mods can access.</summary>
public interface IContentPatcherAPI
{
    /*********
    ** Accessors
    *********/
    /// <summary>Whether the conditions API is initialized and ready for use.</summary>
    /// <remarks>Due to the Content Patcher lifecycle, the conditions API becomes available roughly two ticks after the <see cref="IGameLoopEvents.GameLaunched"/> event.</remarks>
    bool IsConditionsApiReady { get; }

    /// <summary>Register a simple token.</summary>
    /// <param name="mod">The manifest of the mod defining the token (see <see cref="Mod.ModManifest"/> in your entry class).</param>
    /// <param name="name">The token name. This only needs to be unique for your mod; Content Patcher will prefix it with your mod ID automatically, like <c>YourName.ExampleMod/SomeTokenName</c>.</param>
    /// <param name="getValue">A function which returns the current token value. If this returns a null or empty list, the token is considered unavailable in the current context and any patches or dynamic tokens using it are disabled.</param>
    void RegisterToken(IManifest mod, string name, Func<IEnumerable<string>?> getValue);
}