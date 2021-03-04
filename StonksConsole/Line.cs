namespace StonksConsole
{
    class Line
    {
        private Vector2 StartPoint;
        private float Rise;

        public Line(Vector2 startPoint, float rise)
        {
            StartPoint = startPoint;
            Rise = rise;
        }
        public float GetYforX(float x)
        {
            var xDistance = x - StartPoint.X;
            float yValue = xDistance * Rise + StartPoint.Y;

            return yValue;
        }
    }
}
