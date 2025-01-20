using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace L0veRavenCore
{
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
            
            api.RegisterToken(this.ModManifest, "sixAM", () =>
            {
                string rawSixAM = "600";

                var sixAM = api.ParseTokenString(
                    manifest: this.ModManifest,
                    rawValue: rawSixAM,
                    formatVersion: new SemanticVersion("2.4.4")
                );

                sixAM.UpdateContext();
                string value = sixAM.Value;
            });
            
            api.RegisterToken(this.ModManifest, "sixTenAM", () =>
            {
                string rawSixTenAM = "610";

                var sixTenAM = api.ParseTokenString(
                    manifest: this.ModManifest,
                    rawValue: rawSixTenAM,
                    formatVersion: new SemanticVersion("2.4.4")
                );

                sixTenAM.UpdateContext();
                string value = sixTenAM.Value;
            });
            
            api.RegisterToken(this.ModManifest, "sixTwentyAM", () =>
            {
                string rawSixTwentyAM = "620";

                var sixTwentyAM = api.ParseTokenString(
                    manifest: this.ModManifest,
                    rawValue: rawSixTwentyAM,
                    formatVersion: new SemanticVersion("2.4.4")
                );

                sixTwentyAM.UpdateContext();
                string value = sixTwentyAM.Value;
            });
            
            api.RegisterToken(this.ModManifest, "sixThirtyAM", () =>
            {
                string rawSixThirtyAM = "630";
                var sixThirtyAM = api.ParseTokenString(
                    manifest: this.ModManifest,
                    rawValue: rawSixThirtyAM,
                    formatVersion: new SemanticVersion("2.4.4")
                );

                sixThirtyAM.UpdateContext();
                string value = sixThirtyAM.Value;
            });
            
            api.RegisterToken(this.ModManifest, "sixFortyAM", () =>
            {
                string rawSixFortyAM = "640";
                var sixFortyAM = api.ParseTokenString(
                    manifest: this.ModManifest,
                    rawValue: rawSixFortyAM,
                    formatVersion: new SemanticVersion("2.4.4")
                );

                sixFortyAM.UpdateContext();
                string value = sixFortyAM.Value;
            });
            
            api.RegisterToken(this.ModManifest, "sixFiftyAM", () =>
            {
                string rawSixFiftyAM = "650";
                var sixFiftyAM = api.ParseTokenString(
                    manifest: this.ModManifest,
                    rawValue: rawSixFiftyAM,
                    formatVersion: new SemanticVersion("2.4.4")
                );

                sixFiftyAM.UpdateContext();
                string value = sixFiftyAM.Value;
            });
            
            api.RegisterToken(this.ModManifest, "sevenAM", () =>
            {
                string rawSevenAM = "700";
                var sevenAM = api.ParseTokenString(
                    manifest: this.ModManifest,
                    rawValue: rawSevenAM,
                    formatVersion: new SemanticVersion("2.4.4")
                );

                sevenAM.UpdateContext();
                string value = sevenAM.Value;
            });
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
}
