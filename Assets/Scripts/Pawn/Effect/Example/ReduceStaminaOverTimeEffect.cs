using UnityEngine;

namespace WinterUniverse
{
    public class ReduceStaminaOverTimeEffect : Effect
    {
        public ReduceStaminaOverTimeEffect(EffectConfig config, Pawn owner, Pawn source, float value, float duration) : base(config, owner, source, value, duration)
        {
        }

        public override void OnApply()
        {
            _owner.Stamina.Reduce(_value);
        }

        protected override void ApplyOnTick(float deltaTime)
        {
            _owner.Stamina.Reduce(_value * deltaTime);
        }
    }
}