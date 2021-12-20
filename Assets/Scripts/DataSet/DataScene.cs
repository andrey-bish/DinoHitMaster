using System.Collections.Generic;
using UnityEngine;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Data/SceneSettings")]
    class DataScene: ScriptableObject
    {
        public List<GameObject> WayPoints = new List<GameObject>();

        public Vector3 CameraOffset;

        public LayerMask layer;
    }
}
