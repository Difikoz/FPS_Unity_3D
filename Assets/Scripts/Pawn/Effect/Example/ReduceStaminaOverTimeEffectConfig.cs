using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Reduce Stamina Over Time", menuName = "Winter Universe/Pawn/Effect/New Reduce Stamina Over Time")]
    public class ReduceStaminaOverTimeEffectConfig : EffectConfig
    {
        public override Effect CreateEffect(Pawn target, Pawn source, float value, float duration)
        {
            return new ReduceStaminaOverTimeEffect(this, target, source, value, duration);
        }
    }
}