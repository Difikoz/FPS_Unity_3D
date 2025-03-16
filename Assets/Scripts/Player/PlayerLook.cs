using UnityEngine;

namespace WinterUniverse
{
    public class PlayerLook
    {
        private PlayerController _player;
        private float _xRot;

        public PlayerLook(PlayerController player)
        {
            _player = player;
        }

        public void Update()
        {
            if (_player.Input.LookInput.x != 0f)
            {
                _player.transform.Rotate(Vector3.up * _player.Input.LookInput.x * _player.Config.HorizontalSpeed * (_player.Config.InvertHorizontalInput ? -1f : 1f) * Time.deltaTime);
            }
            if (_player.Input.LookInput.y != 0f)
            {
                _xRot = Mathf.Clamp(_xRot + (_player.Input.LookInput.y * _player.Config.VerticalSpeed * (_player.Config.InvertHorizontalInput ? 1f : -1f) * Time.deltaTime), -_player.Config.MaxVerticalAngle, _player.Config.MinVerticalAngle);
                _player.Head.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
            }
        }

        public void Interact()
        {
            if (Physics.Raycast(_player.Head.position, _player.Head.forward, out RaycastHit hit, _player.Config.InteractionDistace, GameManager.StaticInstance.LayersManager.DetectableMask))
            {
                InteractableBase interactable = hit.transform.GetComponentInParent<InteractableBase>();
                if (interactable != null && interactable.CanInteract())
                {
                    interactable.Interact();
                }
            }
        }
    }
}