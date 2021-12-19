using UnityEngine;
using UnityEngine.AI;
using DinoHitMaster.Interface;
using DinoHitMaster.Views;


namespace DinoHitMaster.Player
{
    class PlayerMovement : IMove
    {
        #region Fields

        private NavMeshAgent _playerNavMeshAgent;
        private Animator _playerAnimator;

        private WayPointView[] _wayPoints;

        private int _currentWayPointIndex;

        #endregion


        #region Consructor

        public PlayerMovement(NavMeshAgent playerNavMeshAgent, Animator playerAnimator, WayPointView[] wayPoints)
        {
            _playerNavMeshAgent = playerNavMeshAgent;
            _playerAnimator = playerAnimator;
            _wayPoints = wayPoints;
        }

        #endregion


        #region IMove realization

        public void Move()
        {
            if (!_playerAnimator.GetBool("IsMoving"))
            {
                if (_currentWayPointIndex < _wayPoints.Length - 1)
                {
                    _playerNavMeshAgent.enabled = true;
                    _currentWayPointIndex++;
                    _playerAnimator.SetBool("IsMoving", true);
                    Debug.Log(_wayPoints[_currentWayPointIndex].transform.position);
                    _playerNavMeshAgent.SetDestination(_wayPoints[_currentWayPointIndex].transform.position);
                }
                else if (_currentWayPointIndex >= _wayPoints.Length - 1)
                {

                    Debug.Log("End wayPoints");
                }
            }
        }

        #endregion
    }
}
