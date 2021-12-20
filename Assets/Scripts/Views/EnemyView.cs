using UnityEngine;
using UnityEngine.EventSystems;



namespace DinoHitMaster.Views
{
    class EnemyView : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("LALALA");
        }
    }
}
