using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.DataSet;
using DinoHitMaster.ObjectPool;


namespace DinoHitMaster.Player
{
    class PlayerShooting: IShoot
    {
        private readonly Data _data;

        private Transform _weaponShootPosition;
        private Touch _touch;

        private float _zTouchOffset = 10.0f;
        private float _lastFireTime = 0.0f;
        private float _shotCooldown;

        public PlayerShooting(Data data, IWeapon weapon)
        {
            _data = data;
            _weaponShootPosition = weapon.ShootPosition;
            _shotCooldown = weapon.FireCooldown;
        }

        public void Shoot()
        {
            _touch = Input.GetTouch(0);
            if(!_data.Weapon.IsLockShooting && _lastFireTime + _shotCooldown < Time.time)
            {
                if (_touch.phase == TouchPhase.Began)
                {
                    var direction = new Vector3(_touch.position.x, _touch.position.y - 2.0f, _zTouchOffset);
                    var touchPosition = Camera.main.ScreenToWorldPoint(direction);
                    _lastFireTime = Time.time;
                    var bullet = BulletObjectPool.GetBullet(_data, _weaponShootPosition);
                    bullet.velocity = touchPosition.normalized * _data.Weapon.BulletSpeed;
                }
            }
        }
    }
}
