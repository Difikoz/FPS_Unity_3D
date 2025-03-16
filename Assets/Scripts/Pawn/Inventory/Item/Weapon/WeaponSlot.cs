using Lean.Pool;
using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class WeaponSlot : MonoBehaviour
    {
        private PlayerController _player;
        private WeaponItemConfig _weaponConfig;
        private AmmoItemConfig _ammoConfig;
        private GameObject _model;
        private ShootPoint _shootPoint;
        private bool _isFiring;
        private int _ammoInMag;
        private Coroutine _fireCoroutine;
        private Coroutine _reloadCoroutine;

        public WeaponItemConfig WeaponConfig => _weaponConfig;
        public AmmoItemConfig AmmoConfig => _ammoConfig;
        public int AmmoInMag => _ammoInMag;
        public bool IsPerfomingAction => _fireCoroutine != null || _reloadCoroutine != null;

        public void Initialize(PlayerController player)
        {
            _player = player;
        }

        public void ChangeWeaponConfig(WeaponItemConfig config)
        {
            if (_weaponConfig != null)
            {

            }
            if (_model != null)
            {
                LeanPool.Despawn(_model);
                _model = null;
                _shootPoint = null;
            }
            _weaponConfig = config;
            if (_weaponConfig != null)
            {
                _model = LeanPool.Spawn(_weaponConfig.Model, transform);
                _shootPoint = GetComponentInChildren<ShootPoint>();
            }
        }

        public void ChangeAmmoConfig(AmmoItemConfig config)
        {
            _ammoConfig = config;
        }

        public void ChangeAmmoType()
        {
            if (_weaponConfig == null || IsPerfomingAction || _weaponConfig.UsingAmmo.Count == 1)
            {
                return;
            }
            if (_ammoConfig == null)
            {
                if (_player.Pawn.Inventory.GetAmmo(_weaponConfig, out AmmoItemConfig ammo))
                {
                    _player.Equipment.EquipAmmo(ammo);
                }
            }
            else
            {
                int currentAmmoIndex = _weaponConfig.UsingAmmo.IndexOf(_ammoConfig);
                if (currentAmmoIndex < _weaponConfig.UsingAmmo.Count - 1)
                {
                    for (int i = currentAmmoIndex + 1; i < _weaponConfig.UsingAmmo.Count; i++)
                    {
                        if (_player.Pawn.Inventory.AmountOfItem(_weaponConfig.UsingAmmo[i]) > 0)
                        {
                            _player.Equipment.EquipAmmo(_weaponConfig.UsingAmmo[i]);
                            break;
                        }
                    }
                }
                if (currentAmmoIndex > 1)
                {
                    for (int i = 0; i < currentAmmoIndex - 1; i++)
                    {
                        if (_player.Pawn.Inventory.AmountOfItem(_weaponConfig.UsingAmmo[i]) > 0)
                        {
                            _player.Equipment.EquipAmmo(_weaponConfig.UsingAmmo[i]);
                            break;
                        }
                    }
                }
            }
        }

        public void ReloadWeapon()
        {
            if (_weaponConfig == null || IsPerfomingAction || _ammoInMag == _weaponConfig.MagSize)
            {
                return;
            }
            if (_ammoConfig == null || _player.Pawn.Inventory.AmountOfItem(_ammoConfig) == 0)
            {
                if (_player.Pawn.Inventory.GetAmmo(_weaponConfig, out AmmoItemConfig ammo))
                {
                    _player.Equipment.EquipAmmo(ammo);
                }
            }
            else
            {
                _reloadCoroutine = StartCoroutine(ReloadCoroutine());
            }
        }

        public void DischargeWeapon()
        {
            if (_ammoConfig != null && _ammoInMag > 0)
            {
                _player.Pawn.Inventory.AddItem(_ammoConfig, _ammoInMag);
            }
            _ammoConfig = null;
            _ammoInMag = 0;
        }

        public void StartFire()
        {
            if (_weaponConfig != null && _ammoConfig != null && !IsPerfomingAction && _ammoInMag > 0)
            {
                _isFiring = true;
                _ammoInMag--;
                _fireCoroutine = StartCoroutine(FireCoroutine());
            }
            else
            {
                StopFire();
            }
        }

        public void StopFire()
        {
            _isFiring = false;
        }

        private IEnumerator FireCoroutine()
        {
            Vector3 spread;
            for (int i = 0; i < _weaponConfig.ProjectilesPerShot; i++)
            {
                spread = new(Random.Range(-_weaponConfig.Spread, _weaponConfig.Spread), Random.Range(-_weaponConfig.Spread, _weaponConfig.Spread), Random.Range(-_weaponConfig.Spread, _weaponConfig.Spread));
                spread += _shootPoint.transform.eulerAngles;
                //GameManager.StaticInstance.PrefabsManager.GetProjectile(_shootPoint.transform.position, Quaternion.Euler(spread)).Initialize(_player, _weaponConfig, _ammoConfig);
            }
            yield return new WaitForSeconds(60f / _weaponConfig.FireRate);
            _fireCoroutine = null;
            if (_weaponConfig != null)
            {
                if (_ammoInMag == 0)
                {
                    ReloadWeapon();
                }
                else if (_isFiring && _weaponConfig.AutoFire)
                {
                    StartFire();
                }
            }
        }

        private IEnumerator ReloadCoroutine()
        {
            yield return new WaitForSeconds(_weaponConfig.ReloadTime);
            if (_weaponConfig != null && _ammoConfig != null)
            {
                int ammoDif = _weaponConfig.MagSize - _ammoInMag;
                int amountInInventory = _player.Pawn.Inventory.AmountOfItem(_ammoConfig);
                if (ammoDif > amountInInventory)
                {
                    ammoDif = amountInInventory;
                }
                if (_player.Pawn.Inventory.RemoveItem(_ammoConfig, ammoDif))
                {
                    _ammoInMag += ammoDif;
                }
            }
            _reloadCoroutine = null;
        }
    }
}