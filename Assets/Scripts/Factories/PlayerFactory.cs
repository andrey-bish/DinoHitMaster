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
            (player as MonoBehaviour).transform.rotation *= Quaternion.Euler(playerRotation);
            return (T)player;
        }
    }
}
