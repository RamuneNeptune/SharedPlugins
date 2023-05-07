
using Nautilus.Assets;
using static CraftData;

namespace DRS.ModulesMod.Modules.All
{
    public static class EngineOvercharge
    {
        public static PrefabInfo info;

        public static void Patch()
        {
            var recipe = Helpers.CreateRecipe(1,
                new Ingredient(TechType.Tank, 1),
                new Ingredient(TechType.Silicone, 1),
                new Ingredient(TechType.Magnetite, 1));

            info = Helpers.CreatePrefabInfo("EngineOverchargeModule", "Engine overcharge module", "Temporarily overcharge vehicle engine providing a temporary speed boost at the cost of more energy usage.\n\nSeamoth, Prawn Suit, and Cyclops compatible", Helpers.GetSprite(TechType.PowerUpgradeModule));
            var prefab = Helpers.CreatePrefab(Helpers.VehicleType.General, info, recipe);

            prefab.Register();
        }

        static void OnEquip()
        {
            ModulesMod.logger.LogInfo("EngineOvercharge equipped.");
        }
    }
}