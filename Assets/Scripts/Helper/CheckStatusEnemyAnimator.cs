using System.Linq;
using DinoHitMaster.Views;


namespace DinoHitMaster.Helper
{
    class CheckStatusEnemyAnimator
    {
        private EnemyLocation[] _enemyLocations;

        public CheckStatusEnemyAnimator(EnemyLocation[] enemyLocation)
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
