using System;
using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.Helper;


namespace DinoHitMaster.Views
{
    class EnemyView : MonoBehaviour, IEnemy
    {
        #region Fields

        public event Action<IEnemy> EnemyDead;

        public Animator _enemyAnimator;
        public CapsuleCollider _enemyCollider;
        public Rigidbody _enemyRigidBody;

        private Health _health;

        #endregion


        #region IEnemy realization

        public void SetHealth(Health health)
        {
            if(_health == null || _health.CurrentHp <= 0)
            {
                _health = health;
            }
        }

        public void Recreate()
        {
            _health.SetHp();
            _enemyAnimator.enabled = true;
            _enemyCollider.enabled = true;
            _health.OnDeath += Death;
        }

        #endregion


        #region Methods

        public void Hit(float damage)
        {
            _health.Damage(damage);
        }

        public void Death()
        {
            EnemyDead?.Invoke(this);
        }
        
        private void OnDisable()
        {
            _health.OnDeath -= Death;
        }

        #endregion
    }
}
