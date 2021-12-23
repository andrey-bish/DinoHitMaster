using UnityEngine;


namespace DinoHitMaster.Interface
{
    public interface IWeaponFactory
    {
        IWeapon Create(string typeWeapon);
    }
}
