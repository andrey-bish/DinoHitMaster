using UnityEngine;
using DinoHitMaster.Interface;


namespace DinoHitMaster.Helper
{
    class EnemyRagDollActivation
    {
        private Animator EnemyAnimator;
        private BoxCollider EnemyBoxCollider;

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
            EnemyAnimator = enemy.GetAnimator();
            EnemyAnimator.enabled = false;

            EnemyBoxCollider = enemy.GetBoxCollider();
            EnemyBoxCollider.enabled = false;

            Remove(enemy);
        }

    }
}
