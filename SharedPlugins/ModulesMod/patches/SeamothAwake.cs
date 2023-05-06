using DRS.ModulesMod.Handlers;
using HarmonyLib;

namespace DRS.ModulesMod.Patches
{
    [HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Awake))]
    public class SeamothAwake
    {
        public static void Prefix(SeaMoth __instance) 
        {
            __instance.gameObject.EnsureComponent<SeamothHandler>();
        }
    }
}