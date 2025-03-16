using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class SpawnerItem : SpawnerBase
    {
        [SerializeField] private int _limitAmount = 10;
        [SerializeField] private List<ItemStack> _stacks = new();

        private List<InteractableItem> _spawnedItems = new();

        protected override void OnSpawn()
        {
            if (_spawnedItems.Count > 0)
            {
                for (int i = _spawnedItems.Count - 1; i >= 0; i--)
                {
                    if (!_spawnedItems[i].isActiveAndEnabled)
                    {
                        _spawnedItems.RemoveAt(i);
                    }
                }
            }
            int amount = Random.Range(_minAmount, _maxAmount + 1);
            for (int i = 0; i < amount; i++)
            {
                if (_spawnedItems.Count == _limitAmount)
                {
                    break;
                }
                InteractableItem item = GameManager.StaticInstance.PrefabsManager.GetItem(_spawnPoints[Random.Range(0, _spawnPoints.Count)]);
                _spawnedItems.Add(item);
                item.Initialize(_stacks[Random.Range(0, _stacks.Count)]);
            }
        }
    }
}