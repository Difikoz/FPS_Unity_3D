using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class Pawn
    {
        private PawnHealth _health;
        private PawnStamina _stamina;
        private StatHolder _statHolder;
        private StateHolder _stateHolder;
        private EffectHolder _effectHolder;
        private PawnInventory _inventory;
        private PawnFaction _faction;

        public PawnHealth Health => _health;
        public PawnStamina Stamina => _stamina;
        public StatHolder StatHolder => _statHolder;
        public StateHolder StateHolder => _stateHolder;
        public EffectHolder EffectHolder => _effectHolder;
        public PawnInventory Inventory => _inventory;
        public PawnFaction Faction => _faction;

        public Pawn(List<StatCreator> stats, List<StateKeyConfig> states)
        {
            _health = new(this);
            _stamina = new(this);
            _statHolder = new(stats);
            _stateHolder = new(states);
            _effectHolder = new(this);
            _inventory = new(this);
            _faction = new(this);
        }
    }
}