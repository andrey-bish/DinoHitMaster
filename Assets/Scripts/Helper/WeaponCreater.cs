using System;
using UnityEngine;
using DinoHitMaster.DataSet;
using DinoHitMaster.Factories;
using DinoHitMaster.Interface;


namespace DinoHitMaster.Helper
{
    class WeaponCreater
    {
        private readonly DataWeapon _dataWeapon;

        private Animator _playerAnimator;
        private Transform _weaponPosition;

        public WeaponCreater(Data data, Animator playerAnimator)
        {
            _dataWeapon = data.Weapon;
            _playerAnimator = playerAnimator;
            _weaponPosition = GameObject.Find("Weapon_Position").transform;
        }

        #region CreateWeapon

        public IWeapon CreateWeapon(string typeWeapon)
        {
            IWeapon weapon = null;
            switch (typeWeapon)
            {
                case "OneHand":
                    Debug.Log("ONEHAND CASE");
                    weapon = new PistolFactory(_dataWeapon).Create(typeWeapon);
                    var weaponOneHandPosition = _weaponPosition.Find("One_Hand_Position");
                    WeaponPosition(weapon, weaponOneHandPosition);
                    _playerAnimator.runtimeAnimatorController = _dataWeapon.OneHandWeapon;
                    break;

                case "TwoHand":
                    Debug.Log("TWOHAND CASE");
                    weapon = new AssaultRifleFactory(_dataWeapon).Create(typeWeapon);
                    var weaponTwoHandPosition = _weaponPosition.Find("Two_Hand_Position");
                    WeaponPosition(weapon, weaponTwoHandPosition);
                    _playerAnimator.runtimeAnimatorController = _dataWeapon.TwoHandWeapon;
                    break;

                default:
                    throw new NullReferenceException("The specified enemy type was not found.");
            }
            return weapon;
        }

        private void WeaponPosition(IWeapon weapon, Transform weaponPosition)
        {
            (weapon as MonoBehaviour).transform.position = weaponPosition.position;
            (weapon as MonoBehaviour).transform.parent = weaponPosition.transform;
            weapon.ShootPosition = weaponPosition.Find("ShootPosition");
        }

        #endregion
    }
}
