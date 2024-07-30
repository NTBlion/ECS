using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct MouseLookDirectionComponent
    {
        [HideInInspector] public Vector2 direction;
        [Range(0, 2)] public float mouseSensitivity;
    }
}