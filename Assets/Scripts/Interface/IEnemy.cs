using System;
using DinoHitMaster.Helper;
using UnityEngine;

namespace DinoHitMaster.Interface
{
    public interface IEnemy
    {
        event Action<IEnemy> EnemyDead;
        void SetHealth(Health health);
        void Hit(float damage);
        void Recreate();
     }
}
