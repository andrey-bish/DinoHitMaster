using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.DataSet;
using DinoHitMaster.ObjectPool;


namespace DinoHitMaster.Player
{
    class PlayerShooting: IShoot
    {
        private readonly Data _data;

        private Transform _weaponTransform;
        private Touch _touch;

        private float _zTouchOffset = 10.0f;

        public PlayerShooting(Data data)
        {
            _data = data;
            _weaponTransform = GameObject.Find("ShootPosition").transform;
        }

        public void Shoot()
        {
            _touch = Input.GetTouch(0);
            if(!_data.Player.IsLockShooting)
            {
                if (_touch.phase == TouchPhase.Began)
                {
                    var direction = new Vector3(_touch.position.x, _touch.position.y - 2.0f, _zTouchOffset);
                    var touchPosition = Camera.main.ScreenToWorldPoint(direction);
                    var bullet = BulletObjectPool.GetBullet(_data, _weaponTransform);
                    bullet.velocity = touchPosition.normalized * _data.Player.BulletSpeed;
                }
            }
        }
    }
}
