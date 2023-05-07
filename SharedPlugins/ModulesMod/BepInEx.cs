
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using Nautilus.Handlers;
using Modules = DRS.ModulesMod.Modules;
using System.Linq;

namespace DRS.ModulesMod
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class ModulesMod : BaseUnityPlugin
    {
        private const string myGUID = "com.drs.ModulesMod";
        private const string pluginName = "ModulesMod";
        private const string versionString = "1.0.0";
        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Helpers.PatchFabricator();
            Helpers.PatchLanguageLines();
            Helpers.PatchModules();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has breached the mainframe.. successfully loaded");
            logger = Logger;
        }
    }
}