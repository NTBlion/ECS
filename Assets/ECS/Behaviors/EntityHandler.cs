using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ECS.Behaviors
{
    public class EntityHandler : MonoBehaviour
    {
        public EcsEntity Entity { get; private set; }

        private void Awake()
        {
            var converter = GetComponent<ConvertToEntity>();
            var entity = converter.TryGetEntity();

            if (entity != null)
            {
                Entity = (EcsEntity)entity;
            }
        }
    }
}