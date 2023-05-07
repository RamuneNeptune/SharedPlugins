
using Nautilus.Assets;
using static CraftData;

namespace DRS.ModulesMod.Modules.Cyclops
{
    public static class SonarMK1
    {
        public static PrefabInfo info;

        public static void Patch()
        {
            var recipe = Helpers.CreateRecipe(1,
                new Ingredient(TechType.Tank, 1),
                new Ingredient(TechType.Silicone, 1),
                new Ingredient(TechType.Magnetite, 1));

            info = Helpers.CreatePrefabInfo("CyclopsSonarModuleMK1", "Cyclops sonar enhancement module MK1", "An upgrade to the Cyclops sonar systems.\n\nCyclops compatible", Helpers.GetSprite(TechType.CyclopsSonarModule));
            var prefab = Helpers.CreatePrefab(Helpers.VehicleType.Cyclops, info, recipe);

            prefab.Register();
        }
    }
}