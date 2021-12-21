using UnityEngine;
using UnityEngine.AI;
using DinoHitMaster.Interface;
using DinoHitMaster.Views;
using DinoHitMaster.DataSet;
using DinoHitMaster.Helper;


namespace DinoHitMaster.Player
{
    class PlayerMovement : IMove
    {
        #region Fields

        private NavMeshAgent _playerNavMeshAgent;
        private CheckEnemy _checkEnemy;
        private Animator _playerAnimator;
        private Data _data;

        private WayPointView[] _wayPoints;

        private int _currentWayPointIndex;

        #endregion


        #region Consructor

        public PlayerMovement(NavMeshAgent playerNavMeshAgent, Animator playerAnimator, WayPointView[] wayPoints, Data data, CheckEnemy checkEnemy)
        {
            _playerNavMeshAgent = playerNavMeshAgent;
            _playerAnimator = playerAnimator;
            _wayPoints = wayPoints;
            _data = data;
            _checkEnemy = checkEnemy;
        }

        #endregion


        #region IMove realization

        public void Move()
        {
            var hasIsLive =  _checkEnemy.CheckingActiveEnemyAnimator(_currentWayPointIndex);
            if (!_playerAnimator.GetBool("IsMoving") && !hasIsLive)
            {
                _data.Player.IsLockShooting = true;
                if (_currentWayPointIndex < _wayPoints.Length - 1)
                {
                    _playerNavMeshAgent.enabled = true;
                    _currentWayPointIndex++;
                    _playerAnimator.SetBool("IsMoving", true);
                    _playerNavMeshAgent.SetDestination(_wayPoints[_currentWayPointIndex].transform.position);
                }
                else if (_currentWayPointIndex >= _wayPoints.Length - 1)
                {
                    Debug.Log("End wayPoints");

                }
            }
            else
            {
                _data.Player.IsLockShooting = false;
            }
        }

        #endregion
    }
}
