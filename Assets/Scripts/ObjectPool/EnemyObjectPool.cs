using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using DinoHitMaster.Interface;
using DinoHitMaster.Factories;
using DinoHitMaster.DataSet;
using DinoHitMaster.Helper;


namespace DinoHitMaster.ObjectPool
{
    class EnemyObjectPool
    {
        public static readonly Dictionary<string, HashSet<IEnemy>> _enemyCollection = new Dictionary<string, HashSet<IEnemy>>();

        private static Data _data;

        public static EnemyRagDollActivation _listenerHitShowDamage;

        #region Create Enemy

        private static IEnemy CreateEnemy(string typeEnemies, Transform spawnTransform)
        {
            IEnemy enemy = null;
            switch (typeEnemies)
            {
                case ("EnemyView"):
                    enemy = new EnemyFactory(_data, _listenerHitShowDamage).Create(new Health(_data.Enemy.EnemyHp), spawnTransform);
                    break;
                default:
                    throw new NullReferenceException("The specified enemy type was not found.");
            }
            return enemy;
        }

        #endregion


        #region Search in dictionary

        private static HashSet<IEnemy> GetListEnemy(string typeEnemies)
        {
            Debug.Log(typeEnemies);
            if (_enemyCollection.ContainsKey(typeEnemies))
            {
                return _enemyCollection[typeEnemies];
            }
            else
            {
                return _enemyCollection[typeEnemies] = new HashSet<IEnemy>();
            }        
        }

        #endregion


        #region GetEnemy Method

        public static T GetEnemy<T>(Data data, Transform spawnTransform) where T : IEnemy
        {
            _data = data;
            var type = typeof(T).Name;
            var list = GetListEnemy(type);

            var enemy = list.FirstOrDefault(x => !(x as MonoBehaviour).gameObject.activeSelf);
            if (enemy == null)
            {
                enemy = CreateEnemy(type, spawnTransform);
                list.Add(enemy);
            }
            else
            {
                _listenerHitShowDamage.Add(enemy);
                enemy.Recreate();
            }
            (enemy as MonoBehaviour).gameObject.SetActive(true);
            return (T)enemy;
        }

        #endregion


        public static void ReturnToPool(IEnemy enemy)
        {
            (enemy as MonoBehaviour).gameObject.SetActive(false);
        }
    }
}
