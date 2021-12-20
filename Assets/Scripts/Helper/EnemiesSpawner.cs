using UnityEngine;
using DinoHitMaster.Interface;


namespace DinoHitMaster.Helper
{
    public class EnemiesSpawner
    {
        //написать нормальный спавнер
        public void RandomSpawnLocation(IEnemy enemy)
        {
            var spawnPoint = GameObject.Find("Enemies");
            (enemy as MonoBehaviour).transform.position = spawnPoint.transform.position;
        }
    }
}
