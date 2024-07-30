using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class ShootSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ShootEventComponent> _shootFilter;
        
        public void Run()
        {
            foreach (var i in _shootFilter)
            {
                ref var entity = ref _shootFilter.GetEntity(i);
                
                Debug.Log("Ты пидор");
            }
        }
    }
}