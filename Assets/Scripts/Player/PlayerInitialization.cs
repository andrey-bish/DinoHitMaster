using UnityEngine;
using UnityEngine.AI;
using DinoHitMaster.Controllers;
using DinoHitMaster.DataSet;
using DinoHitMaster.Interface;
using DinoHitMaster.Views;
using DinoHitMaster.Factories;
using DinoHitMaster.Enemy;


namespace DinoHitMaster.Player
{
    class PlayerInitialization: IInitialization
    {
        #region Fields

        public PlayerView Player;
        public PlayerMovement PlayerMovement;
        public WayPointController WayPointController;

        private readonly Data _data;
        private readonly MainControllers _mainControllers;

        private EnemyInitialization _enemyInitialization;
        private NavMeshAgent _playerNavMeshAgent;
        private Animator _animator;

        #endregion


        #region Constructor

        public PlayerInitialization(Data data, MainControllers mainControllers, EnemyInitialization enemyInitialization)
        {
            _data = data;
            _mainControllers = mainControllers;
            _enemyInitialization = enemyInitialization;
        }

        #endregion


        #region Iinitialization realization

        public void Initialization()
        {
            WayPointController = Object.FindObjectOfType<WayPointController>();
            
            Player = new PlayerFactory().Create<PlayerView>(_data.Player.PlayerMenPrefab, _data.Player.RotationPlayer);
            Player.transform.position = WayPointController.WayPoints[0].transform.position;

            TryGetCompontents();
            WayPointSubscribe();

            PlayerMovement = new PlayerMovement(_playerNavMeshAgent, _animator, WayPointController.WayPoints, _data, _enemyInitialization.CheckEnemy);
            var playerShooting = new PlayerShooting(_data);
            new InputController(_mainControllers, PlayerMovement, playerShooting);
        }

        #endregion


        #region Methods

        private void WayPointSubscribe()
        {
            var shootPositing = new ShootPosition(_playerNavMeshAgent, Player.transform, _animator, _data.Player.RotationPlayer);
            foreach(var wayPoint in WayPointController.WayPoints)
            {
                wayPoint.InsideWayPoint += shootPositing.IncomeShootPosition;
            }
        }

        private void TryGetCompontents()
        {
            if(!Player.TryGetComponent(out _animator))
            {
                _animator = Player.gameObject.AddComponent<Animator>();
                _animator.runtimeAnimatorController = _data.Player.PlayerAnimatorController;
                _animator.avatar = _data.Player.PlayerAvatar;
            }
            if(!Player.TryGetComponent(out _playerNavMeshAgent))
            {
                _playerNavMeshAgent = Player.gameObject.AddComponent<NavMeshAgent>();
                _playerNavMeshAgent.speed = _data.Player.Speed;
            }
        }

        #endregion
    }
}
