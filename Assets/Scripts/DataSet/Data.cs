using UnityEngine;


namespace DinoHitMaster.DataSet
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    internal class Data : ScriptableObject
    {
        [SerializeField] private DataPlayer _player;
        [SerializeField] private DataEnemy _enemies;
        [SerializeField] private DataScene _scene;
        [SerializeField] private DataWeapon _weapon;

        public DataPlayer Player
        {
            get => _player;
            set => _player = value;
        }

        public DataEnemy Enemy
        {
            get => _enemies;
            set => _enemies = value;
        }

        public DataScene Scene
        {
            get => _scene;
            set => _scene = value;
        }

        public DataWeapon Weapon
        {
            get => _weapon;
            set => _weapon = value;
        }
    }
}
