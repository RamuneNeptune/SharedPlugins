using DRS.ModulesMod.Modules.Seamoth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DRS.ModulesMod.Handlers
{
    public class SeamothHandler : MonoBehaviour
    {
        public object[] lastVehicleValues;
        public EngineRpmSFXManager engine;
        public EnergyMixin energyMixin;
        public Animator animator;
        public Vehicle vehicle;
        public SeaMoth seamoth;

        public bool hasEngineOverchargeModules;

        public void Start()
        {
            engine = gameObject.GetComponentInChildren<EngineRpmSFXManager>();
            seamoth = gameObject.GetComponentInChildren<SeaMoth>();
            animator = gameObject.GetComponentInChildren<Animator>();
            vehicle = gameObject.GetComponentInParent<Vehicle>();

            lastVehicleValues = new object[] 
            {
                vehicle.forwardForce,
                vehicle.backwardForce,
                vehicle.sidewardForce,
                seamoth.enginePowerConsumption,
                engine.engineRpmSFX,
                animator.speed,
            };
        }

        public void SetLastValues()
        {
            lastVehicleValues[0] = vehicle.forwardForce;
            lastVehicleValues[1] = vehicle.backwardForce;
            lastVehicleValues[2] = vehicle.sidewardForce;
            lastVehicleValues[3] = seamoth.enginePowerConsumption;
            lastVehicleValues[5] = animator.speed;
        }

        public void GetModules()
        {
            hasEngineOverchargeModules = seamoth.modules.GetCount(EngineOvercharge.Info.TechType) > 0;
        }

        public void Update()
        {
            GetModules();
            if (hasEngineOverchargeModules)
            {

            }
        }
    }
}