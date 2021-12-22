using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.ObjectPool;


namespace DinoHitMaster.Views
{
    class BulletView: MonoBehaviour, IAmmunition
    {
        private float _damage;

        public float Damage { set => _damage = value; }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.TryGetComponent<IEnemy>(out var hitObject))
            {
                hitObject.Hit(_damage);
            }
            Destroy();
        }

        private void OnBecameInvisible()
        {
            Destroy();
        }

        private void Destroy()
        {
            BulletObjectPool.ReturnToPool(this);
        }
    }
}
