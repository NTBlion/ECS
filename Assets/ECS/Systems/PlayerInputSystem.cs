using System;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<DirectionComponent> _directionFilter = null;

        private float _moveX;
        private float _moveZ;
        
        public void Run()
        {
            SetDirection();
            
            foreach (var i in _directionFilter)
            {
                ref var directionComponent = ref _directionFilter.Get1(i);
                ref var direction = ref directionComponent.Direction;

                direction.x = _moveX;
                direction.z = _moveZ;
            }
        }

        private void SetDirection()
        {
            _moveX = Input.GetAxis("Horizontal");
            _moveZ = Input.GetAxis("Vertical");
        }
    }
}