using Lean.Pool;
using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;

        private PlayerController _player;
        private WeaponItemConfig _weaponConfig;
        private AmmoItemConfig _ammoConfig;
        private int _pierceCount;
        private GameObject _model;

        public void Initialize(PlayerController player, WeaponItemConfig weapon, AmmoItemConfig ammo)
        {
            _player = player;
            _weaponConfig = weapon;
            _ammoConfig = ammo;
            _pierceCount = 0;
            _model = LeanPool.Spawn(_ammoConfig.Model, transform);
            _rb.linearVelocity = transform.forward * _weaponConfig.Force * _ammoConfig.ForceMultiplier;
            StartCoroutine(DespawnCoroutine());
        }

        private IEnumerator DespawnCoroutine()
        {
            yield return new WaitForSeconds(_weaponConfig.Range * _ammoConfig.RangeMultiplier / _weaponConfig.Force * _ammoConfig.ForceMultiplier);
            Despawn();
        }

        private void OnTriggerEnter(Collider other)
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();// change player to enemy
            if (player != null)
            {
                // apply damage with source as player
                // read damage from weapon and ammo multiplier
                // add knockback to target
                _pierceCount++;
                if (_pierceCount > _weaponConfig.PierceCount + _ammoConfig.PierceCount)
                {
                    Despawn();
                }
            }
        }

        private void Despawn()
        {
            _rb.linearVelocity = Vector3.zero;
            LeanPool.Despawn(_model);
            LeanPool.Despawn(gameObject);
        }
    }
}