using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class PlayerMouseInputRotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MouseLookDirectionComponent> _mouseLookDirectionFilter = null;
        
        private float _axisX;
        
        public void Run()
        {
            GetAxis();
            
            foreach (var i in _mouseLookDirectionFilter)
            {
                ref var lookComponent = ref _mouseLookDirectionFilter.Get1(i);
                
                lookComponent.direction.x = _axisX;
            }
        }
        
        private void GetAxis()
        {
            _axisX += Input.GetAxis("Mouse X");
        }
        
    }
}