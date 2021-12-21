using UnityEngine;
using DinoHitMaster.Controllers;
using DinoHitMaster.DataSet;
using DinoHitMaster.Interface;
using DinoHitMaster.ObjectPool;
using DinoHitMaster.Helper;
using DinoHitMaster.Views;


namespace DinoHitMaster.Enemy
{
    class EnemyInitialization: IInitialization
    {
        public CheckEnemy CheckEnemy;

        private readonly Data _data;
        private readonly MainControllers _mainControllers;

        public EnemyInitialization(Data data, MainControllers mainControllers)
        {
            _data = data;
            _mainControllers = mainControllers;
        }

        public void Initialization()
        {
            var spawn = Object.FindObjectOfType<EnemySpawnView>();
            EnemyObjectPool._listenerHitShowDamage = new EnemyListener();
            SpawnEnemy(spawn);

            CheckEnemy = new CheckEnemy(spawn._enemiesSpanwLocation);
        }

        private void SpawnEnemy(EnemySpawnView enemySpawn)
        {
            for (int i = 0; i < enemySpawn._enemiesSpanwLocation.Length; i++)
            {
                EnemyObjectPool.GetEnemy<EnemyView>(_data, enemySpawn._enemiesSpanwLocation[i].transform);
                EnemyObjectPool.GetEnemy<EnemyView>(_data, enemySpawn._enemiesSpanwLocation[i].transform);
                enemySpawn._enemiesSpanwLocation[i]._enemyViews = enemySpawn._enemiesSpanwLocation[i].GetComponentsInChildren<EnemyView>();
            }
        }
    }
}
