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

            api.RegisterToken(this.ModManifest, "sixA", () =>
            {
                string sixAm = "600";

                // save is loaded
                if (Context.IsWorldReady)
                    return new[] { sixAm };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new[] { sixAm };

                // no save loaded (e.g. on the title screen)
                return new[] { sixAm };
            });

            api.RegisterToken(this.ModManifest, "sixtenA", () =>
            {
                string sixTenAm = "610";

                // save is loaded
                if (Context.IsWorldReady)
                    return new[] { sixTenAm };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new[] { sixTenAm };

                // no save loaded (e.g. on the title screen)
                return new[] { sixTenAm };
            });

            api.RegisterToken(this.ModManifest, "sixtwentyA", () =>
            {
                string sixTwentyAm = "620";

                // save is loaded
                if (Context.IsWorldReady)
                    return new[] { sixTwentyAm };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new[] { sixTwentyAm };

                // no save loaded (e.g. on the title screen)
                return new[] { sixTwentyAm };
            });

            api.RegisterToken(this.ModManifest, "sixthirtyA", () =>
            {
                string sixThirtyAm = "630";

                // save is loaded
                if (Context.IsWorldReady)
                    return new[] { sixThirtyAm };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new[] { sixThirtyAm };

                // no save loaded (e.g. on the title screen)
                return new[] { sixThirtyAm };
            });

            api.RegisterToken(this.ModManifest, "sixfortyA", () =>
            {
                string sixFortyAm = "640";

                // save is loaded
                if (Context.IsWorldReady)
                    return new[] { sixFortyAm };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new[] { sixFortyAm };

                // no save loaded (e.g. on the title screen)
                return new[] { sixFortyAm };
            });

            api.RegisterToken(this.ModManifest, "sixfiftyA", () =>
            {
                string sixFiftyAm = "650";

                // save is loaded
                if (Context.IsWorldReady)
                    return new[] { sixFiftyAm };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new[] { sixFiftyAm };

                // no save loaded (e.g. on the title screen)
                return new[] { sixFiftyAm };
            });

            api.RegisterToken(this.ModManifest, "sevenA", () =>
            {
                string sevenAm = "700";

                // save is loaded
                if (Context.IsWorldReady)
                    return new[] { sevenAm };

                // or save is currently loading
                if (SaveGame.loaded?.player != null)
                    return new[] { sevenAm };

                // no save loaded (e.g. on the title screen)
                return new[] { sevenAm };
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
