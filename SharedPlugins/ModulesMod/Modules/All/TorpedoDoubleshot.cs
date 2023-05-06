
using Nautilus.Assets;
using static CraftData;

namespace DRS.ModulesMod.Modules.All
{
    public static class TorpedoDoubleshot
    {
        public static PrefabInfo info;

        public static void Patch()
        {
            var recipe = Helpers.CreateRecipe(1,
                new Ingredient(TechType.Tank, 1),
                new Ingredient(TechType.Silicone, 1),
                new Ingredient(TechType.Magnetite, 1));

            info = Helpers.CreatePrefabInfo("TorpedoDoubleshotModule", "Torpedo doubleshot module", "Adds a doubleshot functionality to the torpedo bay or torpedo arm, allowing two projectiles to be launched at once.\n\nSeamoth and Prawn Suit compatible", Helpers.GetSprite(TechType.SeamothTorpedoModule));
            var prefab = Helpers.CreatePrefab(Helpers.ModuleType.General, info, recipe);

            prefab.Register();
        }
    }
}