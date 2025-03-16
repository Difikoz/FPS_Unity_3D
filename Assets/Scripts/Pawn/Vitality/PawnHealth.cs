using System;
using UnityEngine;

namespace WinterUniverse
{
    public class PawnHealth
    {
        public Action<float, float> OnValueChanged;

        private Pawn _pawn;
        private float _current;

        public float Current => _current;
        public float Max => _pawn.StatHolder.GetStat("HP MAX").CurrentValue;
        public float Percent => Current / Max;

        public PawnHealth(Pawn pawn)
        {
            _pawn = pawn;
        }

        public void Set(float value)
        {
            _current = Mathf.Clamp(value, 0f, Max);
            OnValueChanged?.Invoke(Current, Max);
        }

        public void Reduce(float value, DamageTypeConfig type, Pawn source)
        {
            if (_pawn.StateHolder.CompareStateValue("Is Dead", true) || value <= 0f)
            {
                return;
            }
            Set(_current - value);
            if (_current <= 0f)
            {
                Die();
            }
        }

        public void Restore(float value)
        {
            if (_pawn.StateHolder.CompareStateValue("Is Dead", true) || value <= 0f)
            {
                return;
            }
            Set(_current + value);
        }

        public void Die()
        {
            if (_pawn.StateHolder.CompareStateValue("Is Dead", true))
            {
                return;
            }
            Set(0f);
            _pawn.StateHolder.SetStateValue("Is Dead", true);
        }

        public void Revive()
        {
            Set(Max);
            _pawn.StateHolder.SetStateValue("Is Dead", false);
        }
    }
}