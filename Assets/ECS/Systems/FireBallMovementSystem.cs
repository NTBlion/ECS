using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class FireBallMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, RigidBodyComponent, ModelComponent> _movableFilter;

        public void Run()
        {
            foreach (var i in _movableFilter)
            {
                ref var movableComponent = ref _movableFilter.Get1(i);
                ref var rigidbodyComponent = ref _movableFilter.Get2(i);
                ref var modelComponent = ref _movableFilter.Get3(i);

                rigidbodyComponent.rigidbody.AddForce(
                    modelComponent.modelTransform.forward * movableComponent.speed * Time.deltaTime,
                    ForceMode.VelocityChange);
            }
        }
    }
}