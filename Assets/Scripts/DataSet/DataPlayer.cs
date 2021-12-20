﻿using UnityEngine;
using DinoHitMaster.Views;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/PlayerSettings")]
    internal class DataPlayer: ScriptableObject
    {
        public PlayerView PlayerPrefab;
        public GameObject PlayerMenPrefab;
        public GameObject PlayerWomanPrefab;

        public GameObject CubePref;

        public BulletView SimpeBulletView;
        public float SimpleBulletDamage;
        public GameObject Particle;
        public string TypeBullet;
        public float BulletSpeed;

        [Header("Player parametrs")]
        public float Speed;
        public Vector3 RotationPlayer;
        public RuntimeAnimatorController PlayerAnimatorController;
        public Avatar PlayerAvatar;
    }
}