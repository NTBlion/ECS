using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class ShootEventSendSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ShootEventComponent> _shootComponent;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0) == false)
                return;

            foreach (var i in _shootComponent)
            {
                ref var entity = ref _shootComponent.GetEntity(i);
                entity.Get<ShootEventComponent>();
            }
        }
    }
}