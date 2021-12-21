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
        public BoxCollider _enemyCollider;

        private Health _health;

        #endregion


        #region IEnemy realization

        #region GetComponent Methods

        public Animator GetAnimator()
        {
            return _enemyAnimator.GetComponent<Animator>();
        }

        public BoxCollider GetBoxCollider()
        {
            return _enemyCollider.GetComponent<BoxCollider>();
        }

        #endregion

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
            Debug.Log("OnDisable");
            _health.OnDeath -= Death;
        }

        #endregion
    }
}
