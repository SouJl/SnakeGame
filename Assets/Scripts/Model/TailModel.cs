using Snake_Game.Interfaces;
using UnityEngine;

namespace Snake_Game.Model
{
    public class TailModel : AbstractTailModel
    {
        private Transform _transform;

        public Transform Transform { get => _transform; set => _transform = value; }

        public TailModel(IHead head, Transform transform) : base(head)
        {
            Transform = transform;
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
            Vector3 point = Head.HeadPositions[Mathf.Min(Index * 120, Head.HeadPositions.Count - 1)];

            Vector3 moveDirection = point - Transform.position;
            
            Transform.position += moveDirection * Head.Speed * Time.deltaTime;

            Transform.LookAt(point);

            if (NextTail != null)
                NextTail.MoveNext();
        }
    }
}
