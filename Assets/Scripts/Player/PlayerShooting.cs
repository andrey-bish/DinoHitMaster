using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.DataSet;
using DinoHitMaster.ObjectPool;
using System;

namespace DinoHitMaster.Player
{
    class PlayerShooting: IShoot
    {
        private  GameObject _cube;
        private readonly Data _data;
        private Touch _touch;
        private Transform _playerTransform;
        private Transform _weaponTransform;

        public PlayerShooting(Data data, GameObject cube, Transform playerTransform, Transform weaponTransform)
        {
            _data = data;
            _cube = cube;
            _playerTransform = playerTransform;
            _weaponTransform = weaponTransform;
        }
        public void Shoot()
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                var direction = new Vector3(_touch.position.x, _touch.position.y-2.0f, 10.0f);
                var touchPosition = Camera.main.ScreenToWorldPoint(direction);
                var bullet = BulletObjectPool.GetBullet(_data, _weaponTransform);
                bullet.velocity = touchPosition * _data.Player.BulletSpeed;
                //bullet.AddForce(touchPosition * _data.Player.BulletSpeed, ForceMode.Impulse);
                Debug.DrawRay(_weaponTransform.position, touchPosition, Color.red, 1);
            }
        }

    }
}
