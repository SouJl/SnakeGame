using Snake_Game.Interfaces;
using UnityEngine;

namespace Snake_Game.Abstractions
{
    public abstract class AbstractTail: ITail
    {
        private IHead _head;
        private ITail _nextTail;

        public IHead Head { get => _head; set => _head = value; }
        public ITail NextTail { get => _nextTail; set => _nextTail = value; }
        
        public int Index { get; set; }

        public Transform TailTransform { get; private set; }

        public AbstractTail(IHead head, Transform transform)
        {
            Head = head;
            TailTransform = transform;
        }

        public abstract void Add(ITail tail);
        public abstract Vector3 GetLastPos();
        public abstract void MoveNext(); 
    }
}
