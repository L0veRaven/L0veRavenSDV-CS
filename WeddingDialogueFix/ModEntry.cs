using System;
using ContentPatcher;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;


namespace WeddingDialogueFix
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

            api.RegisterToken(this.ModManifest, "FarmerMarriesFarmer", () =>
            {
                if (GameStateQuery.CheckConditions("PLAYER_PLAYER_RELATIONSHIP") == true)
                {
                    this.Monitor.Log($"{Game1.player.Name} is with another farmer.", LogLevel.Debug);
                    return true;
                }

                else
                {
                    this.Monitor.Log($"{Game1.player.Name} isn't with another farmer.", LogLevel.Debug);
                    return false;
                }
            });

            api.RegisterToken(this.ModManifest, "FarmerMarriesFarmer", () =>
            {
                if (GameStateQuery.CheckConditions("PLAYER_PLAYER_RELATIONSHIP") == true)
                {
                    this.Monitor.Log($"{Game1.player.Name} is with another farmer.", LogLevel.Debug);
                    return true;
                }

                else
                {
                    this.Monitor.Log($"{Game1.player.Name} isn't with another farmer.", LogLevel.Debug);
                    return false;
                }
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
