using System.Collections.Generic;
using DinoHitMaster.DataSet;
using DinoHitMaster.Interface;
using DinoHitMaster.Player;
using DinoHitMaster.Enemy;
using DinoHitMaster.Controllers;


namespace DinoHitMaster
{
    class GameInitialization
    {
        public void StartGame(Data data, MainControllers mainControllers)
        {
            List<IInitialization> InitializeObjectList = new List<IInitialization>();

            InitializeObjectList.Add(PlayerInitialize(data, mainControllers));
            InitializeObjectList.Add(EnemyIntialize(data, mainControllers));

            AddInMainController(InitializeObjectList, mainControllers);

            mainControllers.Initialization();
        }

        private PlayerInitialization PlayerInitialize(Data data, MainControllers mainControllers)
        {
            return new PlayerInitialization(data, mainControllers);
        }

        private EnemyInitialization EnemyIntialize(Data data, MainControllers mainControllers)
        {
            return new EnemyInitialization(data, mainControllers);
        }


        private void AddInMainController(List<IInitialization> InitializeObjectList, MainControllers mainControllers)
        {
            foreach(IInitialization InitializeObject in InitializeObjectList)
            {
                mainControllers.Add(InitializeObject);
            }
        }
    }
}
