using UnityEngine;
using UnityEngine.AI;
using DinoHitMaster.Views;
using DinoHitMaster.DataSet;
using DinoHitMaster.Player;


namespace DinoHitMaster.Helper
{
    class WayPointSubscription
    {
        private readonly DataPlayer _dataPlayer;

        private WayPointController _wayPointController;
        private ShootPosition _shootPosition;

        private NavMeshAgent _playerNavMeshAgent;
        private Transform _playerTransform;
        private Animator _playerAnimator;
        
        public WayPointSubscription(DataPlayer dataPlayer, WayPointController wayPointController, NavMeshAgent playerNavMeshAgent, Transform playerTransform, Animator playerAnimator)
        {
            _dataPlayer = dataPlayer;
            _wayPointController = wayPointController;
            _playerNavMeshAgent = playerNavMeshAgent;
            _playerTransform = playerTransform;
            _playerAnimator = playerAnimator;
            _shootPosition = new ShootPosition(_playerNavMeshAgent, _playerTransform, _playerAnimator, _dataPlayer.RotationPlayer);
        }

        public void Subscribe()
        {
            foreach (var wayPoint in _wayPointController.WayPoints)
            {
                wayPoint.InsideWayPoint += _shootPosition.IncomeShootPosition;
            }
        }

        public void Unsubscribe()
        {
            foreach (var wayPoint in _wayPointController.WayPoints)
            {
                wayPoint.InsideWayPoint -= _shootPosition.IncomeShootPosition;
            }
        }
    }
}
