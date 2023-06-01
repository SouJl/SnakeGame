using Snake_Game.Interfaces;
using UnityEngine;

namespace Snake_Game.Model
{
    public class SnakeModel: IMove
    {
        private IHead _head;

        private ITail _tail;

        public IHead Head { get => _head; }

        public ITail Tail { get => _tail; }

        public SnakeModel(IHead head)
        {
            _head = head;
        }


        public void AddTailPart(ITail tail) 
        {
            if(_tail != null) 
            {
                _tail.Add(tail);
            }
            else 
            {
               _tail = tail;
               _tail.Index = 1;
               _head.PoisitionChanged += _tail.MoveNext;
            }
        }

        public void Move(Vector3 direction)
        {
            _head.ChangePosition(direction);
        }
    }
}

