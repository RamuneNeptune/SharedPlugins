using DRS.ModulesMod.Handlers;
using HarmonyLib;

namespace DRS.ModulesMod.Patches
{
    [HarmonyPatch(typeof(SubRoot), nameof(SubRoot.Awake))]
    public class SubRootAwake
    {
        [HarmonyPrefix]
        public static void AwakePrefix(SubRoot __instance) 
        {
            if (__instance.isCyclops)
                __instance.gameObject.EnsureComponent<CyclopsHandler>();
        }
    }
}
