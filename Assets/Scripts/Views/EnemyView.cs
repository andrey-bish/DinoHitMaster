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

        private Health _health;

        public void SetHealth(Health health)
        {
            if(_health == null || _health.CurrentHp <= 0)
            {
                _health = health;
            }
        }

        public void Death()
        {

        }
        
        
    }
}
