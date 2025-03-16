using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Winter Universe/Pawn/Inventory/Item/New Weapon")]
    public class WeaponItemConfig : ItemConfig
    {
        [SerializeField] private bool _autoFire = true;
        [SerializeField] private float _damage = 10f;
        [SerializeField] private float _fireRate = 300f;
        [SerializeField] private float _range = 300f;
        [SerializeField] private float _knockback = 2f;
        [SerializeField] private float _force = 100f;
        [SerializeField] private float _spread = 5f;
        [SerializeField] private float _reloadTime = 1f;
        [SerializeField] private int _magSize = 30;
        [SerializeField] private int _projectilesPerShot = 1;
        [SerializeField] private int _pierceCount = 1;
        [SerializeField] private List<AmmoItemConfig> _usingAmmo = new();
        [SerializeField] private List<StatModifierCreator> _modifiers = new();
        [SerializeField] private List<EffectCreator> _effects = new();

        public bool AutoFire => _autoFire;
        public float Damage => _damage;
        public float FireRate => _fireRate;
        public float Range => _range;
        public float Knockback => _knockback;
        public float Force => _force;
        public float Spread => _spread;
        public float ReloadTime => _reloadTime;
        public int MagSize => _magSize;
        public int ProjectilesPerShot => _projectilesPerShot;
        public int PierceCount => _pierceCount;
        public List<AmmoItemConfig> UsingAmmo => _usingAmmo;
        public List<StatModifierCreator> Modifiers => _modifiers;
        public List<EffectCreator> Effects => _effects;

        private void OnValidate()
        {
            _itemType = ItemType.Weapon;
        }

        public override void Use(bool fromInventory = true)
        {
            //GameManager.StaticInstance.ControllersManager.Player.Equipment.EquipWeapon(this, fromInventory);
        }
    }
}