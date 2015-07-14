namespace RefactorIfStatements
{
    using System;

    internal class RefactorCells
    {
        public static void MovementGenerator(int x, int y, bool IsCellFree)
        {
            const int MinX = 0;
            const int MaxX = 100;
            const int MinY = 0;
            const int MaxY = 100;
            bool InRange = (x >= MinX && y >= MinY) && (x <= MaxX && y <= MaxY);

            if (IsCellFree && InRange)
            {
                VisitCell();
            }
        }
        private static void VisitCell()
        {
            Console.WriteLine("Cell is visited");
        }
    }
}
