using UnityEngine;
using UnityEngine.AI;
using DinoHitMaster.Controllers;
using DinoHitMaster.DataSet;
using DinoHitMaster.Interface;
using DinoHitMaster.Views;
using DinoHitMaster.Helper;
using DinoHitMaster.Enemy;


namespace DinoHitMaster.Player
{
    class PlayerInitialization: IInitialization, ICleanup
    {
        #region Fields

        public PlayerView Player;
        public PlayerMovement PlayerMovement;
        public WayPointController WayPointController;

        private readonly Data _data;
        private readonly MainControllers _mainControllers;

        private EnemyInitialization _enemyInitialization;
        private WayPointSubscription _wayPointSubscription;
        private NavMeshAgent _playerNavMeshAgent;
        private Animator _playerAnimator;

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

            //Временная симуляция выбора типа игрока
            Player = new PlayerCreater(_data).CreatePlayer("MenPlayer");
            Player.transform.position = WayPointController.WayPoints[0].transform.position;
            TryGetCompontents();
            
            //Временная симуляция выбора оружия
            var weapon = new WeaponCreater(_data, _playerAnimator).CreateWeapon("TwoHand");

            _wayPointSubscription = new WayPointSubscription(_data.Player, WayPointController, _playerNavMeshAgent, Player.transform, _playerAnimator);
            _wayPointSubscription.Subscribe();

            PlayerMovement = new PlayerMovement(_playerNavMeshAgent, _playerAnimator, WayPointController.WayPoints, _data, _enemyInitialization.CheckStatusEnemyAnimator);
            var playerShooting = new PlayerShooting(_data, weapon);
            new InputController(_mainControllers, PlayerMovement, playerShooting);
        }

        #endregion


        #region Methods

        private void TryGetCompontents()
        {
            if (!Player.TryGetComponent(out _playerAnimator))
            {
                _playerAnimator = Player.gameObject.AddComponent<Animator>();
                _playerAnimator.avatar = _data.Player.PlayerAvatar;
            }

            if (!Player.TryGetComponent(out _playerNavMeshAgent))
            {
                _playerNavMeshAgent = Player.gameObject.AddComponent<NavMeshAgent>();
                _playerNavMeshAgent.speed = _data.Player.Speed;
            }
        }

        #endregion


        #region ICleanup realization

        public void Cleanup()
        {
            _wayPointSubscription.Unsubscribe();
        }

        #endregion
    }
}
