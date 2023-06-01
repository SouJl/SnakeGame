using Snake_Game.Abstractions;
using Snake_Game.Interfaces;
using UnityEngine;

namespace Snake_Game.Model
{
    public class TailModel : AbstractTail
    {
        private int _tailGap;    
        public int TailGap { get => _tailGap; }

        public TailModel(IHead head, Transform transform, int tailGap) : base(head, transform)
        {
            _tailGap = tailGap;
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

            Vector3 moveDirection = point - TailTransform.position;

            TailTransform.position += moveDirection * Head.Speed * Time.deltaTime;

            TailTransform.LookAt(point);

            if (NextTail != null)
                NextTail.MoveNext();
        }

        public override Vector3 GetLastPos()
        {
            if (NextTail != null)
            {
                return NextTail.GetLastPos();
            }
            else
            {
                return TailTransform.position;
            }
        }
    }
}
