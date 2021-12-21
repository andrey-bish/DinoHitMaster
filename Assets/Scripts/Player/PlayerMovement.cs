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

        public int CurrentWayPointIndex;

        private WayPointView[] _wayPoints;

        private NavMeshAgent _playerNavMeshAgent;
        private CheckEnemy _checkEnemy;
        private Animator _playerAnimator;
        private Data _data;

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
            var hasIsLive =  _checkEnemy.CheckingActiveEnemyAnimator(CurrentWayPointIndex);
            if (!_playerAnimator.GetBool("IsMoving") && !hasIsLive)
            {
                _data.Player.IsLockShooting = true;
                if (CurrentWayPointIndex < _wayPoints.Length - 1)
                {
                    _playerNavMeshAgent.enabled = true;
                    CurrentWayPointIndex++;
                    _playerAnimator.SetBool("IsMoving", true);
                    _playerNavMeshAgent.SetDestination(_wayPoints[CurrentWayPointIndex].transform.position);
                }
                else 
                {
                    CurrentWayPointIndex = 0;
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
