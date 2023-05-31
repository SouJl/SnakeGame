using Snake_Game.Interfaces;

namespace Snake_Game.Abstractions
{
    public abstract class AbstractTail: ITail
    {
        private IHead _head;
        private ITail _nextTail;

        public IHead Head { get => _head; set => _head = value; }
        public ITail NextTail { get => _nextTail; set => _nextTail = value; }
        
        public int Index { get; set; }

        public AbstractTail(IHead head)
        {
            Head = head;
        }

        public abstract void Add(ITail tail);

        public abstract void MoveNext();
    }
}
