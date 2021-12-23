using UnityEngine;
using DinoHitMaster.Interface;


namespace DinoHitMaster.Views
{
    class WeaponView : MonoBehaviour, IWeapon
    {
        private Transform _shootPosition;

        private float _fireCooldown;

        public float FireCooldown { get => _fireCooldown; set => _fireCooldown = value; }
        public Transform ShootPosition { get => _shootPosition; set => _shootPosition = value; }
    }
}
