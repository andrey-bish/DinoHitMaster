using UnityEngine;
using UnityEngine.UI;
using DinoHitMaster.Interface;
using DinoHitMaster.DataSet;


namespace DinoHitMaster.Helper
{
    class EnemyListener
    {
        public bool _isShowPlease = false;

        public void Add(IEnemy value)
        {
            //value.EnemyDead += ShowMessageDeathEnemy;
        }

        public void Remove(IEnemy value)
        {
           // value.EnemyDead -= ShowMessageDeathEnemy;
        }

        private void ShowMessageDeathEnemy(IEnemy enemy)
        {
            Remove(enemy);
        }

    }
}
