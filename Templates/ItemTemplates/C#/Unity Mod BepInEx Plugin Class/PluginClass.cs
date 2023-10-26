using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace $rootnamespace$
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class $safeitemname$ : BaseUnityPlugin
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
        private void Awake()
        {
            // Int setting example
            IntExample = Config.Bind("General",
                "Int Example Key",
                1,
                new ConfigDescription("Example int configuration setting.",
                    new AcceptableValueRange<int>(0, 10)));
            // Apply all of our patches
            Harmony.PatchAll();
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");

            // Sets up our static Log, so it can be used elsewhere in code.
            // .e.g.
            // PLUGINCLASS.Log.LogDebug("Debug Message to BepInEx log file");
            Log = Logger;
        }
    }
}
