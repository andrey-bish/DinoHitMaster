using UnityEngine;
using UnityEngine.UI;
using DinoHitMaster.Interface;
using DinoHitMaster.DataSet;


namespace DinoHitMaster.Helper
{
    class EnemyListener
    {
        public bool _isShowPlease = false;

        public void Add(IEnemy value)
        {
            value.EnemyDead += ActivateRagDoll;
        }

        public void Remove(IEnemy value)
        {
            value.EnemyDead -= ActivateRagDoll;
        }

        private void ActivateRagDoll(IEnemy enemy)
        {
            var enemyAnimator = enemy.GetAnimator();
            enemyAnimator.enabled = false;
            Remove(enemy);
        }

    }
}
