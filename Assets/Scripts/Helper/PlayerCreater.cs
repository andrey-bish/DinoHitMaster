using System;
using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.Factories;
using DinoHitMaster.DataSet;
using DinoHitMaster.Views;


namespace DinoHitMaster.Helper
{
    class PlayerCreater
    {
        private readonly Data _data;

        public PlayerCreater(Data data)
        {
            _data = data;
        }

        public PlayerView CreatePlayer(string typePlayer)
        {
            var player =  CreatingPlayer(typePlayer);
            return (player as MonoBehaviour).GetComponent<PlayerView>();
        }

        private IPlayer CreatingPlayer(string typePlayer)
        {
            IPlayer player = null;
            switch (typePlayer)
            {
                case "MenPlayer":
                    player = new PlayerFactory().Create<PlayerView>(_data.Player.PlayerMenPrefab, _data.Player.RotationPlayer);
                    break;
                case "WomanPlayer":
                    player = new PlayerFactory().Create<PlayerView>(_data.Player.PlayerWomanPrefab, _data.Player.RotationPlayer);
                    break;
                default:
                    throw new NullReferenceException("The specified bullet type was not found");
            }
            return player;
        }
    }
}
