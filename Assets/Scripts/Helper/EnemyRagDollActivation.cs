using UnityEngine;
using DinoHitMaster.Interface;


namespace DinoHitMaster.Helper
{
    class EnemyRagDollActivation
    {
        private Animator EnemyAnimator;
        private CapsuleCollider EnemyCollider;

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
            EnemyAnimator = (enemy as MonoBehaviour).GetComponent<Animator>();
            EnemyAnimator.enabled = false;

            EnemyCollider = (enemy as MonoBehaviour).GetComponent<CapsuleCollider>();
            EnemyCollider.enabled = false;

            Remove(enemy);
        }

    }
}
