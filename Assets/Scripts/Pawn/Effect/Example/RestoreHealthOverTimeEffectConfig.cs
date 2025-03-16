using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Restore Health Over Time", menuName = "Winter Universe/Pawn/Effect/New Restore Health Over Time")]
    public class RestoreHealthOverTimeEffectConfig : EffectConfig
    {
        public override Effect CreateEffect(Pawn target, Pawn source, float value, float duration)
        {
            return new RestoreHealthOverTimeEffect(this, target, source, value, duration);
        }
    }
}