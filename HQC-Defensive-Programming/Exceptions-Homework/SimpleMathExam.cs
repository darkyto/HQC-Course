using System;

public class SimpleMathExam : Exam
{
    private const int MinSolved = 0;
    private const int MaxSolved = 10;
    private const int LowResults = 2;
    private const int MidResults = 4;
    private const int TopResults = 7;
    private int problemsSolved;
    private string comment;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved 
    {
        get 
        {
            if (this.problemsSolved < MinSolved)
            {
                return MinSolved;
            }
            else if (this.problemsSolved > MaxSolved)
            {
                return MaxSolved;
            }
            else 
            {
                return this.problemsSolved;
            }
        }

        private set
        {
            if (value > MaxSolved)
            {
                throw new ArgumentOutOfRangeException("Maximum solved tast can not exceed the numbers of tasks");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved <= LowResults)
        {
            this.comment = "Bad result: nothing done.";
        }
        else if (this.ProblemsSolved <= MidResults)
        {
            this.comment = "Good result: average tasks done.";
        }
        else if (this.ProblemsSolved <= TopResults)
        {
            this.comment = "Very good result: most tasks done.";
        }
        else if (this.ProblemsSolved > TopResults)
        {
            this.comment = "Excellent result: all tasks done.";
        }

        return new ExamResult(this.ProblemsSolved, MinSolved, MaxSolved, this.comment);
    }
}
