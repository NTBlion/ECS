using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct MovableComponent
    {
        public float Speed;
        public CharacterController Controller;
    }
}