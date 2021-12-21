using System.Collections.Generic;
using UnityEngine;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Data/SceneSettings")]
    class DataScene: ScriptableObject
    {
        public Vector3 CameraOffset;
    }
}
