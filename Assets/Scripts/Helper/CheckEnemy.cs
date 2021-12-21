using System.Linq;
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
            var loc = _enemyLocations[indexWayPoint];
            var check = loc._enemyViews.Any(o => o._enemyAnimator.enabled);
            return check;
        }
    }
}
