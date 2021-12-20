﻿using UnityEngine;
using DinoHitMaster.Interface;
using DinoHitMaster.ObjectPool;


namespace DinoHitMaster.Views
{
    class BulletView: MonoBehaviour, IAmmunition
    {
        private float _damage;

        public float Damage { set => _damage = value; }

        private void OnTriggerEnter(Collider collier)
        {
            if(collier.gameObject.GetComponent<EnemyView>())
            {
                
            }
            Destroy();
        }

        private void OnBecameInvisible()
        {
            BulletObjectPool.ReturnToPool(this);
        }

        private void Destroy()
        {
            BulletObjectPool.ReturnToPool(this);
        }
    }
}
