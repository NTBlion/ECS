using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class EnemyFollowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, MovableComponent, TargetComponent> _enemyFilter = null;

        public void Run()
        {
            foreach (var i in _enemyFilter)
            {
                ref var modelComponent = ref _enemyFilter.Get1(i);
                ref var moveSpeedComponent = ref _enemyFilter.Get2(i);
                ref var targetComponent = ref _enemyFilter.Get3(i);
                
                var targetTransform = targetComponent.targetEntity.Get<ModelComponent>().modelTransform;
                var direction = (targetTransform.position - modelComponent.modelTransform.position).normalized;
                modelComponent.modelTransform.position += direction * moveSpeedComponent.speed * Time.deltaTime;
            }
        }
    }
}