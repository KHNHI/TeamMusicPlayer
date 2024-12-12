using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    internal class DoublyLinkedList
    {
        public SongNode Head { get; private set; } // Node đầu tiên
        public SongNode Tail { get; private set; } // Node cuối cùng
        public SongNode Current { get; set; }      // Node hiện tại
        public int Count { get; private set; }
    }
}
