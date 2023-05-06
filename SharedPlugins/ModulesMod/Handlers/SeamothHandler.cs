using UnityEngine;

namespace DRS.ModulesMod.Handlers
{
    public class SeamothHandler : VehicleHandler
    {
        public EngineRpmSFXManager engine;
        public EnergyMixin energyMixin;
        public Animator animator;

        public SeaMoth seamoth;
        public SeaMoth lastSeamothValues;

        public void Start()
        {
            engine = gameObject.GetComponentInChildren<EngineRpmSFXManager>();
            animator = gameObject.GetComponentInChildren<Animator>();
            seamoth = vehicle as SeaMoth;
        }

        public override void OnModuleEquip(TechType techType, int count)
        {
            base.OnModuleEquip(techType, count);
        }

        public override void OnModuleToggle(TechType techType, int slotID, bool state)
        {
            base.OnModuleToggle(techType, slotID, state);
        }
    }
}