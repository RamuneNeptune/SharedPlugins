using Nautilus.Assets;
using System;
using System.Collections.Generic;

namespace DRS.ModulesMod.Modules.Seamoth
{
    public class EngineOvercharge
    {
        public static PrefabInfo Info { get; private set; }

        public static void Patch()
        {
            Info = Helpers.CreatePrefabInfo("SeamothEngineOverchargeModule", "Engine overcharge module", "test", Helpers.GetSprite(TechType.SeamothElectricalDefense));

            var recipe = Helpers.CreateRecipe(1,
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.GasPod, 2),
                new CraftData.Ingredient(TechType.Quartz, 1) );

            var engineOverchargePrefab = Helpers.CreatePrefab(Helpers.ModuleType.Seamoth, Info, recipe);

            engineOverchargePrefab.Register();
        }
    }
}
