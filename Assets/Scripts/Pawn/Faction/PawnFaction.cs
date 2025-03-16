using System;
using UnityEngine;

namespace WinterUniverse
{
    public class PawnFaction
    {
        public Action OnFactionChanged;

        private Pawn _pawn;
        private FactionConfig _config;

        public FactionConfig Config => _config;

        public PawnFaction(Pawn pawn)
        {
            _pawn = pawn;
        }

        public void ChangeConfig(FactionConfig config)
        {
            _config = config;
            OnFactionChanged?.Invoke();
        }
    }
}