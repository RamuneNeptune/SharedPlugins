
using Nautilus.Assets;
using static CraftData;

namespace DRS.ModulesMod.Modules.Seamoth
{
    public static class Example
    {
        public static PrefabInfo info;

        public static void Patch()
        {
            var recipe = Helpers.CreateRecipe(1,
                new Ingredient(TechType.Tank, 1),
                new Ingredient(TechType.Silicone, 1),
                new Ingredient(TechType.Magnetite, 1));

            info = Helpers.CreatePrefabInfo("Example", "Example seamoth module", "An advanced upgrade to the Seamoth torpedo systems.\n\nSeamoth compatible", Helpers.GetSprite(TechType.SeamothElectricalDefense));
            var prefab = Helpers.CreatePrefab(Helpers.ModuleType.Seamoth, info, recipe);

            prefab.Register();
        }
    }
}