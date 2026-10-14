
public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int length, double distance)
        : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return GetLength() == 0 ? 0 : GetDistance() / GetLength() * 60;
    }

    public override double GetPace()
    {
        return GetDistance() == 0 ? 0 : GetLength() / GetDistance();
    }

    public override string GetActivityName()
    {
        return "Running";
    }
}
