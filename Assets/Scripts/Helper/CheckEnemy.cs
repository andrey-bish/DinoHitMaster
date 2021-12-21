using System.Linq;
using UnityEngine;
using DinoHitMaster.Views;


namespace DinoHitMaster.Helper
{
    class CheckEnemy
    {
        private EnemyLocation[] _enemyLocations;

        public CheckEnemy(EnemyLocation[] enemyLocation)
        {
            _enemyLocations = enemyLocation;
        }

        public bool CheckingActiveEnemyAnimator(int indexWayPoint)
        {
            if(indexWayPoint < _enemyLocations.Length)
            {
                var loc = _enemyLocations[indexWayPoint];
                var check = loc._enemyViews.Any(o => o._enemyAnimator.enabled);
                return check;
            }

            return true;
        }
    }
}
