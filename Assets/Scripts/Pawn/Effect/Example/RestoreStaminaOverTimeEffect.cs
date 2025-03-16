namespace WinterUniverse
{
    public class RestoreStaminaOverTimeEffect : Effect
    {
        public RestoreStaminaOverTimeEffect(EffectConfig config, Pawn owner, Pawn source, float value, float duration) : base(config, owner, source, value, duration)
        {
        }

        public override void OnApply()
        {
            _owner.Stamina.Restore(_value);
        }

        protected override void ApplyOnTick(float deltaTime)
        {
            _owner.Stamina.Restore(_value * deltaTime);
        }
    }
}