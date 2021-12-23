using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.DataSet;


namespace DinoHitMaster.Factories
{
    class AssaultRifleFactory : IWeaponFactory
    {
        private readonly DataWeapon _dataWeapon;

        public AssaultRifleFactory(DataWeapon dataWeapon)
        {
            _dataWeapon = dataWeapon;
        }

        public IWeapon Create(string typeWeapon)
        {
            var weapon = Object.Instantiate(_dataWeapon.AssaultRiflePrefab);
            weapon.FireCooldown = _dataWeapon.AssaultRifleFireCooldown;
            return weapon;
        }
    }
}
