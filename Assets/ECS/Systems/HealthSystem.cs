using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class HealthSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthComponent> _healthFilter = null;

        public void Run()
        {
            foreach (var i in _healthFilter)
            {
                ref var health = ref _healthFilter.Get1(i);

                if (health.health <= 0f)
                {
                    Debug.Log("Здоровье ниже 0");
                }
            }
        }
    }
}