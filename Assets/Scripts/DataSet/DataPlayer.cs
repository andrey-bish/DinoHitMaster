using UnityEngine;
using DinoHitMaster.Views;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/PlayerSettings")]
    internal class DataPlayer: ScriptableObject
    {
        public GameObject PlayerMenPrefab;
        public GameObject PlayerWomanPrefab;

        [Header("Player parametrs")]
        public float Speed;
        public Vector3 RotationPlayer;
        public RuntimeAnimatorController PlayerAnimatorController;
        public Avatar PlayerAvatar;
    }
}