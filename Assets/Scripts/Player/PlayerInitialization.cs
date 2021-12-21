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

        private readonly Data _data;
        private readonly MainControllers _mainControllers;

        private EnemyInitialization _enemyInitialization;
        private WayPointController _wayPointController;
        private NavMeshAgent _playerNavMeshAgent;
        private PlayerView _player;
        private Animator _animator;
        private Camera _camera;

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
            _wayPointController = Object.FindObjectOfType<WayPointController>();
            _data.Player.TypeBullet = "SimpleBullet";
            _player = new PlayerFactory().Create<PlayerView>(_data.Player.PlayerMenPrefab, _data.Player.RotationPlayer);
            _player.transform.position = _wayPointController.WayPoints[0].transform.position;

            _camera = Camera.main;
            _camera.transform.parent = _player.transform;
            _camera.transform.position = _player.transform.position + _data.Scene.CameraOffset;

            TryGetCompontents();
            WayPointSubscribe();

            var playerMovement = new PlayerMovement(_playerNavMeshAgent, _animator, _wayPointController.WayPoints, _data, _enemyInitialization.CheckEnemy);
            var playerShooting = new PlayerShooting(_data);
            new InputController(_mainControllers, playerMovement, playerShooting);
        }

        #endregion


        #region Methods

        private void WayPointSubscribe()
        {
            var shootPositing = new ShootPosition(_playerNavMeshAgent, _player.transform, _animator, _data.Player.RotationPlayer);
            foreach(var wayPoint in _wayPointController.WayPoints)
            {
                wayPoint.InsideWayPoint += shootPositing.IncomeShootPosition;
            }
        }

        private void TryGetCompontents()
        {
            if(!_player.TryGetComponent(out _animator))
            {
                _animator = _player.gameObject.AddComponent<Animator>();
                _animator.runtimeAnimatorController = _data.Player.PlayerAnimatorController;
                _animator.avatar = _data.Player.PlayerAvatar;
            }
            if(!_player.TryGetComponent(out _playerNavMeshAgent))
            {
                _playerNavMeshAgent = _player.gameObject.AddComponent<NavMeshAgent>();
                _playerNavMeshAgent.speed = _data.Player.Speed;
            }
        }

        #endregion
    }
}
