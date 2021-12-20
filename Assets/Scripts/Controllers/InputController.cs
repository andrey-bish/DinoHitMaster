using UnityEngine;
using DinoHitMaster.Interface;


namespace DinoHitMaster.Controllers
{
    class InputController:IUpdateble
    {
        private IMove _playerMovement;
        private IShoot _playerShooting;

        public InputController(MainControllers mainControllers, IMove playerMovement, IShoot playerShooting)
        {
            mainControllers.Add(this);
            _playerMovement = playerMovement;
            _playerShooting = playerShooting;
        }

        public void Updateble(float deltaTime)
        {
            if(Input.touchCount > 0)
            {
                //_playerMovement.Move();
                _playerShooting.Shoot();
            }
        }
    }
}
