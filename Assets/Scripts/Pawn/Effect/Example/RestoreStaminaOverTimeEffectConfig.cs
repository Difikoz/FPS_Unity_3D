using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Restore Stamina Over Time", menuName = "Winter Universe/Pawn/Effect/New Restore Stamina Over Time")]
    public class RestoreStaminaOverTimeEffectConfig : EffectConfig
    {
        public override Effect CreateEffect(Pawn target, Pawn source, float value, float duration)
        {
            return new RestoreStaminaOverTimeEffect(this, target, source, value, duration);
        }
    }
}