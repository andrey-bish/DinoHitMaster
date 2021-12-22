using UnityEngine;
using DinoHitMaster.Player;
using DinoHitMaster.Enemy;
using DinoHitMaster.Views;
using DinoHitMaster.DataSet;
using DinoHitMaster.Interface;
using DinoHitMaster.ObjectPool;


namespace DinoHitMaster.Controllers
{
    class SceneManager: IInitialization, ICleanup
    {
        #region Fields

        private readonly Data _data;

        private EnemyView[] enemies;

        private PlayerInitialization _playerInitialization;
        private EnemyInitialization _enemyInitialization;
        private WayPointController _wayPointController;
        private Camera _camera;

        #endregion


        #region Constructor

        public SceneManager(Data data, PlayerInitialization playerInitialization, EnemyInitialization enemyInitialization)
        {
            _data = data;
            _playerInitialization = playerInitialization;
            _enemyInitialization = enemyInitialization;
        }

        #endregion


        #region IInitialization realization

        public void Initialization()
        {
            enemies = Object.FindObjectsOfType<EnemyView>();
            _wayPointController = _playerInitialization.WayPointController;

            _data.Weapon.TypeBullet = "SimpleBullet";

            _camera = Camera.main;
            _camera.transform.parent = _playerInitialization.Player.transform;
            _camera.transform.position = _playerInitialization.Player.transform.position + _data.Scene.CameraOffset;
            _camera.transform.rotation = Quaternion.Euler(new Vector3(0.0f, -30.0f, 0.0f));

            SubscribeMethods();
        }

        #endregion


        #region Methods

        private void SubscribeMethods()
        {
            _wayPointController.WayPoints[_wayPointController.WayPoints.Length - 1].FinishWayPoint += EnemyRestart;
            _wayPointController.WayPoints[_wayPointController.WayPoints.Length - 1].FinishWayPoint += _enemyInitialization.SpawnEnemy;
            _wayPointController.WayPoints[_wayPointController.WayPoints.Length - 1].FinishWayPoint += PlayerRestartPosition;
            
        }

        private void PlayerRestartPosition()
        {
            _playerInitialization.Player.transform.position = _wayPointController.WayPoints[0].transform.position;
            _playerInitialization.PlayerMovement.CurrentWayPointIndex = 0;
        }

        private void EnemyRestart()
        {
            foreach(var enemy in enemies)
            {
                EnemyObjectPool.ReturnToPool(enemy);
            }
        }

        #endregion


        #region ICleanup realization

        public void Cleanup()
        {
            _wayPointController.WayPoints[_wayPointController.WayPoints.Length - 1].FinishWayPoint -= _enemyInitialization.SpawnEnemy;
            _wayPointController.WayPoints[_wayPointController.WayPoints.Length - 1].FinishWayPoint -= PlayerRestartPosition;
            _wayPointController.WayPoints[_wayPointController.WayPoints.Length - 1].FinishWayPoint -= EnemyRestart;
        }

        #endregion
    }
}
