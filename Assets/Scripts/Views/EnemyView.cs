using System;
using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.ObjectPool;
using DinoHitMaster.Helper;


namespace DinoHitMaster.Views
{
    class EnemyView : MonoBehaviour, IEnemy
    {
        public event Action<IEnemy> EnemyDead;

        public Animator _enemyAnimator;

        private Health _health;

        public Animator GetAnimator()
        {
            return _enemyAnimator.GetComponent<Animator>();
        }
        public void SetHealth(Health health)
        {
            if(_health == null || _health.CurrentHp <= 0)
            {
                _health = health;
                Debug.Log(_health);
            }
        }

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
            EnemyObjectPool.ReturnToPool(this);
        }
    }
}
