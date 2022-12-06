using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake_Game.Interfaces
{
    public interface IHead
    {
        Transform Transform { get; set; }
        
        float Speed { get; set; }

        List<Vector3> HeadPositions { get; set; }

        Action PoisitionChanged { get; set; }

        void ChangePosition(Vector3 position);
    }
}
