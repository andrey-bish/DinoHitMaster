using UnityEngine;
using DinoHitMaster.Views;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Data/WeaponSettings")]
    class DataWeapon: ScriptableObject
    {
        [Header("Simple bullet parameters")]
        public BulletView SimpeBulletView;
        public GameObject Particle;
        public float BulletSpeed;
        public float SimpleBulletDamage;

        [Header("Pistol parameters")]
        public WeaponView PistolPrefab;
        public float PistolFireCooldown;

        [Header("Assault rifle parameters")]
        public WeaponView AssaultRiflePrefab;
        public float AssaultRifleFireCooldown;

        [Header("Other data")]
        public RuntimeAnimatorController OneHandWeapon;
        public RuntimeAnimatorController TwoHandWeapon;
        public string TypeBullet;
        public bool IsLockShooting;
    }
}
