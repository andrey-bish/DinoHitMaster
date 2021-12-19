using UnityEngine;
using DinoHitMaster.Interface;


namespace DinoHitMaster.Controllers
{
    class InputController:IUpdateble
    {
        private IMove _playerMovement;

        public InputController(MainControllers mainControllers, IMove playerMovement)
        {
            mainControllers.Add(this);
            _playerMovement = playerMovement;
        }

        public void Updateble(float deltaTime)
        {
            if(Input.touchCount > 0)
            {
                _playerMovement.Move();
            }
        }
    }
}
