
using Nautilus.Assets;
using static CraftData;

namespace DRS.ModulesMod.Modules.All
{
    public static class TorpedoAccelerator
    {
        public static PrefabInfo info;

        public static void Patch()
        {
            var recipe = Helpers.CreateRecipe(1,
                new Ingredient(TechType.Tank, 1),
                new Ingredient(TechType.Silicone, 1),
                new Ingredient(TechType.Magnetite, 1));

            info = Helpers.CreatePrefabInfo("TorpedoAcceleratorModule", "Torpedo accelerator module", "Increases damage and firing rate of torpedo system bay or torpedo arm.\n\nSeamoth and Prawn Suit compatible", Helpers.GetSprite(TechType.SeamothTorpedoModule));
            var prefab = Helpers.CreatePrefab(Helpers.ModuleType.General, info, recipe);

            prefab.Register();
        }
    }
}