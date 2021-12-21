using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.Views;


namespace DinoHitMaster.Factories
{
    class PlayerFactory : IPlayerFactory
    {
        public T Create<T>(GameObject gameObject, Vector3 playerRotation) where T : IPlayer
        {
            var player = (IPlayer)Object.Instantiate(gameObject).AddComponent<PlayerView>();
            return (T)player;
        }
    }
}
