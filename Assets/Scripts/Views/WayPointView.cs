using System;
using UnityEngine;
using DinoHitMaster.Interface;


namespace DinoHitMaster.Views
{
    public class WayPointView: MonoBehaviour
    {
        public event Action InsideWayPoint;
        

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.GetComponent<PlayerView>())
            {
                InsideWayPoint?.Invoke();
            }
        }


    }
}
