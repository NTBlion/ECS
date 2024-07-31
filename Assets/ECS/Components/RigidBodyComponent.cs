using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct RigidBodyComponent
    {
        public Rigidbody rigidbody;
    }
}