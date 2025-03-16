using System;
using UnityEngine;

namespace WinterUniverse
{
    public class PawnStamina
    {
        public Action<float, float> OnValueChanged;

        private Pawn _pawn;
        private float _current;

        public float Current => _current;
        public float Max => _pawn.StatHolder.GetStat("SP MAX").CurrentValue;
        public float Percent => Current / Max;

        public PawnStamina(Pawn pawn)
        {
            _pawn = pawn;
        }

        public void Set(float value)
        {
            _current = Mathf.Clamp(value, 0f, Max);
            OnValueChanged?.Invoke(Current, Max);
        }

        public bool CanReduce(float value)
        {
            return _current - value >= 0f && value >= 0f;
        }

        public bool Reduce(float value)
        {
            if (CanReduce(value))
            {
                Set(_current - value);
                return true;
            }
            return false;
        }

        public void Restore(float value)
        {
            if (value <= 0f)
            {
                return;
            }
            Set(_current + value);
        }
    }
}