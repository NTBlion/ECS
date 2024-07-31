using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct PlayerMovableComponent
    {
        public float speed;
        public CharacterController controller;
    }
}