using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.DataSet;


namespace DinoHitMaster.Factories
{
    class PistolFactory : IWeaponFactory
    {
        private readonly DataWeapon _dataWeapon;

        public PistolFactory(DataWeapon dataWeapon)
        {
            _dataWeapon = dataWeapon; 
        }

        public IWeapon Create(string typeWeapon)
        {
            var weapon = Object.Instantiate(_dataWeapon.PistolPrefab);
            weapon.FireCooldown = _dataWeapon.PistolFireCooldown;
            return weapon;
        }
    }
}
