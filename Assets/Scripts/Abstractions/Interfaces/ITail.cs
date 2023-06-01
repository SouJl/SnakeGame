using UnityEngine;

namespace Snake_Game.Interfaces
{
    public interface ITail
    {
        Transform TailTransform { get; }

        int Index { get; set; }

        IHead Head { get; set; }
        
        ITail NextTail { get; set; }

        void Add(ITail tail);

        Vector3 GetLastPos();
        void MoveNext();
    }
}
