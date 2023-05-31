using System.Collections.Generic;
using UnityEngine;

namespace Snake_Game.Interfaces
{
    public interface ITail
    {
        int Index { get; set; }

        IHead Head { get; set; }
        
        ITail NextTail { get; set; }

        void Add(ITail tail);

        void MoveNext();
    }
}
