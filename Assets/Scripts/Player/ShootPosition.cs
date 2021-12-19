using UnityEngine;
using UnityEngine.AI;


namespace DinoHitMaster.Player
{
    class ShootPosition
    {
        private NavMeshAgent _playerNavMeshAgent;
        private Transform _playerTransform;
        private Animator _playerAnimator;
        private Vector3 _playerRotation;
        
        public ShootPosition(NavMeshAgent playerNavMeshAgent, Transform playerTransform, Animator playerAnimator, Vector3 playerRotation)
        {
            _playerNavMeshAgent = playerNavMeshAgent;
            _playerTransform = playerTransform;
            _playerAnimator = playerAnimator;
            _playerRotation = playerRotation;
        }

        public void IncomeShootPosition()
        {
            _playerAnimator.SetBool("IsMoving", false);
            _playerNavMeshAgent.enabled = false;
            _playerTransform.rotation *= Quaternion.Euler(_playerRotation);
        }
    }
}
