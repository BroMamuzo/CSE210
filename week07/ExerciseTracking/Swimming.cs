
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50.0 / 1000;
    }

    public override double GetSpeed()
    {
        return GetLength() == 0
            ? 0
            : GetDistance() / GetLength() * 60;
    }

    public override double GetPace()
    {
        return GetDistance() == 0
            ? 0
            : GetLength() / GetDistance();
    }

    public override string GetActivityName()
    {
        return "Swimming";
    }
}