using ECS.Components;
using Leopotam.Ecs;

namespace ECS.Systems
{
    sealed class HitSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<HitComponent> _hitComponent;
        
        public void Run()
        {
            foreach (var i in _hitComponent)
            {
                ref var hitComponent = ref _hitComponent.Get1(i);
                hitComponent.Entity.Get<DamageComponent>();
            }
        }
    }
}