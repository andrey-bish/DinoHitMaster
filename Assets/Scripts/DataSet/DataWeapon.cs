using UnityEngine;
using DinoHitMaster.Views;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Data/WeaponSettings")]
    class DataWeapon: ScriptableObject
    {
        public BulletView SimpeBulletView;
        public GameObject Particle;

        public string TypeBullet;

        public float SimpleBulletDamage;
        public float BulletSpeed;
        public float FireCooldown;

        public bool IsLockShooting;
    }
}
