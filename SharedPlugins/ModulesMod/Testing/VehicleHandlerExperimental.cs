using System;
using System.Collections.Generic;

namespace DRS.ModulesMod.Testing
{
    public class VehicleHandlerExperimental
    {
        // Example 1: With Module
        public void Example1(TechType techType)
        {
            ModuleHandler.moduleTree[Helpers.VehicleType.Seamoth][techType].OnEquip.Invoke();
        }

        // Example 2: With MinimalModule
        public void Example2(TechType techType)
        {
            ModuleHandler.minimalModuleTree[Helpers.VehicleType.Seamoth][techType].OnEquip.Invoke();
        }

        // Example 3: With List<Module>
        public void Example3(TechType techType)
        {
            var index = ModuleHandler.GetIndex(Helpers.VehicleType.Seamoth, techType);
            ModuleHandler.moduleListTree[Helpers.VehicleType.Seamoth][index].OnEquip.Invoke();
        }
    }

    public class ModuleHandler
    {
        public static readonly Dictionary<Helpers.VehicleType, Dictionary<TechType, Module>> moduleTree = new Dictionary<Helpers.VehicleType, Dictionary<TechType, Module>>();
        
        // For testing, see wich one do you like, i prefer this one below.
        public static readonly Dictionary<Helpers.VehicleType, Dictionary<TechType, MinimalModule>> minimalModuleTree = new Dictionary<Helpers.VehicleType, Dictionary<TechType, MinimalModule>>();

        // And this one
        public static readonly Dictionary<Helpers.VehicleType, List<Module>> moduleListTree = new Dictionary<Helpers.VehicleType, List<Module>>();

        public static int GetIndex(Helpers.VehicleType vehicleType, TechType techType)
        {
            int result = 0;
            int count = 0;
            moduleListTree[vehicleType].ForEach(module =>
            {
                if (module.techType == techType)
                    result = count;
                count++; 
            });
            return result;
        }
    }

    public struct Module
    {
        public TechType techType;
        public Helpers.VehicleType vehicleType;

        public Action OnEquip; // Ideally Action<VehicleHandler>
        public Action OnUnequip; // Ideally Action<VehicleHandler>
        public Action<bool> OnToggle; // Ideally Action<VehicleHandler, bool>

        /// <summary>
        /// Creates a module with no events.
        /// </summary>
        /// <param name="techType">The TechType of the module.</param>
        /// <param name="vehicleType">The vehicle the module belongs on.</param>
        public Module(TechType techType, Helpers.VehicleType vehicleType)
        {
            this.techType = techType;
            this.vehicleType = vehicleType;

            OnEquip = new Action( () => { } );
            OnUnequip = new Action( () => { } );
            OnToggle = new Action<bool>( @bool => { } );
        }

        /// <summary>
        /// Creates a module with an:
        /// <para>OnEquip event: An action that will be called each time this module is equiped on the vehicle.</para>
        /// </summary>
        /// <param name="techType">The TechType of the module.</param>
        /// <param name="vehicleType">The vehicle the module belongs on.</param>
        /// <param name="onEquip">The Action that will be executed each time this module is equiped on the vehicle.</param>
        public Module(TechType techType, Helpers.VehicleType vehicleType, Action onEquip)
        {
            this.techType = techType;
            this.vehicleType = vehicleType;

            OnEquip = onEquip;
            OnUnequip = new Action(() => { });
            OnToggle = new Action<bool>(@bool => { });
        }

        /// <summary>
        /// Creates a module with an:
        /// <para>OnToggle event: An action that will be called each time this module is toggled. (In vehicle slots)</para>
        /// </summary>
        /// <param name="techType">The TechType of the module.</param>
        /// <param name="vehicleType">The vehicle the module belongs on.</param>
        /// <param name="onToggle">The action that will be execited each time the module is toggled.</param>
        public Module(TechType techType, Helpers.VehicleType vehicleType, Action<bool> onToggle)
        {
            this.techType = techType;
            this.vehicleType = vehicleType;

            OnEquip = new Action(() => { });
            OnUnequip = new Action(() => { });
            OnToggle = onToggle;
        }
        /// <summary>
        /// Creates a module with an:
        /// <para>OnEquip event: An action that will be called each time this module is equiped on the vehicle.</para>
        /// <para>OnToggle event: An action that will be called each time this module is toggled. (In vehicle slots)</para>
        /// </summary>
        /// <param name="techType">The TechType of the module.</param>
        /// <param name="vehicleType">The vehicle the module belongs on.</param>
        /// <param name="onEquip">The Action that will be executed each time this module is equiped on the vehicle.</param>
        /// <param name="onToggle">The action that will be execited each time the module is toggled.</param>
        public Module(TechType techType, Helpers.VehicleType vehicleType, Action onEquip, Action<bool> onToggle)
        {
            this.techType = techType;
            this.vehicleType = vehicleType;

            OnEquip = onEquip;
            OnUnequip = new Action(() => { });
            OnToggle = onToggle;
        }

        /// <summary>
        /// Creates a module with an:
        /// <para>OnEquip event: An action that will be called each time this module is equiped on the vehicle.</para>
        /// <para>OnUnequip event: An action that will be called each time this module is unequiped from the vehicle. (In vehicle slots)</para>
        /// </summary>
        /// <param name="techType">The TechType of the module.</param>
        /// <param name="vehicleType">The vehicle the module belongs on.</param>
        /// <param name="onEquip">The Action that will be executed each time this module is equiped on the vehicle.</param>
        /// <param name="onUnequip">The Action that will be executed each time this module is unequiped from the vehicle.</param>
        public Module(TechType techType, Helpers.VehicleType vehicleType, Action onEquip, Action onUnequip)
        {
            this.techType = techType;
            this.vehicleType = vehicleType;

            OnEquip = onEquip;
            OnUnequip = onUnequip;
            OnToggle = new Action<bool>(@bool => { });
        }

        /// <summary>
        /// Creates a module with an:
        /// <para>OnEquip event: An action that will be called each time this module is equiped on the vehicle.</para>
        /// <para>OnUnequip event: An action that will be called each time this module is unequiped from the vehicle. (In vehicle slots)</para>
        /// <para>OnToggle event: An action that will be called each time this module is toggled. (In vehicle slots)</para>
        /// </summary>
        /// <param name="techType">The TechType of the module.</param>
        /// <param name="vehicleType">The vehicle the module belongs on.</param>
        /// <param name="onEquip">The Action that will be executed each time this module is equiped on the vehicle.</param>
        /// <param name="onUnequip">The Action that will be executed each time this module is unequiped from the vehicle.</param>
        /// <param name="onToggle">The action that will be execited each time the module is toggled.</param>
        public Module(TechType techType, Helpers.VehicleType vehicleType, Action onEquip, Action onUnequip, Action<bool> onToggle)
        {
            this.techType = techType;
            this.vehicleType = vehicleType;

            OnEquip = onEquip;
            OnUnequip = onUnequip;
            OnToggle = onToggle;
        }
    }

    public struct MinimalModule
    {
        public Action OnEquip; // Ideally Action<VehicleHandler>
        public Action OnUnequip; // Ideally Action<VehicleHandler>
        public Action<bool> OnToggle; // Ideally Action<VehicleHandler, bool>

        /// <summary>
        /// Creates a module with an:
        /// <para>OnEquip event: An action that will be called each time this module is equiped on the vehicle.</para>
        /// </summary>
        /// <param name="onEquip">The Action that will be executed each time this module is equiped on the vehicle.</param>
        public MinimalModule(Action onEquip)
        {
            OnEquip = onEquip;
            OnUnequip = new Action(() => { });
            OnToggle = new Action<bool>(@bool => { });
        }

        /// <summary>
        /// Creates a module with an:
        /// <para>OnToggle event: An action that will be called each time this module is toggled. (In vehicle slots)</para>
        /// </summary>
        /// <param name="onToggle">The action that will be execited each time the module is toggled.</param>
        public MinimalModule(Action<bool> onToggle)
        {
            OnEquip = new Action(() => { });
            OnUnequip = new Action(() => { });
            OnToggle = onToggle;
        }
        /// <summary>
        /// Creates a module with an:
        /// <para>OnEquip event: An action that will be called each time this module is equiped on the vehicle.</para>
        /// <para>OnToggle event: An action that will be called each time this module is toggled. (In vehicle slots)</para>
        /// </summary>
        /// <param name="onEquip">The Action that will be executed each time this module is equiped on the vehicle.</param>
        /// <param name="onToggle">The action that will be execited each time the module is toggled.</param>
        public MinimalModule(Action onEquip, Action<bool> onToggle)
        {
            OnEquip = onEquip;
            OnUnequip = new Action(() => { });
            OnToggle = onToggle;
        }

        /// <summary>
        /// Creates a module with an:
        /// <para>OnEquip event: An action that will be called each time this module is equiped on the vehicle.</para>
        /// <para>OnUnequip event: An action that will be called each time this module is unequiped from the vehicle. (In vehicle slots)</para>
        /// </summary>
        /// <param name="onEquip">The Action that will be executed each time this module is equiped on the vehicle.</param>
        /// <param name="onUnequip">The Action that will be executed each time this module is unequiped from the vehicle.</param>
        public MinimalModule(Action onEquip, Action onUnequip)
        {
            OnEquip = onEquip;
            OnUnequip = onUnequip;
            OnToggle = new Action<bool>(@bool => { });
        }

        /// <summary>
        /// Creates a module with an:
        /// <para>OnEquip event: An action that will be called each time this module is equiped on the vehicle.</para>
        /// <para>OnUnequip event: An action that will be called each time this module is unequiped from the vehicle. (In vehicle slots)</para>
        /// <para>OnToggle event: An action that will be called each time this module is toggled. (In vehicle slots)</para>
        /// </summary>
        /// <param name="onEquip">The Action that will be executed each time this module is equiped on the vehicle.</param>
        /// <param name="onUnequip">The Action that will be executed each time this module is unequiped from the vehicle.</param>
        /// <param name="onToggle">The action that will be execited each time the module is toggled.</param>
        public MinimalModule(Action onEquip, Action onUnequip, Action<bool> onToggle)
        {
            OnEquip = onEquip;
            OnUnequip = onUnequip;
            OnToggle = onToggle;
        }
    }
}
