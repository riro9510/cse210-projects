class Rectangle:Shape{
    private int _lenght;
    private int _width;
    public Rectangle(string color,int lenght, int width):base(color){
        _lenght=lenght;
        _width=width;
    }
    public override float GetArea(){
    return _lenght*_width;
}
}