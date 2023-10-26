using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using BepInEx.Unity.IL2CPP;

namespace $safeprojectname$
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class $safeitemname$ : BasePlugin
    {
        private const string MyGUID = "MYGUID";
        private const string PluginName = "PLUGINNAME";
        private const string VersionString = "1.0.0";

        public static ConfigEntry<int> IntExample;

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        /// <summary>
        /// Initialise the configuration settings and patch methods
        /// </summary>
        public override void Load()
        {
            // Int setting example
            IntExample = Config.Bind("General",
                "Int Example Key",
                1,
                new ConfigDescription("Example int configuration setting.",
                    new AcceptableValueRange<int>(0, 10)));
            // Apply all of our patches
            Harmony.PatchAll();
            Log.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");

            // Sets up our static Log, so it can be used elsewhere in code.
            // .e.g.
            // PLUGINCLASS.Log.LogDebug("Debug Message to BepInEx log file");
            Log = base.Log;
        }
    }
}
