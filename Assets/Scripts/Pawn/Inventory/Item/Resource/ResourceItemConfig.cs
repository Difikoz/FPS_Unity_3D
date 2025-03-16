using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Resource", menuName = "Winter Universe/Pawn/Inventory/Item/New Resource")]
    public class ResourceItemConfig : ItemConfig
    {
        private void OnValidate()
        {
            _itemType = ItemType.Resource;
        }

        public override void Use(bool fromInventory = true)
        {

        }
    }
}