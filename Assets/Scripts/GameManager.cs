using UnityEngine;
using DinoHitMaster.DataSet;
using DinoHitMaster.Controllers;


namespace DinoHitMaster
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Data _data;

        private MainControllers _mainControllers;


        #region Unity Methods

        private void Awake()
        {
            _mainControllers = new MainControllers();
            new GameAwake().AwakeGame(_data, _mainControllers);
        }
        private void Start()
        {
            new GameInitialization().StartGame(_data, _mainControllers);
        }
        
        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _mainControllers.Updateble(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.deltaTime;
            _mainControllers.FixUpdateble(deltaTime);
        }

        private void OnDisable()
        {
            _mainControllers.Cleanup();
        }

        #endregion
    }
}
