using UnityEngine;

namespace DRS.ModulesMod.Handlers
{
    public abstract class VehicleHandler : MonoBehaviour
    {
        public Vehicle vehicle;

        public virtual void Awake()
        {
            vehicle = GetComponentInChildren<Vehicle>();

            vehicle.modules.onEquip += (slot, item) => 
            {
                OnModuleEquip(item.techType, vehicle.modules.GetCount(item.techType));
            };

            vehicle.modules.onUnequip += (slot, item) => 
            {
                OnModuleUnequip(item.techType, vehicle.modules.GetCount(item.techType));
            };

            vehicle.onToggle += (slotid, state) =>
            {
                OnModuleToggle(vehicle.GetSlotBinding(slotid), slotid, state);
            };
        }



        public virtual void OnModuleEquip(TechType techType, int count) { }
        public virtual void OnModuleUnequip(TechType techType, int count) { }
        public virtual void OnModuleToggle(TechType techType, int slotID, bool state) { }
    }
}
