using DRS.ModulesMod.Handlers;
using HarmonyLib;

namespace DRS.ModulesMod.Patches
{
    [HarmonyPatch(typeof(Exosuit), nameof(Exosuit.Awake))]
    public class ExosuitAwake
    {
        [HarmonyPrefix]
        public static void AwakePrefix(Exosuit __instance) 
        {
            __instance.gameObject.EnsureComponent<ExosuitHandler>();
        }
    }
}
