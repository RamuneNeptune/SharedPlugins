
using System;
using System.Collections.Generic;
using System.Reflection;
using Nautilus.Crafting;
using Nautilus.Utility;
using static CraftData;

namespace DRS.ModulesMod
{
    public static class Helpers
    {

        /// Helpers.GetSprite(TechType.Titanium);  / returns a game sprite
        /// Helpers.GetSprite("Tractor")l          / returns a custom sprite from ModulesMod\Assets\Tractor.png
        
        public static Atlas.Sprite GetSprite(object FileOrTechType)
        {
            if (FileOrTechType is TechType techType) return SpriteManager.Get(techType);
            else if (FileOrTechType is string filename) return ImageUtils.LoadSpriteFromFile(IOUtilities.Combine(Assembly.GetExecutingAssembly().Location, "Assets", filename + ".png"));
            else throw new ArgumentException("Incorrect type used in Sprite.Get()");
        }


        /// Helpers.CreateRecipe(3                       <- amount to craft
        ///     new Ingredient(TechType.Titanium, 5),    <- ingredient
        ///     new Ingredient(TechType.GasPod, 2),      <- ingredient
        ///     new Ingredient(TechType.Quartz, 1));     <- ingredient
        ///     
        ///   returns a RecipeData to use in setting an item recipe

        public static RecipeData CreateRecipe(int craftAmount, params Ingredient[] ingredients)
        {
            RecipeData recipe = new RecipeData();
            recipe.craftAmount = craftAmount;
            recipe.Ingredients = new List<Ingredient>(ingredients);
            return recipe;
        }
    }
}