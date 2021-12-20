using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.DataSet;
using DinoHitMaster.Enemy;
using DinoHitMaster.Helper;

namespace DinoHitMaster.Factories
{
    class EnemyFactory : IEnemiesFactory
    {
        private readonly DataEnemy _dataEnemy;
        private readonly EnemyListener _enemyListener;

        public EnemyFactory(Data data, EnemyListener enemyListener)
        {
            _dataEnemy = data.Enemy;

            _enemyListener = enemyListener;
        }
        public IEnemy Create(Health health)
        {
            var enemy = Object.Instantiate(_dataEnemy.EnemyPrefab);
            enemy.SetHealth(health);
            health.OnDeath += enemy.Death;
            _enemyListener.Add(enemy);
            //Прописать спавн
            new EnemiesSpawner().RandomSpawnLocation(enemy);
            
            return enemy;
        }
    }
}
