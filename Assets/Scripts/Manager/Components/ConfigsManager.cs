using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class ConfigsManager : MonoBehaviour
    {
        [SerializeField] private float _gravity = -9.81f;
        [SerializeField] private List<VisualConfig> _visuals = new();
        [SerializeField] private List<VoiceConfig> _voices = new();
        [SerializeField] private List<FactionConfig> _factions = new();
        [SerializeField] private List<InventoryConfig> _inventory = new();
        [SerializeField] private List<WeaponItemConfig> _weapons = new();
        [SerializeField] private List<ArmorItemConfig> _armors = new();
        [SerializeField] private List<AmmoItemConfig> _ammo = new();
        [SerializeField] private List<ConsumableItemConfig> _consumables = new();
        [SerializeField] private List<ResourceItemConfig> _resources = new();

        private List<ItemConfig> _items = new();

        public float Gravity => _gravity;
        public List<VisualConfig> Visuals => _visuals;
        public List<VoiceConfig> Voices => _voices;
        public List<FactionConfig> Factions => _factions;
        public List<InventoryConfig> Inventory => _inventory;
        public List<ItemConfig> Items => _items;

        public void Initialize()
        {
            _items.Clear();
            foreach (WeaponItemConfig config in _weapons)
            {
                _items.Add(config);
            }
            foreach (ArmorItemConfig config in _armors)
            {
                _items.Add(config);
            }
            foreach (AmmoItemConfig config in _ammo)
            {
                _items.Add(config);
            }
            foreach (ConsumableItemConfig config in _consumables)
            {
                _items.Add(config);
            }
            foreach (ResourceItemConfig config in _resources)
            {
                _items.Add(config);
            }
        }

        public VisualConfig GetVisual(string name)
        {
            foreach (VisualConfig config in _visuals)
            {
                if (config.DisplayName == name)
                {
                    return config;
                }
            }
            return null;
        }

        public VoiceConfig GetVoice(string name)
        {
            foreach (VoiceConfig config in _voices)
            {
                if (config.DisplayName == name)
                {
                    return config;
                }
            }
            return null;
        }

        public FactionConfig GetFaction(string name)
        {
            foreach (FactionConfig config in _factions)
            {
                if (config.DisplayName == name)
                {
                    return config;
                }
            }
            return null;
        }

        public InventoryConfig GetInventory(string name)
        {
            foreach (InventoryConfig config in _inventory)
            {
                if (config.DisplayName == name)
                {
                    return config;
                }
            }
            return null;
        }

        public ItemConfig GetItem(string name)
        {
            foreach (ItemConfig config in _items)
            {
                if (config.DisplayName == name)
                {
                    return config;
                }
            }
            return null;
        }

        public WeaponItemConfig GetWeapon(string name)
        {
            foreach (WeaponItemConfig config in _weapons)
            {
                if (config.DisplayName == name)
                {
                    return config;
                }
            }
            return null;
        }

        public ArmorItemConfig GetArmor(string name)
        {
            foreach (ArmorItemConfig config in _armors)
            {
                if (config.DisplayName == name)
                {
                    return config;
                }
            }
            return null;
        }

        public AmmoItemConfig GetAmmo(string name)
        {
            foreach (AmmoItemConfig config in _ammo)
            {
                if (config.DisplayName == name)
                {
                    return config;
                }
            }
            return null;
        }

        public ConsumableItemConfig GetConsumable(string name)
        {
            foreach (ConsumableItemConfig config in _consumables)
            {
                if (config.DisplayName == name)
                {
                    return config;
                }
            }
            return null;
        }

        public ResourceItemConfig GetResource(string name)
        {
            foreach (ResourceItemConfig config in _resources)
            {
                if (config.DisplayName == name)
                {
                    return config;
                }
            }
            return null;
        }
    }
}