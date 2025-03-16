using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class PlayerLocomotion
    {
        private PlayerController _player;
        private CharacterController _cc;
        private Vector3 _moveVelocity;
        private Vector3 _fallVelocity;
        private RaycastHit _groundHit;
        private Coroutine _crouchCoroutine;
        private bool _isGrounded;
        private bool _isSprinting;
        private bool _isCrouching;
        private int _jumpCount;
        private float _jumpTime;
        private float _groundedTime;

        public PlayerLocomotion(PlayerController player)
        {
            _player = player;
            _cc = _player.GetComponent<CharacterController>();
            StopSprint();
            StopCrouch();
        }

        public void Update()
        {
            CheckJumping();
            CheckGround();
            CalculateFallVelocity();
            CalculateMoveVelocity();
            ApplyVelocity();
        }

        public void ToggleSprint()
        {
            if (_isSprinting)
            {
                StopSprint();
            }
            else
            {
                StartSprint();
            }
        }

        public void StartJump()
        {
            if (_jumpCount == 0)
            {
                _jumpTime = _player.Config.TimeToJump;
            }
            else if (_jumpCount < _player.Config.JumpCount)
            {
                ApplyJumpForce(_player.Config.StandJumpForce);
            }
        }

        public void StopJump()
        {
            if (_fallVelocity.y > 0f)
            {
                _fallVelocity.y /= 2f;
            }
        }

        public void ToggleCrouch()
        {
            if (_isCrouching)
            {
                StopCrouch();
            }
            else
            {
                StartCrouch();
            }
        }

        private void CheckJumping()
        {
            if (_jumpTime > 0f)
            {
                if (_groundedTime > 0f)
                {
                    if (_isCrouching)
                    {
                        if (StopCrouch())
                        {
                            ApplyJumpForce(_player.Config.CrouchJumpForce);
                        }
                    }
                    else if (!UnderRoof())
                    {
                        ApplyJumpForce(_player.Config.StandJumpForce);
                    }
                }
                _jumpTime -= Time.deltaTime;
            }
        }

        private void CheckGround()
        {
            _isGrounded = _fallVelocity.y <= 0 && Physics.SphereCast(_player.transform.position + _cc.center, _cc.radius, Vector3.down, out _groundHit, _cc.center.y - _cc.radius * 0.8f, GameManager.StaticInstance.LayersManager.ObstacleMask);
        }

        private void CalculateFallVelocity()
        {
            if (_isGrounded)
            {
                _fallVelocity.y = GameManager.StaticInstance.ConfigsManager.Gravity / 10f;
                _groundedTime = _player.Config.TimeToFall;
            }
            else
            {
                _jumpCount = 0;
                if (_fallVelocity.y > 0f && UnderRoof())
                {
                    _fallVelocity.y = 0f;
                }
                _fallVelocity.y += GameManager.StaticInstance.ConfigsManager.Gravity * Time.deltaTime;
                if (_groundedTime > 0f)
                {
                    _groundedTime -= Time.deltaTime;
                }
            }
        }

        private void CalculateMoveVelocity()
        {
            if (ObstacleOnWay())
            {
                _moveVelocity = Vector3.zero;
            }
            else if (_player.Input.MoveInput != Vector2.zero)
            {
                _moveVelocity = Vector3.MoveTowards(_moveVelocity, GetMoveDirection() * _player.Config.MaxSpeed, _player.Config.Acceleration * Time.deltaTime);
            }
            else
            {
                if (_isSprinting && _moveVelocity.magnitude < 0.1f)
                {
                    ToggleSprint();
                }
                _moveVelocity = Vector3.MoveTowards(_moveVelocity, Vector3.zero, _player.Config.Deceleration * Time.deltaTime);
            }
        }

        private void ApplyVelocity()
        {
            _cc.Move((_moveVelocity + _fallVelocity) * Time.deltaTime);
        }

        private void StartSprint()
        {
            _isSprinting = true;
            //_currentConfig = _sprintConfig;
        }

        private void StopSprint()
        {
            _isSprinting = false;
            //_currentConfig = _walkConfig;
        }

        private void ApplyJumpForce(float force)
        {
            _jumpCount++;
            _jumpTime = 0f;
            _groundedTime = 0f;
            _fallVelocity.y = Mathf.Sqrt(force * -2f * GameManager.StaticInstance.ConfigsManager.Gravity);
        }

        private void StartCrouch()
        {
            if (_crouchCoroutine != null)
            {
                //StopCoroutine(_crouchCoroutine);
            }
            _isCrouching = true;
            //_crouchCoroutine = StartCoroutine(ToggleCrouchCoroutine());
        }

        private bool StopCrouch()
        {
            if (CanUncrouch())
            {
                if (_crouchCoroutine != null)
                {
                    //StopCoroutine(_crouchCoroutine);
                }
                _isCrouching = false;
                //_crouchCoroutine = StartCoroutine(ToggleCrouchCoroutine());
                return true;
            }
            return false;
        }

        private IEnumerator ToggleCrouchCoroutine()
        {
            float currentTime = 0f;
            float currentHeight = _cc.height;
            if (_isCrouching)
            {
                while (currentTime < _player.Config.TimeToCrouch)
                {
                    currentTime += Time.deltaTime;
                    _cc.height = Mathf.Lerp(currentHeight, _player.Config.CrouchHeight, currentTime / _player.Config.TimeToCrouch);
                    _cc.center = Vector3.up * _cc.height / 2f;
                    _player.Head.localPosition = Vector3.up * _cc.height * _player.Config.HeadHeightPercent;
                    yield return null;
                }
            }
            else
            {
                while (currentTime < _player.Config.TimeToStand)
                {
                    currentTime += Time.deltaTime;
                    _cc.height = Mathf.Lerp(currentHeight, _player.Config.StandHeight, currentTime / _player.Config.TimeToStand);
                    _cc.center = Vector3.up * _cc.height / 2f;
                    _player.Head.localPosition = Vector3.up * _cc.height * _player.Config.HeadHeightPercent;
                    if (UnderRoof())
                    {
                        StartCrouch();
                    }
                    yield return null;
                }
            }
            _crouchCoroutine = null;
        }

        private Vector3 GetMoveDirection()
        {
            return _player.transform.forward * _player.Input.MoveInput.y + _player.transform.right * _player.Input.MoveInput.x;
        }

        private bool ObstacleOnWay()
        {
            return _moveVelocity.magnitude > 0f && Physics.CapsuleCast(_player.transform.position + Vector3.up * _cc.height * 0.3f, _player.transform.position + Vector3.up * _cc.height * 0.7f, _cc.radius * 0.5f, _moveVelocity.normalized, _cc.radius * 0.75f, GameManager.StaticInstance.LayersManager.ObstacleMask);
        }

        private bool UnderRoof()
        {
            return Physics.SphereCast(_player.transform.position + _cc.center, _cc.radius, Vector3.up, out _, _cc.center.y - _cc.radius * 0.8f, GameManager.StaticInstance.LayersManager.ObstacleMask);
        }

        private bool CanUncrouch()
        {
            return !UnderRoof() && !Physics.SphereCast(_player.transform.position + Vector3.up * _player.Config.StandHeight / 2f, _cc.radius, Vector3.up, out _, _player.Config.StandHeight / 2f - _cc.radius * 0.95f, GameManager.StaticInstance.LayersManager.ObstacleMask);
        }
    }
}