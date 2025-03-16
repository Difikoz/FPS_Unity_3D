using Lean.Pool;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class FactionsBarUI : MonoBehaviour
    {
        [SerializeField] private Transform _contentRoot;
        [SerializeField] private GameObject _slotPrefab;
        //[SerializeField] private TMP_Text _playerFactionNameText;
        [SerializeField] private Image _infoBarIconImage;
        [SerializeField] private TMP_Text _infoBarDescriptionText;

        private List<FactionSlotUI> _slots = new();

        public void Initialize()
        {
            for (int i = 0; i < GameManager.StaticInstance.ConfigsManager.Factions.Count; i++)
            {
                _slots.Add(LeanPool.Spawn(_slotPrefab, _contentRoot).GetComponent<FactionSlotUI>());
            }
            GameManager.StaticInstance.ControllersManager.Player.Pawn.Faction.OnFactionChanged += OnFactionChanged;
            OnFactionChanged();
        }

        public void ResetComponent()
        {
            GameManager.StaticInstance.ControllersManager.Player.Pawn.Faction.OnFactionChanged -= OnFactionChanged;
            while (_contentRoot.childCount > 0)
            {
                LeanPool.Despawn(_contentRoot.GetChild(0).gameObject);
            }
            _slots.Clear();
        }

        private void OnFactionChanged()
        {
            //_playerFactionNameText.text = GameManager.StaticInstance.ControllersManager.Player.Faction.Config.DisplayName;
            int index = 0;
            foreach (FactionRelationship fr in GameManager.StaticInstance.ControllersManager.Player.Pawn.Faction.Config.Relationships)
            {
                ShowFullInformation(fr);
                _slots[index].Initialize(fr);
                index++;
            }
        }

        public void ShowFullInformation(FactionRelationship relationship)
        {
            _infoBarIconImage.sprite = relationship.Faction.Icon;
            _infoBarDescriptionText.text = relationship.Faction.Description;
        }
    }
}