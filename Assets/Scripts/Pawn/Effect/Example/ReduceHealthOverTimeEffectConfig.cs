using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Reduce Health Over Time", menuName = "Winter Universe/Pawn/Effect/New Reduce Health Over Time")]
    public class ReduceHealthOverTimeEffectConfig : EffectConfig
    {
        [SerializeField] private DamageTypeConfig _damageType;

        public override Effect CreateEffect(Pawn target, Pawn source, float value, float duration)
        {
            return new ReduceHealthOverTimeEffect(this, target, source, value, duration, _damageType);
        }
    }
}