class Circle{
    private int _radius;
    private double _pi = Math.PI;
    public Circle(string color,int radius):base(color){
        _radius = radius;
    }
    public override float GetArea(){
    return _pi*(_radius*_radius);
}
}