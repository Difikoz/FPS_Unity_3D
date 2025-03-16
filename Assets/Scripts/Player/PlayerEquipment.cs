using System;
using UnityEngine;

namespace WinterUniverse
{
    public class PlayerEquipment
    {
        public Action OnEquipmentChanged;

        private PlayerController _player;
        private WeaponSlot _weaponSlot;
        private ArmorSlot _armorSlot;

        public WeaponSlot WeaponSlot => _weaponSlot;
        public ArmorSlot ArmorSlot => _armorSlot;

        public PlayerEquipment(PlayerController player)
        {
            _player = player;
            _weaponSlot = _player.GetComponentInChildren<WeaponSlot>();
            _armorSlot = _player.GetComponentInChildren<ArmorSlot>();
        }

        public void EquipWeapon(WeaponItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_player.Pawn.StateHolder.CompareStateValue("Is Dead", true) || _weaponSlot.IsPerfomingAction)
            {
                return;
            }
            if (removeNewFromInventory)
            {
                _player.Pawn.Inventory.RemoveItem(config);
            }
            if (addOldToInventory && _weaponSlot.WeaponConfig != null)
            {
                _player.Pawn.Inventory.AddItem(_weaponSlot.WeaponConfig);
            }
            _weaponSlot.ChangeWeaponConfig(config);
            //if (config.PlayAnimationOnUse)
            //{
            //    _pawn.Animator.PlayAction(config.AnimationOnUse);
            //}
            OnEquipmentChanged?.Invoke();
            EquipAmmo(config.UsingAmmo[0]);
        }

        public void UnequipWeapon(bool addOldToInventory = true)
        {
            if (_weaponSlot.IsPerfomingAction)
            {
                return;
            }
            if (addOldToInventory && _weaponSlot.WeaponConfig != null)
            {
                _player.Pawn.Inventory.AddItem(_weaponSlot.WeaponConfig);
            }
            _weaponSlot.ChangeWeaponConfig(null);
            OnEquipmentChanged?.Invoke();
            UnequipAmmo();
        }

        public void EquipArmor(ArmorItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_player.Pawn.StateHolder.CompareStateValue("Is Dead", true))
            {
                return;
            }
            if (removeNewFromInventory)
            {
                _player.Pawn.Inventory.RemoveItem(config);
            }
            if (addOldToInventory && _armorSlot.Config != null)
            {
                _player.Pawn.Inventory.AddItem(_armorSlot.Config);
            }
            _armorSlot.ChangeConfig(config);
            //if (config.PlayAnimationOnUse)
            //{
            //    _pawn.Animator.PlayAction(config.AnimationOnUse);
            //}
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipArmor(bool addOldToInventory = true)
        {
            if (addOldToInventory && _armorSlot.Config != null)
            {
                _player.Pawn.Inventory.AddItem(_armorSlot.Config);
            }
            _armorSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipAmmo(AmmoItemConfig config)
        {
            if (_player.Pawn.StateHolder.CompareStateValue("Is Dead", true) || _weaponSlot.IsPerfomingAction || _weaponSlot.WeaponConfig == null || !_weaponSlot.WeaponConfig.UsingAmmo.Contains(config))
            {
                return;
            }
            _weaponSlot.DischargeWeapon();
            _weaponSlot.ChangeAmmoConfig(config);
            _weaponSlot.ReloadWeapon();
            //if (config.PlayAnimationOnUse)
            //{
            //    _pawn.Animator.PlayAction(config.AnimationOnUse);
            //}
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipAmmo()
        {
            if (_weaponSlot.IsPerfomingAction)
            {
                return;
            }
            _weaponSlot.DischargeWeapon();
            _weaponSlot.ChangeAmmoConfig(null);
            OnEquipmentChanged?.Invoke();
        }
    }
}