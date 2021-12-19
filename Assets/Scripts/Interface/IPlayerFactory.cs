using UnityEngine;


namespace DinoHitMaster.Interface
{
    public interface IPlayerFactory
    {
        T Create<T>(GameObject gameObject, Vector3 playerRotation) where T : IPlayer;
    }
}
