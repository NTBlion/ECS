using System;
using ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ECS
{
    public class EcsGameStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();
            
            AddInjections();
            AddOneFrames();
            AddSystems();
            
            _systems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null)
                return;

            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }

        private void AddSystems()
        {
            _systems.
                Add(new PlayerMouseInputSystem()).
                Add(new PlayerInputSystem()).
                Add(new PlayerMouseLookSystem()).
                Add(new MovementSystem());
        }

        private void AddInjections()
        {
        }

        private void AddOneFrames()
        {
        }
    }
}