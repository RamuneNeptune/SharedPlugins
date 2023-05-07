using System;

namespace DRS.ModulesMod
{
    public struct Module
    {
        public TechType techType;
        public Helpers.VehicleType vehicleType;

        public Action OnEquip; // Ideally Action<VehicleHandler>
        public Action OnUnequip; // Ideally Action<VehicleHandler>
        public Action<bool> OnToggle; // Ideally Action<VehicleHandler, bool>

        /// <summary>
        /// Creates a module with an (optional):
        /// <para>OnEquip event: An action that will be called each time this module is equiped on the vehicle.</para>
        /// <para>OnUnequip event: An action that will be called each time this module is unequiped from the vehicle. (In vehicle slots)</para>
        /// <para>OnToggle event: An action that will be called each time this module is toggled. (In vehicle slots)</para>
        /// </summary>
        /// <param name="techType">The TechType of the module.</param>
        /// <param name="vehicleType">The vehicle the module belongs on.</param>
        /// <param name="onEquip">The Action that will be executed each time this module is equiped on the vehicle.</param>
        /// <param name="onUnequip">The Action that will be executed each time this module is unequiped from the vehicle.</param>
        /// <param name="onToggle">The action that will be execited each time the module is toggled.</param>
        public Module(Helpers.VehicleType vehicleType, TechType techType, Action onEquip = null, Action onUnequip = null, Action<bool> onToggle = null)
        {
            this.vehicleType = vehicleType;
            this.techType = techType;

            OnEquip = onEquip;
            OnUnequip = onUnequip;
            OnToggle = onToggle;
        }
    }
}
