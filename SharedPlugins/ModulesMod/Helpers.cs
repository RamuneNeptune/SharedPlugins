
using System;
using System.Collections.Generic;
using System.Reflection;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Utility;
using DRS.ModulesMod.Handlers;
using static CraftData;
using Sprite = Atlas.Sprite;
using DRS.ModulesMod.Modules.Seamoth;
using UnityEngine;
using System.IO;

namespace DRS.ModulesMod
{
    public static class Helpers
    {
        public static readonly Dictionary<ModuleType, List<TechType>> modulesRefrences = new Dictionary<ModuleType, List<TechType>>();

        public static string[] GeneralSteps = { "General" };
        public static string[] SeamothSteps = { "Seamoth" };
        public static string[] ExosuitSteps = { "Exosuit" };
        public static string[] CyclopsSteps = { "Cyclops" };

        public enum ModuleType
        {
            Exosuit,
            Seamoth,
            Cyclops,
            General,
        }


        public static void SetModuleType(ModuleType moduleType, TechType techType) 
        {
            if(!modulesRefrences[moduleType].Contains(techType))
                modulesRefrences[moduleType].Add(techType);
        }


        public static bool HasModule(Vehicle vehicle, TechType module)
        {
            if (vehicle.modules.GetCount(module) > 0) return true;
            return false;
        }


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
            else if(FileOrTechType is string filename) return ImageUtils.LoadSpriteFromFile(IOUtilities.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", filename + ".png"));
            else throw new ArgumentException("Incorrect type used in 'Helpers.GetSprite();'");
        }

        public static Texture2D GetTexutre(string filename)
        {
            return ImageUtils.LoadTextureFromFile(IOUtilities.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", filename + ".png"));
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
                .WithIcon(sprite);
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
        public static CustomPrefab CreatePrefab(ModuleType moduleType, PrefabInfo prefabInfo, RecipeData recipe)
        {
            var prefab = new CustomPrefab(prefabInfo);
            var clone = new CloneTemplate(prefabInfo, TechType.CyclopsHullModule1);
            //prefab.SetUnlock(unlocksWith);
            switch (moduleType)
            {
                case ModuleType.Seamoth: // Seamoth
                    clone.ModifyPrefab += obj =>
                    {
                        //obj.EnsureComponent<NonPassiveModule>(); and set its parameters.
                    };
                    prefab.SetEquipment(EquipmentType.SeamothModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(Fabricator.TreeType)
                        .WithStepsToFabricatorTab(SeamothSteps);
                    break;
                case ModuleType.Exosuit: // Exosuit
                    clone.ModifyPrefab += obj =>
                    {
                        //obj.EnsureComponent<NonPassiveModule>(); and set its parameters.
                    };
                    prefab.SetEquipment(EquipmentType.ExosuitModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(Fabricator.TreeType)
                        .WithStepsToFabricatorTab(ExosuitSteps);
                    break;
                case ModuleType.Cyclops: // Cyclops
                    clone.ModifyPrefab += obj =>
                    {
                        //obj.EnsureComponent<NonPassiveModule>(); and set its parameters.
                    };
                    prefab.SetEquipment(EquipmentType.CyclopsModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(Fabricator.TreeType)
                        .WithStepsToFabricatorTab(CyclopsSteps);
                    break;
                case ModuleType.General:
                    clone.ModifyPrefab += obj =>
                    {
                        //Check for a general handler or check what vehicle is.
                    };
                    prefab.SetEquipment(EquipmentType.VehicleModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(Fabricator.TreeType)
                        .WithStepsToFabricatorTab(GeneralSteps);
                    break;
            }
            prefab.SetGameObject(clone);
            return prefab;
        }

        public static bool ModuleExist(TechType techType, Vehicle vehicle)
        {
            if (vehicle.modules.GetCount(techType) > 0)
            {
                return true;
            }
            return false;
        }
    }
}