using StardewModdingAPI;
using ImprovedMiniBars.Framework.Rendering;
using ImprovedMiniBars.Framework;
using StardewModdingAPI.Events;
using StardewValley;

namespace ImprovedMiniBars
{
    public class ModEntry : Mod
    {
        public static ModEntry instance;
        public static Config config;

        public override void Entry(IModHelper helper)
        {
            instance = this;
            config = helper.ReadConfig<Config>();

            Textures.LoadTextures();

            helper.Events.Display.RenderedWorld += MonsterRenderer.OnRendered;
            helper.Events.Display.RenderedWorld += PlayerRenderer.OnRendered;
            helper.Events.Player.Warped += ModEntry.OnWarped;
            helper.ConsoleCommands.Add("minibars_theme", "Change the bars theme.\nUsage: minibars_theme '1 or 2'", Commands.Theme);
            helper.ConsoleCommands.Add("minibars_showfull", "Enable or disable showing healthbars when health is full.\nUsage: minibars_showfull 'true or false'", Commands.ShowFullLife);
            helper.ConsoleCommands.Add("minibars_range", "Enable or disable the range verification.\nUsage: minibars_range 'true or false'", Commands.RangeVerification);
            helper.ConsoleCommands.Add("minibars_showmonsterbars", "Enable or disable showing healthbars for monsters.\nUsage: minibars_monsterbars 'true or false'", Commands.ShowMonsterBars);
            helper.ConsoleCommands.Add("minibars_showplayerbar", "Enable or disable showing healthbar for player.\nUsage: minibars_showplayerbar 'true or false'", Commands.ShowPlayerBar);
        }

        public static void OnWarped(object sender, WarpedEventArgs e)
        {
            instance.Monitor.Log($"Game1.showingHealthBar is {Game1.showingHealthBar}", LogLevel.Debug);
            instance.Monitor.Log($"Game1.showingHealth is {Game1.showingHealth}", LogLevel.Debug);
        }
    }
}
