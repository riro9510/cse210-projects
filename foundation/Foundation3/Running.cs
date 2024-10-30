class Running:Activity{
    private double _distance;
    public Running(double distance,int activityDuration):base(activityDuration){
        _distance = distance;
    }
     public override  String DistanceActivity(){
        return $"Distance {_distance:F2} km";
     }
    public  override String SpeedActivity(){
        double speed = (_distance /Duration) * 60;
        return $"Speed: {speed:F2} kph";
    }
    public  override String PaceActivity(){
        double pace = Duration/_distance;
        return $"Pace: {pace:F2} min per km";
    }

}