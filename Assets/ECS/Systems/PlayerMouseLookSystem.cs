using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class PlayerMouseLookSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, MouseLookDirectionComponent> _mouseLookFilter = null;

        private readonly Quaternion _startTransformRotation = Quaternion.identity;

        public void Run()
        {
            foreach (var i in _mouseLookFilter)
            {
                ref var model = ref _mouseLookFilter.Get1(i);
                ref var lookComponent = ref _mouseLookFilter.Get2(i);

                var axisX = lookComponent.direction.x;

                var rotateX =
                    Quaternion.AngleAxis(axisX, Vector3.up * Time.deltaTime * lookComponent.mouseSensitivity);

                model.modelTransform.rotation = _startTransformRotation * rotateX;
            }
        }
    }
}