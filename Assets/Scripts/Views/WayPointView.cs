using System;
using UnityEngine;
using DinoHitMaster.Interface;


namespace DinoHitMaster.Views
{
    public class WayPointView: MonoBehaviour
    {
        public event Action InsideWayPoint;
        public event Action FinishWayPoint;
        public bool IsFinish;

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.GetComponent<PlayerView>())
            {
                if (IsFinish)
                {
                    FinishWayPoint?.Invoke();
                }
                else
                {
                    InsideWayPoint?.Invoke();
                }
                
            }
        }


    }
}
