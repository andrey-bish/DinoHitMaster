using UnityEngine;
using DinoHitMaster.Controllers;
using DinoHitMaster.DataSet;
using DinoHitMaster.Interface;
using DinoHitMaster.Views;


namespace DinoHitMaster.Player
{
    class PlayerInitialization: IInitialization
    {
        private readonly Data _data;
        private readonly MainControllers _mainControllers;


        public PlayerInitialization(Data data, MainControllers mainControllers)
        {
            _data = data;
            _mainControllers = mainControllers;
        }

        public void Initialization()
        {
            var wayPoints = Object.FindObjectOfType<WayPointController>();

            var player = Object.Instantiate(_data.Player.PlayerPrefab);
            player.transform.position = wayPoints.WayPoints[0].transform.position;
        }
    }
}
