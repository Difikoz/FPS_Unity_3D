using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class ControllersManager : MonoBehaviour
    {
        [SerializeField] private FactionConfig _playerFaction;

        private PlayerController _player;
        private List<NPCController> _controllers = new();

        public PlayerController Player => _player;

        public void Initialize()
        {
            _player = GameManager.StaticInstance.PrefabsManager.GetPlayer(transform);
            //_player.Initialize(_playerFaction);
        }

        public void ResetComponent()
        {
            foreach (NPCController controller in _controllers)
            {
                //controller.ResetComponents();
            }
        }

        public void OnUpdate()
        {
            //_player.OnUpdate();
            foreach (NPCController controller in _controllers)
            {
                controller.OnUpdate();
            }
        }

        public void AddController(NPCController controller)
        {
            _controllers.Add(controller);
        }

        public void RemoveController(NPCController controller)
        {
            if (_controllers.Contains(controller))
            {
                _controllers.Remove(controller);
            }
        }
    }
}