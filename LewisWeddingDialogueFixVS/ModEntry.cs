using System; // Base C# system library
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using StardewModdingAPI; // Using SMAPI library
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Events;
using StardewValley.Delegates;

namespace LewisWeddingDialogueFix
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += (s, e) =>
            {
                var api = this.Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher");
                helper.Events.Player.Warped += Player_Warped;

                api.RegisterToken(this.ModManifest, "FarmerMarriesFarmer2", () =>
                {
                    // save is loaded
                    if (Context.IsWorldReady)
                        return new[] { Game1.player.Name };

                    // or save is currently loading
                    if (SaveGame.loaded?.player != null)
                        return new[] { SaveGame.loaded.player.Name };

                    // no save loaded (e.g. on the title screen)
                    return null;
                });

                api.RegisterToken(((Mod)this).ModManifest, "FarmerMarriesFarmer", delegate
                {
                    if (Context.IsWorldReady)
                    {
                        
                    }
                    return (IEnumerable<string>)null;
                });
            };
        }

        private void Player_Warped(object sender, StardewModdingAPI.Events.WarpedEventArgs e)
        {
            if (e.NewLocation.Name == "Custom_L0veRaven_RavenTentInside")
            {
                Game1.hudMessages.Add(new HUDMessage("Welcome to Raven's Tent!", HUDMessage.newQuest_type));
            }
        }
    }
}
