using Abstractions.Pool;
using Tanks;
using Tanks.Models;
using UnityEngine;

namespace Pool
{
    public class TankFactory<T> : Factory<T> where T : ITankController
    {
        private TanksDescriptions description;

        public override void Init(Descriptions descriptions, MonoFactory factory)
        {
            base.Init(descriptions, factory);
            description = descriptions.Tanks;
        }

        protected override T FactoryPoolMethod(IPool<T> pool)
        {
            // заглушка
            var view = new GameObject().AddComponent<TankView>();
            var model = description.GetModel;
            ITankController controller = new TankController(view, model);

            return (T)controller;
        }
    }

    public class TankController : ITankController
    {
        private TankView _view;
        private ITankModel _model;

        public TankController(TankView view, ITankModel model)
        {
            _view = view;
            _model = model;
        }

        public void PoolInit()
        {
            throw new System.NotImplementedException();
        }

        public void PoolClear()
        {
            throw new System.NotImplementedException();
        }
    }

    public class TankView : MonoBehaviour
    {
    }
}