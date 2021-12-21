using UnityEngine;
using DinoHitMaster.Views;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Data/WeaponSettings")]
    class DataWeapon: ScriptableObject
    {
        public BulletView SimpeBulletView;
        public float SimpleBulletDamage;
        public GameObject Particle;
        public string TypeBullet;
        public float BulletSpeed;
        public int CurrentIndexWP;
        public bool IsLockShooting;
    }
}
