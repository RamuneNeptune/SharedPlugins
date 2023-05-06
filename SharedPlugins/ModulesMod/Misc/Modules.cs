using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.ModulesMod.Misc
{
    public class Modules
    {
        public Vehicle vehicle;

        public event OnEquip ModuleEquipped;
        public event OnUnequip ModuleUnequipped;

        public Modules(Vehicle vehicle)
        {
            this.vehicle = vehicle;
            vehicle.modules.onEquip += OnModuleEquipped;
            vehicle.modules.onUnequip += OnModuleUnequipped;
        }

        private int GetCount(TechType techType)
        {
            return vehicle.modules.GetCount(techType);
        }

        private void OnModuleEquipped(string slot, InventoryItem item)
        {
            ModuleEquipped?.Invoke(item.techType, GetCount(item.techType));
        }

        private void OnModuleUnequipped(string slot, InventoryItem item)
        {
            ModuleUnequipped?.Invoke(item.techType, GetCount(item.techType));
        }
    }

    public delegate void OnEquip(TechType techType, int count);
    public delegate void OnUnequip(TechType techType, int count);
}
