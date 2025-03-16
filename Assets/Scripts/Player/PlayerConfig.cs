using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Locomotion", menuName = "Winter Universe/Player/New Config")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Locomotion")]
        [SerializeField] private float _acceleration = 16f;
        [SerializeField] private float _deceleration = 32f;
        [SerializeField] private float _maxSpeed = 8f;
        [SerializeField] private float _standJumpForce = 2f;
        [SerializeField] private float _crouchJumpForce = 3f;
        [SerializeField, Range(1, 9)] private int _jumpCount = 1;
        [SerializeField, Range(0.1f, 1f)] private float _timeToJump = 0.5f;
        [SerializeField, Range(0.1f, 1f)] private float _timeToFall = 0.5f;
        [Header("Crouch")]
        [SerializeField] private float _standHeight = 1.8f;
        [SerializeField] private float _crouchHeight = 1.2f;
        [SerializeField, Range(0.5f, 0.9f)] private float _headHeightPercent = 0.9f;
        [SerializeField, Range(0.1f, 1f)] private float _timeToStand = 0.5f;
        [SerializeField, Range(0.1f, 1f)] private float _timeToCrouch = 0.5f;
        [Header("Look")]
        [SerializeField] private bool _invertHorizontalInput;
        [SerializeField] private bool _invertVerticalInput;
        [SerializeField] private float _horizontalSpeed = 10f;
        [SerializeField] private float _verticalSpeed = 10f;
        [SerializeField] private float _minVerticalAngle = 90f;
        [SerializeField] private float _maxVerticalAngle = 90f;
        [SerializeField] private float _interactionDistace = 1f;

        public float Acceleration => _acceleration;
        public float Deceleration => _deceleration;
        public float MaxSpeed => _maxSpeed;
        public float StandJumpForce => _standJumpForce;
        public float CrouchJumpForce => _crouchJumpForce;
        public int JumpCount => _jumpCount;
        public float TimeToJump => _timeToJump;
        public float TimeToFall => _timeToFall;
        public float StandHeight => _standHeight;
        public float CrouchHeight => _crouchHeight;
        public float HeadHeightPercent => _headHeightPercent;
        public float TimeToStand => _timeToStand;
        public float TimeToCrouch => _timeToCrouch;
        public bool InvertHorizontalInput => _invertHorizontalInput;
        public bool InvertVerticalInput => _invertVerticalInput;
        public float HorizontalSpeed => _horizontalSpeed;
        public float VerticalSpeed => _verticalSpeed;
        public float MinVerticalAngle => _minVerticalAngle;
        public float MaxVerticalAngle => _maxVerticalAngle;
        public float InteractionDistace => _interactionDistace;
    }
}