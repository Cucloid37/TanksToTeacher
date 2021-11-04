using System.Collections.Generic;
using TANKS.Start;
using UnityEngine;

namespace TANKS
{
    public class LevelController
    {
        private readonly Data _data;
        private readonly List<Vector3> _spawnPoints;
        private readonly List<Vector3> _spawnPlayerPoints;
        private List<TankModel> _playerTank;
        private List<TankModel> _enemyTank;
        private List<TankController> _enemyTankControllers;
        private List<TankController> _playerTankControllers;
        private List<GameObject> _viewList;
        private List<GameObject> _viewList2;
        private readonly IFactory _factory;
        private IBulletFactory _bulletFactory;
        private GameObject _level;
        
        private readonly GunModel _gun;
        private readonly AmmoModel _ammo;
        private readonly ArmourModel _armour;

        public List<TankModel> PlayerTank => _playerTank;
        public List<TankModel> EnemyTank => _enemyTank;
        public List<TankController> PlayerControllers => _playerTankControllers;
        public List<TankController> EnemyControllers => _enemyTankControllers;

        private const int Health = 10;

        public LevelController(Data data, IFactory factory, GunModel gun, AmmoModel ammo, ArmourModel armour)
        {
            _data = data;
            _spawnPoints = data.LevelData.SpawnPoints;
            _spawnPlayerPoints = data.LevelData.SpawnPlayer;
            _factory = factory;
            _gun = gun;
            _ammo = ammo;
            _armour = armour;
            _playerTank = new List<TankModel>(1);
            _enemyTank = new List<TankModel>(3);
            _viewList = new List<GameObject>();
            _viewList2 = new List<GameObject>();
            _enemyTankControllers = new List<TankController>(3);
            _playerTankControllers = new List<TankController>(1);
            _bulletFactory = new GameObject("Bullet").AddComponent<BulletFactory>();
        }

        public void Initialization()
        {
            _level = _factory.CreatePrefab(_data.LevelData.Prefab, Vector3.zero);

            for (var i = 0; i < _spawnPoints.Capacity; i++)
            {
                _viewList.Add(_factory.CreatePrefab(_data.TanksData.Prefab, _spawnPoints[i]));
                var model = new TankModel(_gun, _ammo, _armour, _viewList[i].GetComponent<TankView>(), $"Name enemy {i}", Health);
                _enemyTank.Add(model);
                _enemyTankControllers.Add(new TankController(model, _bulletFactory));
                Debug.Log($"Объем поинтов врагов {_enemyTank.Capacity}");

            }
            
            for (var i = 0; i < _spawnPlayerPoints.Capacity; i++)
            {
                _viewList2.Add(_factory.CreatePrefab(_data.TanksData.Prefab, _spawnPlayerPoints[i]));
                var model = new TankModel(_gun, _ammo, _armour, _viewList[_viewList.Capacity].GetComponent<TankView>(), $"Name player {i}", Health);
                _playerTank.Add(model);
                _playerTankControllers.Add(new TankController(model, _bulletFactory));
                Debug.Log($"Объем поинтов игрока {_playerTank.Capacity}");
            }
        }
    }
}