using System;

public class CSharpExam : Exam
{
    private const int MinScore = 0;
    private const int MaxScore = 100;
    private const string CommmentScore = "Exam results calculated by score.";

    public CSharpExam(int score)
    {
        if (score < MinScore)
        {
            throw new NullReferenceException("Score must be greater or equal to " + MinScore);
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult Check()
    {
        if (this.Score < MinScore || this.Score > MaxScore)
        {
            throw new ArgumentOutOfRangeException("Score (c# exam) must be within f0 and 100");
        }
        else
        {
            return new ExamResult(this.Score, MinScore, MaxScore, CommmentScore);
        }
    }
}
