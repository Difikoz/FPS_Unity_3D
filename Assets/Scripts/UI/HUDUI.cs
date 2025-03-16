using UnityEngine;

namespace WinterUniverse
{
    public class HUDUI : MonoBehaviour
    {
        private PlayerVitalityUI _playerVitality;
        private EffectsBarUI _effectsBar;

        public void Initialize()
        {
            _playerVitality = GetComponentInChildren<PlayerVitalityUI>();
            _effectsBar = GetComponentInChildren<EffectsBarUI>();
            _playerVitality.Initialize();
            _effectsBar.Initialize();
        }

        public void ResetComponent()
        {
            _playerVitality.ResetComponent();
            _effectsBar.ResetComponent();
        }
    }
}