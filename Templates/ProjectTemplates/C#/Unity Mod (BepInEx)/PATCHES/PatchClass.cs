using HarmonyLib;

namespace $safeprojectname$
{
    [HarmonyPatch(typeof(PlayerCharacter))]
    internal class $safeitemname$
    {
        /// <summary>
        /// Patches the PlayerCharacter Awake method with prefix code.
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPatch(nameof(PlayerCharacter.Awake))]
        [HarmonyPrefix]
        public static bool AwakePrefix(PlayerCharacter __instance)
        {
            $safeprojectname$Plugin.Log.LogDebug("In Player Awake method Prefix.");
            return true;
        }

        /// <summary>
        /// Patches the PlayerCharacter Awake method with postfix code.
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPatch(nameof(PlayerCharacter.Awake))]
        [HarmonyPostfix]
        public static void AwakePostfix(PlayerCharacter __instance)
        {
            $safeprojectname$Plugin.Log.LogDebug("In Player Awake method Postfix.");
        }
    }
}