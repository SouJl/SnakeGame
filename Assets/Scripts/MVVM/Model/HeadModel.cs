using Snake_Game.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake_Game.Model
{
    public class HeadModel : IHead
    {
        private Transform _transform;
        private float _speed;

        public Transform Transform { get => _transform; set => _transform = value; }
        
        public float Speed { get => _speed; set => _speed = value; }
        
        public List<Vector3> HeadPositions { get; set; }

        public Action PoisitionChanged { get; set; }

        public HeadModel(Transform transform, float speed) 
        {
            Transform = transform;
            Speed = speed;
            HeadPositions = new List<Vector3>();
        }

        public void ChangePosition(Vector3 position)
        {

            _transform.position += _transform.forward * Speed * Time.deltaTime;

            _transform.Rotate(Vector3.up * position.x * 180 * Time.deltaTime);

            HeadPositions.Insert(0, _transform.position);

            PoisitionChanged?.Invoke();
        }
    }
}
