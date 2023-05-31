using Snake_Game.Abstractions;
using Snake_Game.Interfaces;
using UnityEngine;

namespace Snake_Game.Model
{
    public class TailModel : AbstractTail
    {
        private Transform _transform;
        private int _tailGap;
       
        public Transform Transform { get => _transform; set => _transform = value; }
        public int TailGap { get => _tailGap; set => _tailGap = value; }

        public TailModel(IHead head, Transform transform, int tailGap) : base(head)
        {
            Transform = transform;
            TailGap = tailGap;
        }

        public override void Add(ITail tail)
        {
            if(NextTail != null)
            {
                NextTail.Add(tail);
            }
            else
            {
                NextTail = tail;
                NextTail.Index = Index + 1; 
            }
        }

        public override void MoveNext()
        {
            Vector3 point = Head.HeadPositions[Mathf.Min(Index * TailGap, Head.HeadPositions.Count - 1)];

            Vector3 moveDirection = point - Transform.position;
            
            Transform.position += moveDirection * Head.Speed * Time.deltaTime;

            Transform.LookAt(point);

            if (NextTail != null)
                NextTail.MoveNext();
        }
    }
}
