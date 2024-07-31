using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    sealed class EnemyAttackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, AttackComponent, TargetComponent, HealthComponent> _enemyFilter = null;
        private readonly EcsFilter<PlayerTag, ModelComponent, HealthComponent> _playerFilter = null;

        private float _attackCooldown = 1f;
        private float _lastAttackTime;

        public void Run()
        {
            float currentTime = Time.time;

            if (_playerFilter.GetEntitiesCount() == 0)
            {
                return;
            }

            var playerEntity = _playerFilter.GetEntity(0);
            ref var playerModel = ref _playerFilter.Get2(0);
            ref var playerHealth = ref _playerFilter.Get3(0);

            foreach (var enemyIndex in _enemyFilter)
            {
                ref var enemyModel = ref _enemyFilter.Get1(enemyIndex);
                ref var attackComponent = ref _enemyFilter.Get2(enemyIndex);
                ref var targetComponent = ref _enemyFilter.Get3(enemyIndex);

                var targetEntity = targetComponent.targetEntity;

                if (targetEntity == playerEntity)
                {
                    float distance = Vector3.Distance(enemyModel.modelTransform.position, playerModel.modelTransform.position);

                    if (distance <= attackComponent.attackRange)
                    {
                        if (currentTime - _lastAttackTime >= _attackCooldown)
                        {
                            playerHealth.health -= attackComponent.attackDamage;
                            if (playerHealth.health < 0f)
                                playerHealth.health = 0f;

                            _lastAttackTime = currentTime;
                            
                            Debug.Log($"Player's remaining health after attack: {playerHealth.health}");
                        }
                    }
                }
            }
        }
    }
}
