using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Name List", menuName = "Winter Universe/NPC/New Name List")]
    public class NameListConfig : ScriptableObject
    {
        [SerializeField] private List<string> _displayNames = new();

        public string GetDisplayName()
        {
            return _displayNames[Random.Range(0, _displayNames.Count)];
        }
    }
}