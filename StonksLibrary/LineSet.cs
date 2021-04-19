using System.Collections.Generic;

namespace StonksLibrary
{
    class LineSet
    {
        public List<Line> Lines = new List<Line>();
        public void AddLine(Vector2 startPoint, float rise)
        {
            if (Lines == null)
                Lines = new List<Line>();

            Lines.Add(new Line(startPoint, rise));
        }
    }
}
