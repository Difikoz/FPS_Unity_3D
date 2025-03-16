using UnityEngine;

namespace WinterUniverse
{
    public abstract class EffectConfig : BasicInfoConfig
    {
        public abstract Effect CreateEffect(Pawn target, Pawn source, float value, float duration);
    }
}