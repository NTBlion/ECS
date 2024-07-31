using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UIElements;

namespace ECS.Systems
{
    sealed class ShootSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<ShootPointComponent> _shootFilter = null;

        public void Run()
        {
            foreach (var i in _shootFilter)
            {
                ref var entity = ref _shootFilter.Get1(i);
                var position = entity.position;

                if (Input.GetMouseButtonDown(0))
                {
                    var fireballPrefab = Resources.Load<GameObject>("fireball");
                    GameObject.Instantiate(fireballPrefab, position.position, position.rotation);
                }
            }
        }
    }
}