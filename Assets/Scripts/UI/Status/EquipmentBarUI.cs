using TMPro;
using UnityEngine;

namespace WinterUniverse
{
    public class EquipmentBarUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _infoBarNameText;
        [SerializeField] private TMP_Text _infoBarDescriptionText;

        private WeaponSlotUI _weaponSlot;
        private ArmorSlotUI _armorSlot;
        private AmmoSlotUI _ammoSlot;

        public void Initialize()
        {
            _weaponSlot = GetComponentInChildren<WeaponSlotUI>();
            _armorSlot = GetComponentInChildren<ArmorSlotUI>();
            _ammoSlot = GetComponentInChildren<AmmoSlotUI>();
            GameManager.StaticInstance.ControllersManager.Player.Equipment.OnEquipmentChanged += OnEquipmentChanged;
            OnEquipmentChanged();
        }

        public void ResetComponent()
        {
            GameManager.StaticInstance.ControllersManager.Player.Equipment.OnEquipmentChanged -= OnEquipmentChanged;
        }

        private void OnEquipmentChanged()
        {
            _weaponSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.WeaponSlot.WeaponConfig);
            _armorSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.ArmorSlot.Config);
            _ammoSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.WeaponSlot.AmmoConfig);
        }

        public void ShowFullInformation(ItemConfig config)
        {
            if (config != null)
            {
                _infoBarNameText.text = config.DisplayName;
                _infoBarDescriptionText.text = config.Description;
            }
            else
            {
                _infoBarNameText.text = string.Empty;
                _infoBarDescriptionText.text = string.Empty;
            }
        }
    }
}