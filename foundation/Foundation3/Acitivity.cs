using System.Globalization;
abstract class Activity{
    private String _date;
    private int _activyDuration;
    protected int Duration;
    public Activity(int MinutesActivity){
        _date=DateTime.Now.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
        _activyDuration=MinutesActivity;
        this.Duration=MinutesActivity;
    }
    public abstract String DistanceActivity();
    public abstract String SpeedActivity();
    public abstract String PaceActivity();

    public void GetSumary(){
        Console.WriteLine($"{DistanceActivity()} {SpeedActivity()} {PaceActivity()}");
    }
}