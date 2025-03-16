using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Rigidbody))]
    public class InteractableChest : InteractableBase
    {
        [SerializeField] private SwitchableAnimatedObject _chest;
        [SerializeField] private List<ItemStack> _stacks = new();

        public override bool CanInteract()
        {
            return _stacks.Count > 0;
        }

        public override void Interact()
        {
            _chest.SwitchOn();
            foreach (ItemStack stack in _stacks)
            {
                GameManager.StaticInstance.ControllersManager.Player.Pawn.Inventory.AddItem(stack);
            }
            _stacks.Clear();
        }
    }
}