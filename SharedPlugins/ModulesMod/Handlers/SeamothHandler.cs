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

        public Misc.Modules modules;

        public void Start()
        {
            engine = gameObject.GetComponentInChildren<EngineRpmSFXManager>();
            seamoth = gameObject.GetComponentInChildren<SeaMoth>();
            animator = gameObject.GetComponentInChildren<Animator>();
            vehicle = gameObject.GetComponentInParent<Vehicle>();

            modules = new Misc.Modules(seamoth);
            modules.ModuleEquipped += OnModuleEquipped;
            modules.ModuleUnequipped += OnModuleUnequipped;

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

        public void OnModuleEquipped(TechType techType, int count)
        {

        }

        public void OnModuleUnequipped(TechType techType, int count)
        {

        }

        public void SetLastValues()
        {
            lastVehicleValues[0] = vehicle.forwardForce;
            lastVehicleValues[1] = vehicle.backwardForce;
            lastVehicleValues[2] = vehicle.sidewardForce;
            lastVehicleValues[3] = seamoth.enginePowerConsumption;
            lastVehicleValues[5] = animator.speed;
        }
    }
}