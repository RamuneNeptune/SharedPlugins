
using Nautilus.Assets;
using static CraftData;

namespace DRS.ModulesMod.Modules.Exosuit
{
    public static class JumpJet
    {
        public static PrefabInfo info;

        public static void Patch()
        {
            var recipe = Helpers.CreateRecipe(1,
                new Ingredient(TechType.Tank, 1),
                new Ingredient(TechType.Silicone, 1),
                new Ingredient(TechType.Magnetite, 1));

            info = Helpers.CreatePrefabInfo("ExosuitJetUpgradeModuleMK1", "Prawn suit jet upgrade MK1", "An advanced upgrade to the Prawn suit jets.\n\nExosuit compatible", Helpers.GetSprite(TechType.ExosuitJetUpgradeModule));
            var prefab = Helpers.CreatePrefab(Helpers.VehicleType.Exosuit, info, recipe);

            prefab.Register();
        }
    }
}