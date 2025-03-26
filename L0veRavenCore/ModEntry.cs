using System;
using ContentPatcher;
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

            api.RegisterToken(this.ModManifest, "sixam", () =>
            {
                // save is loaded
                if (Context.IsWorldReady)
                    return new string[] { "600" };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new string[] { "600" };

                // no save loaded (e.g. on the title screen)
                return null;
            });

            api.RegisterToken(this.ModManifest, "sixtenam", () =>
            {
                // save is loaded
                if (Context.IsWorldReady)
                    return new string[] { "610" };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new string[] { "610" };

                // no save loaded (e.g. on the title screen)
                return null;
            });

            api.RegisterToken(this.ModManifest, "sixtenam", () =>
            {
                // save is loaded
                if (Context.IsWorldReady)
                    return new string[] { "610" };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new string[] { "610" };

                // no save loaded (e.g. on the title screen)
                return null;
            });

            api.RegisterToken(this.ModManifest, "sixthirtyam", () =>
            {
                // save is loaded
                if (Context.IsWorldReady)
                    return new string[] { "630" };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new string[] { "630" };

                // no save loaded (e.g. on the title screen)
                return null;
            });

            api.RegisterToken(this.ModManifest, "sixfortyam", () =>
            {
                // save is loaded
                if (Context.IsWorldReady)
                    return new string[] { "640" };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new string[] { "640" };

                // no save loaded (e.g. on the title screen)
                return null;
            });

            api.RegisterToken(this.ModManifest, "sixfiftyam", () =>
            {
                // save is loaded
                if (Context.IsWorldReady)
                    return new string[] { "650" };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new string[] { "650" };

                // no save loaded (e.g. on the title screen)
                return null;
            });

            api.RegisterToken(this.ModManifest, "sevenam", () =>
            {
                // save is loaded
                if (Context.IsWorldReady)
                    return new string[] { "700" };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new string[] { "700" };

                // no save loaded (e.g. on the title screen)
                return null;
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