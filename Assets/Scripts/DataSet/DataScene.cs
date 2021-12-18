using System;
using UnityEngine;
using System.Collections.Generic;
using DinoHitMaster.Views;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Data/SceneSettings")]
    class DataScene: ScriptableObject
    {
        public List<GameObject> WayPoints = new List<GameObject>();
    }
}
