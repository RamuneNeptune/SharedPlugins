
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

            ModuleStation.Patch();
            CraftTreeHandler.AddTabNode(ModuleStation.TreeType, "General", "General", Helpers.GetSprite(TechType.Constructor), "Modules");
            CraftTreeHandler.AddTabNode(ModuleStation.TreeType, "Seamoth", "Seamoth", Helpers.GetSprite(TechType.Seamoth), "Modules");
            CraftTreeHandler.AddTabNode(ModuleStation.TreeType, "Exosuit", "Prawn suit", Helpers.GetSprite(TechType.Exosuit), "Modules");
            CraftTreeHandler.AddTabNode(ModuleStation.TreeType, "Cyclops", "Cyclops", Helpers.GetSprite(TechType.Cyclops), "Modules");

            LanguageHandler.SetLanguageLine("11Menu_General", "General");
            LanguageHandler.SetLanguageLine("11Menu_Seamoth", "Seamoth");
            LanguageHandler.SetLanguageLine("11Menu_Exosuit", "Exosuit");
            LanguageHandler.SetLanguageLine("11Menu_Cyclops", "Cyclops");

            Modules.All.EngineOvercharge.Patch();
            Modules.All.TorpedoAccelerator.Patch();
            Modules.All.TorpedoDoubleshot.Patch();
            Modules.Cyclops.SonarMK1.Patch();
            Modules.Cyclops.SonarMK2.Patch();
            Modules.Cyclops.SonarRange.Patch();
            Modules.Exosuit.JumpJet.Patch();
            Modules.Seamoth.Example.Patch();
            
            Logger.LogInfo(pluginName + " " + versionString + " " + "has breached the mainframe.. successfully loaded");
            logger = Logger;
        }
    }
}