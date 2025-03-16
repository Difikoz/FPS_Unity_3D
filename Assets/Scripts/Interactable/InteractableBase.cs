using UnityEngine;

namespace WinterUniverse
{
    public abstract class InteractableBase : MonoBehaviour
    {
        public abstract bool CanInteract();
        public abstract void Interact();
    }
}