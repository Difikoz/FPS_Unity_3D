using UnityEngine;
using UnityEngine.AI;

namespace WinterUniverse
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class NPCController : MonoBehaviour
    {
        private Pawn _pawn;
        private NavMeshAgent _agent;
        private CapsuleCollider _collider;
        private NPCConfig _config;

        public Pawn Pawn => _pawn;
        public NPCConfig Config => _config;

        public void Initialize(FactionConfig faction)
        {

        }

        protected void GetComponents()
        {
            _agent = GetComponent<NavMeshAgent>();
            _collider = GetComponent<CapsuleCollider>();
            // assign height and radius
        }

        public void OnUpdate()
        {
            if (_agent.hasPath)
            {
                if (_agent.remainingDistance < _agent.radius)
                {
                    StopMovement();
                }
            }
        }

        public void SetDestination(Vector3 position)
        {
            StopMovement();
            if (NavMesh.SamplePosition(position, out NavMeshHit hit, 25f, NavMesh.AllAreas) && _agent.SetDestination(hit.position))
            {
                _agent.destination = hit.position;
            }
        }

        public void StopMovement()
        {
            _agent.ResetPath();
        }
    }
}