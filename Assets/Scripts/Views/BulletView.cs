using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.ObjectPool;


namespace DinoHitMaster.Views
{
    class BulletView: MonoBehaviour, IAmmunition
    {
        private float _damage;
        private float trust = 10.0f;

        public float Damage { set => _damage = value; }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.TryGetComponent<IEnemy>(out var hitObject))
            {
                hitObject.Hit(_damage);
                var enemyRigidbody = (hitObject as MonoBehaviour).transform.Find("Root/Hips");
                enemyRigidbody.GetComponent<Rigidbody>().AddForce(-trust, -trust, 0, ForceMode.Impulse);
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
