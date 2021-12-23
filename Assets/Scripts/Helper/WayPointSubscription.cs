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
        }

        public void Subscribe()
        {
            var shootPositing = new ShootPosition(_playerNavMeshAgent, _playerTransform, _playerAnimator, _dataPlayer.RotationPlayer);
            foreach (var wayPoint in _wayPointController.WayPoints)
            {
                wayPoint.InsideWayPoint += shootPositing.IncomeShootPosition;
            }
        }
    }
}
