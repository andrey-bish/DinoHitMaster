using DinoHitMaster.Interface;


namespace DinoHitMaster.Controllers
{
    class PlayerController: IMove
    {
        private IMove _move;

        public PlayerController(IMove move)
        {
            _move = move;
        }

        public void Move()
        {
            _move.Move();
        }
    }
}
