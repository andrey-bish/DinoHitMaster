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
        public IEnemy Create(Health health, Transform spawnTransform)
        {
            Vector3 pos = new Vector3(Random.Range(spawnTransform.position.x - 1.0f, spawnTransform.position.x + 1.0f),
                spawnTransform.position.y, Random.Range(spawnTransform.position.z - 1.0f, spawnTransform.position.z + 1.0f));

            var enemy = Object.Instantiate(_dataEnemy.EnemyPrefab, pos, spawnTransform.rotation, spawnTransform);

            enemy.SetHealth(health);
            health.OnDeath += enemy.Death;
            _enemyListener.Add(enemy);
            
            return enemy;
        }
    }
}
