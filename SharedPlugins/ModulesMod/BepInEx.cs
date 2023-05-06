
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

            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "LithiumIonBattery");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "HeatBlade");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "PlasteelTank");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "HighCapacityTank");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "UltraGlideFins");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "SwimChargeFins");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "RepulsionCannon");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "CyclopsHullModule2");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "CyclopsHullModule3");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "SeamothHullModule2");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "SeamothHullModule3");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Workbench, "ExoHullModule2");

            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Modules", "Modules", Helpers.GetSprite(TechType.Constructor));
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "General", "General", Helpers.GetSprite(TechType.Constructor), "Modules");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Seamoth", "Seamoth", Helpers.GetSprite(TechType.Seamoth), "Modules");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Exosuit", "Prawn suit", Helpers.GetSprite(TechType.Exosuit), "Modules");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Cyclops", "Cyclops", Helpers.GetSprite(TechType.Cyclops), "Modules");

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