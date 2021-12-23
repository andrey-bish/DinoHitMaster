using UnityEngine;
using DinoHitMaster.Views;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/PlayerSettings")]
    internal class DataPlayer: ScriptableObject
    {
        public GameObject PlayerMenPrefab;
        public GameObject PlayerWomanPrefab;

        [Header("Player parameters")]
        public float Speed;
        public Vector3 RotationPlayer;
        
        public Avatar PlayerAvatar;
    }
}