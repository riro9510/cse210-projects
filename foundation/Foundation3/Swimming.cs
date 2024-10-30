class Swimming:Activity{
    private int _laps;
    public Swimming(int laps,int activityDuration):base(activityDuration){
        _laps = laps;
    }
     public override  String DistanceActivity(){
        double distance = _laps * 50 / 1000;
        return $"Distance {distance:F2} km";
     }
    public  override String SpeedActivity(){
        double speed = ((_laps * 50 / 1000.0) / (Duration / 60.0));
        return $"Speed: {speed:F2} kph";
    }
    public  override String PaceActivity(){
        double pace = (20*Duration)/_laps;
        return $"Pace: {pace:F2} min per km";
    }
}

    