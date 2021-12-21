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
        public EnemySpawnView EnemySpawn;

        private readonly Data _data;
        private readonly MainControllers _mainControllers;

        public EnemyInitialization(Data data, MainControllers mainControllers)
        {
            _data = data;
            _mainControllers = mainControllers;
        }

        public void Initialization()
        {
            EnemySpawn = Object.FindObjectOfType<EnemySpawnView>();
            EnemyObjectPool._listenerHitShowDamage = new EnemyListener();
            SpawnEnemy();

            CheckEnemy = new CheckEnemy(EnemySpawn._enemiesSpanwLocation);
        }

        public void SpawnEnemy()
        {
            for (int i = 0; i < EnemySpawn._enemiesSpanwLocation.Length; i++)
            {
                EnemyObjectPool.GetEnemy<EnemyView>(_data, EnemySpawn._enemiesSpanwLocation[i].transform);
                EnemyObjectPool.GetEnemy<EnemyView>(_data, EnemySpawn._enemiesSpanwLocation[i].transform);
                EnemySpawn._enemiesSpanwLocation[i]._enemyViews = EnemySpawn._enemiesSpanwLocation[i].GetComponentsInChildren<EnemyView>();
            }
        }
    }
}
