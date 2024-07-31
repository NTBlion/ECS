using System;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Behaviors
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField] private EntityHandler _handler;
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out EntityHandler handler))
            {
               ref var hitComponent = ref _handler.Entity.Get<HitComponent>();
               hitComponent.Entity = handler.Entity;
            }
        }
    }
}