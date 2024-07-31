using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class EnemySpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag, ModelComponent> _playerFilter = null;

        private float _spawnInterval = 5f;
        private float _lastSpawnTime = 0f;

        public void Run()
        {
            float currentTime = Time.time;

            if (currentTime - _lastSpawnTime >= _spawnInterval)
            {
                _lastSpawnTime = currentTime;

                foreach (var i in _playerFilter)
                {
                    ref var playerTransform = ref _playerFilter.Get2(i);

                    Vector3 randomOffset = new Vector3(
                        Random.Range(-10, 10),
                        0f,
                        Random.Range(-10, 10)
                    );

                    Vector3 spawnPosition = playerTransform.modelTransform.position + randomOffset;

                    var enemyPrefab = Resources.Load<GameObject>("Enemy");
                    var enemyGameObject = GameObject.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    
                    var enemyEntity = _world.NewEntity();
                    enemyEntity.Get<ModelComponent>() = new ModelComponent
                        { modelTransform = enemyGameObject.transform };
                    enemyEntity.Get<MovableComponent>() = new MovableComponent() { speed = 5f };
                    enemyEntity.Get<TargetComponent>() = new TargetComponent
                        { targetEntity = _playerFilter.GetEntity(i) };
                    enemyEntity.Get<HealthComponent>() = new HealthComponent { health = 10f };
                    enemyEntity.Get<AttackComponent>() = new AttackComponent { attackRange = 2f, attackDamage = 5f };
                }
            }
        }
    }
}