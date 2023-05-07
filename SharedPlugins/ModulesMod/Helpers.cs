
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
using Nautilus.Handlers;

namespace DRS.ModulesMod
{
    public static class Helpers
    {
        public static readonly Dictionary<VehicleType, List<TechType>> modulesRefrences = new Dictionary<VehicleType, List<TechType>>();
        public static readonly Dictionary<VehicleType, List<Module>> moduleTree = new Dictionary<VehicleType, List<Module>>();

        public static string[] GeneralSteps = { "General" };
        public static string[] SeamothSteps = { "Seamoth" };
        public static string[] ExosuitSteps = { "Exosuit" };
        public static string[] CyclopsSteps = { "Cyclops" };

        public enum VehicleType
        {
            Exosuit,
            Seamoth,
            Cyclops,
            General,
        }

        public static void AddModule(Module module)
        {
            if (!moduleTree[module.vehicleType].Contains(module))
                moduleTree[module.vehicleType].Add(module);
        }

        public static Module GetModule(VehicleType vehicleType, TechType techType)
        {
            foreach (var module in moduleTree[vehicleType])
                if (module.techType == techType) return module;
            return default;
        }

        // maybe change to PrefabInfo instead of TechType?
        public static Module CreateModule(VehicleType vehicleType, TechType techType, Action OnEquip = null, Action OnUnequip = null, Action<bool> OnToggle = null)
        {
            Module module = new Module
            {
                techType = techType,
                vehicleType = vehicleType,
                OnEquip = OnEquip,
                OnUnequip = OnUnequip,
                OnToggle = OnToggle
            };
            return module;
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
        public static CustomPrefab CreatePrefab(VehicleType moduleType, PrefabInfo prefabInfo, RecipeData recipe)
        {
            var prefab = new CustomPrefab(prefabInfo);
            var clone = new CloneTemplate(prefabInfo, TechType.CyclopsHullModule1);
            //prefab.SetUnlock(unlocksWith);
            switch (moduleType)
            {
                case VehicleType.Seamoth: // Seamoth
                    clone.ModifyPrefab += obj =>
                    {
                        //obj.EnsureComponent<NonPassiveModule>(); and set its parameters.
                    };
                    prefab.SetEquipment(EquipmentType.SeamothModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(ModuleStation.TreeType)
                        .WithStepsToFabricatorTab(SeamothSteps);
                    break;
                case VehicleType.Exosuit: // Exosuit
                    clone.ModifyPrefab += obj =>
                    {
                        //obj.EnsureComponent<NonPassiveModule>(); and set its parameters.
                    };
                    prefab.SetEquipment(EquipmentType.ExosuitModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(ModuleStation.TreeType)
                        .WithStepsToFabricatorTab(ExosuitSteps);
                    break;
                case VehicleType.Cyclops: // Cyclops
                    clone.ModifyPrefab += obj =>
                    {
                        //obj.EnsureComponent<NonPassiveModule>(); and set its parameters.
                    };
                    prefab.SetEquipment(EquipmentType.CyclopsModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(ModuleStation.TreeType)
                        .WithStepsToFabricatorTab(CyclopsSteps);
                    break;
                case VehicleType.General:
                    clone.ModifyPrefab += obj =>
                    {
                        //Check for a general handler or check what vehicle is.
                    };
                    prefab.SetEquipment(EquipmentType.VehicleModule);
                    prefab.SetRecipe(recipe)
                        .WithFabricatorType(ModuleStation.TreeType)
                        .WithStepsToFabricatorTab(GeneralSteps);
                    break;
            }
            prefab.SetGameObject(clone);
            return prefab;
        }

        /// <summary>
        /// Intended to be ONE USE ONLY and only in BepInEx.cs
        /// <para>Petition to make this kind of things internal</para>
        /// </summary>
        public static void PatchFabricator()
        {
            ModuleStation.Patch();
            CraftTreeHandler.AddTabNode(ModuleStation.TreeType, "General", "General", GetSprite(TechType.Constructor), "Modules");
            CraftTreeHandler.AddTabNode(ModuleStation.TreeType, "Seamoth", "Seamoth", GetSprite(TechType.Seamoth), "Modules");
            CraftTreeHandler.AddTabNode(ModuleStation.TreeType, "Exosuit", "Prawn suit", GetSprite(TechType.Exosuit), "Modules");
            CraftTreeHandler.AddTabNode(ModuleStation.TreeType, "Cyclops", "Cyclops", GetSprite(TechType.Cyclops), "Modules");
        }

        /// <summary>
        /// Intended to be ONE USE ONLY and only in BepInEx.cs
        /// <para>Petition to make this kind of things internal</para>
        /// </summary>
        public static void PatchLanguageLines()
        {
            LanguageHandler.SetLanguageLine("11Menu_General", "General");
            LanguageHandler.SetLanguageLine("11Menu_Seamoth", "Seamoth");
            LanguageHandler.SetLanguageLine("11Menu_Exosuit", "Exosuit");
            LanguageHandler.SetLanguageLine("11Menu_Cyclops", "Cyclops");
        }

        /// <summary>
        /// Intended to be ONE USE ONLY and only in BepInEx.cs
        /// <para>Petition to make this kind of things internal</para>
        /// </summary>
        public static void PatchModules()
        {
            Modules.All.EngineOvercharge.Patch();
            Modules.All.TorpedoAccelerator.Patch();
            Modules.All.TorpedoDoubleshot.Patch();
            Modules.Cyclops.SonarMK1.Patch();
            Modules.Cyclops.SonarMK2.Patch();
            Modules.Cyclops.SonarRange.Patch();
            Modules.Exosuit.JumpJet.Patch();
            Modules.Seamoth.Example.Patch();
        }
    }
}