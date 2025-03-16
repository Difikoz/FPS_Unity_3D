using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "State Holder", menuName = "Winter Universe/Pawn/State/New State Holder")]
    public class StateHolderConfig : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private List<StateKeyConfig> _states = new();

        public string ID => _id;
        public List<StateKeyConfig> States => _states;
    }
}