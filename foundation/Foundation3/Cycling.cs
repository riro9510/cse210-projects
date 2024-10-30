class Cycling:Activity{
    private double _speed;
    public Cycling(double speed,int activityDuration):base(activityDuration){
        _speed = speed;
    }
      public override  String DistanceActivity(){
        double distance = (Duration/20)*_speed;
        return $"Distance {distance:F2} km";
     }
    public  override String SpeedActivity(){
        return $"Speed: {_speed:F2} kph";
    }
    public  override String PaceActivity(){
        double pace = 60/_speed;
        return $"Pace: {pace:F2} min per km";
    }
}
    