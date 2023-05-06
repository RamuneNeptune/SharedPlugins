using DRS.ModulesMod.Handlers;
using HarmonyLib;

namespace DRS.ModulesMod.Patches
{
    [HarmonyPatch(typeof(Exosuit), nameof(Exosuit.Awake))]
    public class ExosuitAwake
    {
        public static void Prefix(Exosuit __instance) 
        {
            __instance.gameObject.EnsureComponent<ExosuitHandler>();
        }
    }
}