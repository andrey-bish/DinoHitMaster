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

            var enemyInitialize = EnemyIntialize(data, mainControllers);
            var playerInitialze = (PlayerInitialize(data, mainControllers, enemyInitialize));

            InitializeObjectList.Add(enemyInitialize);
            InitializeObjectList.Add(playerInitialze);
            InitializeObjectList.Add(SceneManager(data, playerInitialze, enemyInitialize));
            

            AddInMainController(InitializeObjectList, mainControllers);

            mainControllers.Initialization();
        }

        private PlayerInitialization PlayerInitialize(Data data, MainControllers mainControllers, EnemyInitialization enemyInitialize)
        {
            return new PlayerInitialization(data, mainControllers, enemyInitialize);
        }

        private EnemyInitialization EnemyIntialize(Data data, MainControllers mainControllers)
        {
            return new EnemyInitialization(data, mainControllers);
        }

        private SceneManager SceneManager(Data data, PlayerInitialization playerInitialization, EnemyInitialization enemyInitialize)
        {
            return new SceneManager(data, playerInitialization, enemyInitialize);
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
