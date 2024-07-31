using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, PlayerMovableComponent, DirectionComponent, PlayerTag> _movableFilter = null;

        public void Run()
        {
            foreach (var i in _movableFilter)
            {
                ref var modelComponent = ref _movableFilter.Get1(i);
                ref var movableComponent = ref _movableFilter.Get2(i);
                ref var directionComponent = ref _movableFilter.Get3(i);

                ref var direction = ref directionComponent.Direction;
                ref var transform = ref modelComponent.modelTransform;
                ref var characterController = ref movableComponent.controller;
                ref var speed = ref movableComponent.speed;

                var rawDirection = transform.right * direction.x + transform.forward * direction.z;
                characterController.Move(rawDirection * speed * Time.deltaTime);
            }
        }
    }
}