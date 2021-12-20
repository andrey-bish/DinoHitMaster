using UnityEngine;
using DinoHitMaster.Views;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Data/EnemiesSettings")]
    internal class DataEnemy: ScriptableObject
    {
        public EnemyView EnemyPrefab;
    }
}
