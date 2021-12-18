using System;
using UnityEngine;
using System.Collections.Generic;
using DinoHitMaster.Views;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/PlayerSettings")]
    internal class DataPlayer: ScriptableObject
    {
        public PlayerView PlayerPrefab;
    }
}