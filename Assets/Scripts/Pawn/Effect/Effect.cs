namespace WinterUniverse
{
    public abstract class Effect
    {
        protected EffectConfig _config;
        protected Pawn _owner;
        protected Pawn _source;
        protected float _value;
        protected float _duration;

        public EffectConfig Config => _config;
        public Pawn Pawn => _owner;
        public Pawn Source => _source;
        public float Value => _value;
        public float Duration => _duration;

        public Effect(EffectConfig config, Pawn owner, Pawn source, float value, float duration)
        {
            _config = config;
            _owner = owner;
            _source = source;
            _value = value;
            _duration = duration;
        }

        public virtual void OnApply()
        {

        }

        public void OnTick(float deltaTime)
        {
            if (_duration > 0f)
            {
                ApplyOnTick(deltaTime);
                _duration -= deltaTime;
            }
            else
            {
                _owner.EffectHolder.RemoveEffect(this);
            }
        }

        protected virtual void ApplyOnTick(float deltaTime)
        {

        }

        public virtual void OnRemove()
        {

        }
    }
}