using UnityEngine;

namespace WinterUniverse
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private StatHolderConfig _statHolder;
        [SerializeField] private StateHolderConfig _stateHolder;
        [SerializeField] private Transform _head;

        private Pawn _pawn;
        private PlayerEquipment _equipment;
        private PlayerInput _input;
        private PlayerLocomotion _locomotion;
        private PlayerLook _look;

        public PlayerConfig Config => _config;
        public Transform Head => _head;
        public Pawn Pawn => _pawn;
        public PlayerEquipment Equipment => _equipment;
        public PlayerInput Input => _input;
        public PlayerLocomotion Locomotion => _locomotion;
        public PlayerLook Look => _look;

        private void Awake()
        {
            _pawn = new(_statHolder.StatBaseValues, _stateHolder.States);
            _equipment = new(this);
            _input = new(this);
            _locomotion = new(this);
            _look = new(this);
        }

        private void OnEnable()
        {
            _input.EnableInput();
        }

        private void OnDisable()
        {
            _input.DisableInput();
        }

        private void Update()
        {
            _input.HandleInputs();
            _locomotion.Update();
            _look.Update();
        }
    }
}