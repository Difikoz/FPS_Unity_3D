using UnityEngine;

namespace WinterUniverse
{
    public class PlayerInput
    {
        private PlayerController _player;
        private PlayerInputActions _inputActions;
        private Vector2 _moveInput;
        private Vector2 _lookInput;

        public Vector2 MoveInput => _moveInput;
        public Vector2 LookInput => _lookInput;

        public PlayerInput(PlayerController player)
        {
            _player = player;
            _inputActions = new();
        }

        public void EnableInput()
        {
            _inputActions.Enable();
            _inputActions.Player.Sprint.performed += ctx => OnSprintInputPerfomed();
            _inputActions.Player.Jump.performed += ctx => OnJumpInputPerfomed();
            _inputActions.Player.Jump.canceled += ctx => OnJumpInputCanceled();
            _inputActions.Player.Crouch.performed += ctx => OnCrouchInputPerfomed();
            _inputActions.Player.Interact.performed += ctx => OnInteractInputPerfomed();
            _inputActions.Player.PrimaryAction.performed += ctx => OnPrimaryActionInputPerfomed();
            _inputActions.Player.PrimaryAction.canceled += ctx => OnPrimaryActionInputCanceled();
            _inputActions.Player.SecondaryAction.performed += ctx => OnSecondaryActionInputPerfomed();
            _inputActions.Player.SecondaryAction.canceled += ctx => OnSecondaryActionInputCanceled();
            _inputActions.Player.ExtraAction.performed += ctx => OnExtraActionInputPerfomed();
        }

        public void DisableInput()
        {
            _inputActions.Player.Sprint.performed -= ctx => OnSprintInputPerfomed();
            _inputActions.Player.Jump.performed -= ctx => OnJumpInputPerfomed();
            _inputActions.Player.Jump.canceled -= ctx => OnJumpInputCanceled();
            _inputActions.Player.Crouch.performed -= ctx => OnCrouchInputPerfomed();
            _inputActions.Player.Interact.performed -= ctx => OnInteractInputPerfomed();
            _inputActions.Player.PrimaryAction.performed -= ctx => OnPrimaryActionInputPerfomed();
            _inputActions.Player.PrimaryAction.canceled -= ctx => OnPrimaryActionInputCanceled();
            _inputActions.Player.SecondaryAction.performed -= ctx => OnSecondaryActionInputPerfomed();
            _inputActions.Player.SecondaryAction.canceled -= ctx => OnSecondaryActionInputCanceled();
            _inputActions.Player.ExtraAction.performed -= ctx => OnExtraActionInputPerfomed();
            _inputActions.Disable();
        }

        public void HandleInputs()
        {
            if (GameManager.StaticInstance.InputMode != InputMode.Game)
            {
                _moveInput = Vector2.zero;
                _lookInput = Vector2.zero;
                return;
            }
            _moveInput = _inputActions.Player.Move.ReadValue<Vector2>();
            _lookInput = _inputActions.Player.Look.ReadValue<Vector2>();
        }

        private void OnSprintInputPerfomed()
        {
            if (GameManager.StaticInstance.InputMode != InputMode.Game)
            {
                return;
            }
            _player.Locomotion.ToggleSprint();
        }

        private void OnJumpInputPerfomed()
        {
            if (GameManager.StaticInstance.InputMode != InputMode.Game)
            {
                return;
            }
            _player.Locomotion.StartJump();
        }

        private void OnJumpInputCanceled()
        {
            if (GameManager.StaticInstance.InputMode != InputMode.Game)
            {
                return;
            }
            _player.Locomotion.StopJump();
        }

        private void OnCrouchInputPerfomed()
        {
            if (GameManager.StaticInstance.InputMode != InputMode.Game)
            {
                return;
            }
            _player.Locomotion.ToggleCrouch();
        }

        private void OnInteractInputPerfomed()
        {
            if (GameManager.StaticInstance.InputMode != InputMode.Game)
            {
                return;
            }
            _player.Look.Interact();
        }

        private void OnPrimaryActionInputPerfomed()
        {
            if (GameManager.StaticInstance.InputMode != InputMode.Game)
            {
                _player.Equipment.WeaponSlot.StopFire();
                return;
            }
            _player.Equipment.WeaponSlot.StartFire();
        }

        private void OnPrimaryActionInputCanceled()
        {
            _player.Equipment.WeaponSlot.StopFire();
        }

        private void OnSecondaryActionInputPerfomed()
        {
            if (GameManager.StaticInstance.InputMode != InputMode.Game)
            {
                return;
            }

        }

        private void OnSecondaryActionInputCanceled()
        {
            if (GameManager.StaticInstance.InputMode != InputMode.Game)
            {
                return;
            }

        }

        private void OnExtraActionInputPerfomed()
        {
            if (GameManager.StaticInstance.InputMode != InputMode.Game)
            {
                return;
            }
            _player.Equipment.WeaponSlot.ReloadWeapon();
        }
    }
}