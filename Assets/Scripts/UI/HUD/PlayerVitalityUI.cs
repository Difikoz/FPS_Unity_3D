using UnityEngine;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class PlayerVitalityUI : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;
        [SerializeField] private Image _staminaImage;

        public void Initialize()
        {
            GameManager.StaticInstance.ControllersManager.Player.Pawn.Health.OnValueChanged += UpdateHealthOverlay;
            GameManager.StaticInstance.ControllersManager.Player.Pawn.Stamina.OnValueChanged += UpdateStaminaOverlay;
            //GameManager.StaticInstance.ControllersManager.Player.Status.RecalculateVitality();
        }

        public void ResetComponent()
        {
            GameManager.StaticInstance.ControllersManager.Player.Pawn.Health.OnValueChanged -= UpdateHealthOverlay;
            GameManager.StaticInstance.ControllersManager.Player.Pawn.Stamina.OnValueChanged -= UpdateStaminaOverlay;
        }

        private void UpdateHealthOverlay(float current, float max)
        {
            _healthImage.color = new(1f, 1f, 1f, 1f - (current / max));
        }

        private void UpdateStaminaOverlay(float current, float max)
        {
            _staminaImage.color = new(1f, 1f, 1f, 1f - (current / max));
        }
    }
}