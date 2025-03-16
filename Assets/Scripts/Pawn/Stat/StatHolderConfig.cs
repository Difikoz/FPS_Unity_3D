using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Stat Holder", menuName = "Winter Universe/Pawn/Stat/New Holder")]
    public class StatHolderConfig : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private List<StatCreator> _statBaseValues = new();

        public string ID => _id;
        public List<StatCreator> StatBaseValues => _statBaseValues;
    }
}