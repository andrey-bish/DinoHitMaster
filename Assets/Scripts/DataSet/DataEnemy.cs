using UnityEngine;
using DinoHitMaster.Views;
using DinoHitMaster.Helper;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Data/EnemiesSettings")]
    internal class DataEnemy: ScriptableObject
    {
        public EnemyView EnemyPrefab;

        public CheckEnemy checkEnemyExemplar;

        public Vector3 SpawnSpread;
    }
}
