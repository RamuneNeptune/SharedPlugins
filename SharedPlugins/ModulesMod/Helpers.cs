
using System;
using System.Collections.Generic;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Utility;
using static CraftData;
using Sprite = Atlas.Sprite;

namespace DRS.ModulesMod
{
    public static class Helpers
    {
        public static string[] SeamothSteps = { "Modules", "Seamoth" };
        public static string[] ExosuitSteps = { "Modules", "Exosuit" };
        public static string[] CyclopsSteps = { "Modules", "Cyclops" };
        public static Vector2int size = new Vector2int(1, 1);


        /// <summary>
        /// Gets a sprite from a <see cref="TechType"/>, or from the Assets folder
        /// </summary>
        /// <example>
        /// Helpers.GetSprite(TechType.Titanium);
        /// Helpers.GetSprite("Tractor");
        /// </example>
        /// <param name="FileOrTechType"><see cref="TechType"/> or <see cref="string"/>.</param>
        /// <returns><see cref="TechType"/> returns the sprite of an existing TechType. A <see cref="string"/> returns a sprite loaded from the Assets folder with the same name.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Sprite GetSprite(object FileOrTechType)
        {
            if(FileOrTechType is TechType techType) return SpriteManager.Get(techType);
            else if(FileOrTechType is string filename) return ImageUtils.LoadSpriteFromFile(IOUtilities.Combine(Assembly.GetExecutingAssembly().Location, "Assets", filename + ".png"));
            else throw new ArgumentException("Incorrect type used in 'Helpers.GetSprite();'");
        }


        /// <summary>
        /// Creates and returns a <see cref="RecipeData"/>.
        /// </summary>
        /// <example>
        /// Helpers.CreateRecipe(3
        ///     new Ingredient(TechType.Titanium, 5),
        ///     new Ingredient(TechType.GasPod, 2),
        ///     new Ingredient(TechType.Quartz, 1));
        /// </example>
        /// <param name="craftAmount"></param>
        /// <param name="ingredients"></param>
        /// <returns>A <see cref="RecipeData"/>.</returns>
        public static RecipeData CreateRecipe(int craftAmount, params Ingredient[] ingredients)
        {
            RecipeData recipe = new RecipeData();
            recipe.craftAmount = craftAmount;
            recipe.Ingredients = new List<Ingredient>(ingredients);
            return recipe;
        }


        /// <summary> 
        /// Creates and returns a <see cref="PrefabInfo"/>.
        /// </summary>
        /// <param name="id">ID for the item TechType to use</param>
        /// <param name="name">Display name for the item to use</param>
        /// <param name="description">Description for the item to use</param>
        /// <param name="sprite"><see cref="Atlas.Sprite"/> for the item to use</param>
        /// <returns>A <see cref="PrefabInfo"/>.</returns>
        public static PrefabInfo CreatePrefabInfo(string id, string name, string description, Sprite sprite)
        {
            PrefabInfo prefabInfo = PrefabInfo
                .WithTechType(id, name, description)
                .WithIcon(sprite)
                .WithSizeInInventory(size);
            return prefabInfo;
        }


        /// <summary>
        /// Creates and returns a <see cref="CustomPrefab"/>.
        /// </summary>
        /// <param name="moduleType"><see cref="int"/> to use for module type, 1 = Seamoth, 2 = Exosuit, 3 = Cyclops.</param>
        /// <param name="prefabInfo"><see cref="PrefabInfo"/> for this items TechType information & sprite.</param>
        /// <param name="unlocksWith"><see cref="TechType"/> for this item to unlock with.</param>
        /// <param name="recipe"><see cref="RecipeData"/> for this items recipe.</param>
        /// <returns>A <see cref="CustomPrefab"/>.</returns>
        public static CustomPrefab CreatePrefab(int moduleType, PrefabInfo prefabInfo, RecipeData recipe)
        {
            var prefab = new CustomPrefab(prefabInfo);
            var clone = new CloneTemplate(prefabInfo, TechType.CyclopsHullModule1);
            //prefab.SetUnlock(unlocksWith);
            switch (moduleType)
            {
                case 1: // Seamoth
                    clone.ModifyPrefab += obj =>
                    {
                        //obj.EnsureComponent<SeamothHandler>();
                    };
                    prefab.SetEquipment(EquipmentType.SeamothModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(CraftTree.Type.Workbench)
                        .WithStepsToFabricatorTab(SeamothSteps);
                    break;
                case 2: // Exosuit
                    clone.ModifyPrefab += obj =>
                    {
                        //obj.EnsureComponent<ExosuitHandler>();
                    };
                    prefab.SetEquipment(EquipmentType.ExosuitModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(CraftTree.Type.Workbench)
                        .WithStepsToFabricatorTab(ExosuitSteps);
                    break;
                case 3: // Cyclops
                    clone.ModifyPrefab += obj =>
                    {
                        //obj.EnsureComponent<CyclopsHandler>();
                    };
                    prefab.SetEquipment(EquipmentType.CyclopsModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(CraftTree.Type.Workbench)
                        .WithStepsToFabricatorTab(CyclopsSteps);
                    break;
            }
            return prefab;
        }
    }
}