using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace L0veRavenCore;

/// <summary>The mod entry point.</summary>
internal sealed class ModEntry : Mod
{
    /*********
    ** Public methods
    *********/
    /// <summary>The mod entry point, called after the mod is first loaded.</summary>
    /// <param name="helper">Provides simplified APIs for writing mods.</param>
    public override void Entry(IModHelper helper)
    {
        helper.Events.Input.ButtonPressed += this.OnButtonPressed;

        this.Helper.Events.GameLoop.GameLaunched += GameLoop_GameLaunched;
    }

    private void GameLoop_GameLaunched(object? sender, GameLaunchedEventArgs e)
    {
        var api = this.Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");

        string rawSixAM = "600";
        string rawSixTenAM = "610";
        string rawSixTwentyAM = "620";
        string rawSixThirtyAM = "630";
        string rawSixFortyAM = "640";
        string rawSixFiftyAM = "650";
        string rawSevenAM = "700";

        api.RegisterToken(this.ModManifest, "sixAM", () => new string[1] { rawSixAM });
        api.RegisterToken(this.ModManifest, "sixTenAM", () => new string[1] { rawSixTenAM });
        api.RegisterToken(this.ModManifest, "sixTwentyAM", () => new string[1] { rawSixTwentyAM });
        api.RegisterToken(this.ModManifest, "sixThirtyAM", () => new string[1] { rawSixThirtyAM });
        api.RegisterToken(this.ModManifest, "sixFortyAM", () => new string[1] { rawSixFortyAM });
        api.RegisterToken(this.ModManifest, "sixFiftyAM", () => new string[1] { rawSixFiftyAM });
        api.RegisterToken(this.ModManifest, "sevenAM", () => new string[1] { rawSevenAM });
    }

    /*********
    ** Private methods
    *********/
    /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The event data.</param>
    private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
    {
        // ignore if player hasn't loaded a save yet
        if (!Context.IsWorldReady)
            return;

        // print button presses to the console window
        this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
    }
}
