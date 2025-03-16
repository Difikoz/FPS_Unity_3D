using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "NPC", menuName = "Winter Universe/NPC/New NPC")]
    public class NPCConfig : BasicInfoConfig
    {
        [SerializeField] private NameListConfig _nameList;
        [SerializeField] private VisualConfig _visual;
        [SerializeField] private VoiceConfig _voice;
        [SerializeField] private InventoryConfig _inventory;

        public NameListConfig NameList => _nameList;
        public VisualConfig Visual => _visual;
        public VoiceConfig Voice => _voice;
        public InventoryConfig Inventory => _inventory;
    }
}