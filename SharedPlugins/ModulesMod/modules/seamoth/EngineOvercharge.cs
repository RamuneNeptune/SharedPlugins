using Nautilus.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public class EngineOverchargeMono : MonoBehaviour
    {
        public float cooldown;
        public float overchargeSpeed;
        public float overchargeEnergyConsumption;

        // [1] = forward force.
        // [2] = backward force.
        // [3] = sideward force.
        // [4] = power rating.
        // Do not change order, or else you will break space and time itself.
        public object[] lastVehicleValues;

        public void SetUpLastValuesFrom(Vehicle vehicle)
        {
            lastVehicleValues.Append(vehicle.forwardForce);
            lastVehicleValues.Append(vehicle.backwardForce);
            lastVehicleValues.Append(vehicle.sidewardForce);
            lastVehicleValues.Append(vehicle.enginePowerRating);
        }
    }
}