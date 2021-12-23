using UnityEngine;

namespace DinoHitMaster.Interface
{
    public interface IWeapon
    {
        Transform ShootPosition { get; set; }
        float FireCooldown { get; set; }
    }
}
