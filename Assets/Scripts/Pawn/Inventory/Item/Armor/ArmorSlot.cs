using UnityEngine;

namespace WinterUniverse
{
    public class ArmorSlot : MonoBehaviour
    {
        private PlayerController _player;
        private ArmorItemConfig _config;

        public ArmorItemConfig Config => _config;

        public void Initialize()
        {
            _player = GetComponentInParent<PlayerController>();
            ChangeConfig(null);
        }

        public void ChangeConfig(ArmorItemConfig config)
        {
            if (_config != null)
            {
                //_player.Status.RemoveStatModifiers(_config.EquipmentData.Modifiers);
            }
            _config = config;
            if (_config != null)
            {
                //_player.Status.AddStatModifiers(_config.EquipmentData.Modifiers);
            }
        }
    }
}