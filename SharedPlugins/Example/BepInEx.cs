
using BepInEx.Logging;
using BepInEx;
using HarmonyLib;

namespace DRS.Example
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    [BepInProcess("Subnautica.exe")]
    public class Example : BaseUnityPlugin
    {
        private const string myGUID = "com.drs.Example";
        private const string pluginName = "Example";
        private const string versionString = "1.0.0";
        private static readonly Harmony harmony = new Harmony(myGUID);
        public static ManualLogSource logger;

        public void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo(pluginName + " " + versionString + " " + "has been loaded! (yay)");
            logger = Logger;
        }
    }
}