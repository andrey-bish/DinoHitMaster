using System;
using DinoHitMaster.Helper;


namespace DinoHitMaster.Interface
{
    public interface IEnemy
    {
        event Action<IEnemy> EnemyDead;
        void SetHealth(Health health);
    }
}
