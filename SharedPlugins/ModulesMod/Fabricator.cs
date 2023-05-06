using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;
using static CraftData;

namespace DRS.ModulesMod
{
    public static class Fabricator
    {
        public static void Patch()
        {
            var info = Helpers.CreatePrefabInfo("ModuleStation", "Module station", "A crafting station for modules.", Helpers.GetSprite(TechType.Fabricator));
            var tex = Helpers.GetTexutre("ModuleStation");
            var prefab = new CustomPrefab(info);

            var craftTree = prefab.CreateFabricator(out CraftTree.Type treeType);
            var model = new FabricatorTemplate(prefab.Info, treeType)
            {
                FabricatorModel = FabricatorTemplate.Model.MoonPool,
                ModifyPrefab = obj => obj.GetComponentInChildren<SkinnedMeshRenderer>().material.mainTexture = tex
            };

            prefab.SetGameObject(model);
            prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);
            prefab.SetRecipe(Helpers.CreateRecipe(0,
                new Ingredient(TechType.Silver, 1),
                new Ingredient(TechType.Gold, 1)));

            prefab.Register();
        }
    }
}