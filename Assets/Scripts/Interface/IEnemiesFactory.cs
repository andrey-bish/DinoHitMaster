using UnityEngine;
using DinoHitMaster.Helper;


namespace DinoHitMaster.Interface
{
    public interface IEnemiesFactory
    {
        IEnemy Create(Health health, Transform spawnTransform);
    }
}
