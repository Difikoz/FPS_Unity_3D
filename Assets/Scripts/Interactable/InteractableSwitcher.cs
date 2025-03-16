using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class InteractableSwitcher : InteractableBase
    {
        [SerializeField] private bool _singleUse;
        [SerializeField] private List<SwitchableBase> _switchable = new();

        private bool _used;

        private void Awake()
        {
            _used = false;
        }

        public override bool CanInteract()
        {
            return !_used && _switchable != null;
        }

        public override void Interact()
        {
            if (_singleUse)
            {
                _used = true;
            }
            foreach (SwitchableBase switchable in _switchable)
            {
                switchable.Switch();
            }
        }
    }
}