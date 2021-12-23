using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using DinoHitMaster.Factories;
using DinoHitMaster.Interface;
using DinoHitMaster.DataSet;



namespace DinoHitMaster.ObjectPool
{
    class BulletObjectPool
    {
        public static Dictionary<string, HashSet<IAmmunition>> _bulletCollection = new Dictionary<string, HashSet<IAmmunition>>();

        private static Data _data;

        private static Vector3 _direction;

        #region Create Bullet

        private static IAmmunition Create(string typeBullet)
        {
            IAmmunition bullet = null;
            switch(typeBullet)
            {
                case "SimpleBullet":
                    bullet = new SimpleBulletFactory(_data).Create(_data.Weapon.SimpleBulletDamage);
                    break;
                default:
                    throw new NullReferenceException("The specified bullet type was not found");
            }
            return bullet;
        }

        #endregion


        #region GetBullet Method

        public static Rigidbody GetBullet(Data data, Transform weaponShootPosition)
        {
            var bullet = GetBullets(data, weaponShootPosition);
            return (bullet as MonoBehaviour).GetComponent<Rigidbody>();
        }

        private static IAmmunition GetBullets(Data data, Transform weaponShootPosition)
        {
            _data = data;
            var typeBullet = _data.Weapon.TypeBullet;
            var list = GetListBullet(typeBullet);
            var bullet = list.FirstOrDefault(x => !(x as MonoBehaviour).gameObject.activeSelf);
            if (bullet == null)
            {
                bullet = Create(typeBullet);
                list.Add(bullet);
            }
            
            (bullet as MonoBehaviour).transform.position = weaponShootPosition.position;
            (bullet as MonoBehaviour).gameObject.SetActive(true);
            return bullet;
        }

        #endregion


        #region Search in dictionary

        private static HashSet<IAmmunition> GetListBullet(string typeBullet)
        {
            if (_bulletCollection.ContainsKey(typeBullet))
            {
                return _bulletCollection[typeBullet];
            }    
               
            else
            {
                return _bulletCollection[typeBullet] = new HashSet<IAmmunition>();
            }
        }

        #endregion


        public static void ReturnToPool(IAmmunition bullet)
        {
            (bullet as MonoBehaviour).gameObject.SetActive(false);
        }
    }
}
