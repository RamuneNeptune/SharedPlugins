
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using DRS.ModulesMod.Modules.Seamoth;
using Nautilus.Handlers;

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
            PatchModules();

            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "DSRModules", "Modules", Helpers.GetSprite(TechType.Peeper));
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "General", "General", Helpers.GetSprite(TechType.Peeper), "DSRModules");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Seamoth", "Seamoth", Helpers.GetSprite(TechType.Peeper), "DSRModules");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Exosuit", "Prawn suit", Helpers.GetSprite(TechType.Peeper), "DSRModules");
            CraftTreeHandler.AddTabNode(CraftTree.Type.Workbench, "Cyclops", "Cyclops", Helpers.GetSprite(TechType.Peeper), "DSRModules");

            Logger.LogInfo(pluginName + " " + versionString + " " + "has breached the mainframe.. successfully loaded");
            logger = Logger;
        }

        public void PatchModules()
        {
            EngineOvercharge.Patch();
        }
    }
}