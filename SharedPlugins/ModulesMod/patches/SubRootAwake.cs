using DRS.ModulesMod.Handlers;
using HarmonyLib;

namespace DRS.ModulesMod.Patches
{
    [HarmonyPatch(typeof(SubRoot), nameof(SubRoot.Awake))]
    public class SubRootAwake
    {
        public static void Prefix(SubRoot __instance) 
        {
            if(__instance.isCyclops) __instance.gameObject.EnsureComponent<CyclopsHandler>();
        }
    }
}