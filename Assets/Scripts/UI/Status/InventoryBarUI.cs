using Lean.Pool;
using TMPro;
using UnityEngine;

namespace WinterUniverse
{
    public class InventoryBarUI : MonoBehaviour
    {
        [SerializeField] private Transform _contentRoot;
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] private TMP_Text _infoBarNameText;
        [SerializeField] private TMP_Text _infoBarDescriptionText;

        public void Initialize()
        {
            GameManager.StaticInstance.ControllersManager.Player.Pawn.Inventory.OnInventoryChanged += OnInventoryChanged;
            OnInventoryChanged();
        }

        public void ResetComponent()
        {
            GameManager.StaticInstance.ControllersManager.Player.Pawn.Inventory.OnInventoryChanged -= OnInventoryChanged;
        }

        private void OnInventoryChanged()
        {
            while (_contentRoot.childCount > 0)
            {
                LeanPool.Despawn(_contentRoot.GetChild(0).gameObject);
            }
            foreach (ItemStack stack in GameManager.StaticInstance.ControllersManager.Player.Pawn.Inventory.Stacks)
            {
                ShowFullInformation(stack.Item);
                LeanPool.Spawn(_slotPrefab, _contentRoot).GetComponent<InventorySlotUI>().Initialize(stack);
            }
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