using UnityEngine;
using DinoHitMaster.Controllers;
using DinoHitMaster.DataSet;
using DinoHitMaster.Interface;


namespace DinoHitMaster.Enemy
{
    class EnemyInitialization: IInitialization
    {
        private readonly Data _data;
        private readonly MainControllers _mainControllers;

        public EnemyInitialization(Data data, MainControllers mainControllers)
        {
            _data = data;
            _mainControllers = mainControllers;
        }

        public void Initialization()
        {

        }
    }
}
