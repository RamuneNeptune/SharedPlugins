
using Nautilus.Assets;
using static CraftData;

namespace DRS.ModulesMod.Modules.Cyclops
{
    public static class SonarMK2
    {
        public static PrefabInfo info;

        public static void Patch()
        {
            var recipe = Helpers.CreateRecipe(1,
                new Ingredient(TechType.Tank, 1),
                new Ingredient(TechType.Silicone, 1),
                new Ingredient(TechType.Magnetite, 1));

            info = Helpers.CreatePrefabInfo("CyclopsSonarModuleMK2", "Cyclops sonar module MK2", "An upgrade to the Cyclops sonar systems.\n\nCyclops compatible", Helpers.GetSprite(TechType.CyclopsSonarModule));
            var prefab = Helpers.CreatePrefab(Helpers.ModuleType.Cyclops, info, recipe);

            prefab.Register();
        }
    }
}