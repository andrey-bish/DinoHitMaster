using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.DataSet;


namespace DinoHitMaster.Factories
{
    class SimpleBulletFactory: IBulletFactory
    {
        private readonly Data _data;

        public SimpleBulletFactory(Data data)
        {
            _data = data;
        }

        public IAmmunition Create(float damage)
        {
            var bullet = Object.Instantiate(_data.Player.SimpeBulletView);
            Rigidbody rigitbody;
            if (!bullet.TryGetComponent(out rigitbody))
                rigitbody = bullet.gameObject.AddComponent<Rigidbody>();
            bullet.Damage = _data.Player.SimpleBulletDamage;
            return bullet;
        }
    }
}
