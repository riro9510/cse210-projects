class Square:Shape{
private string _side;
public Square(String color,float side):base(color){
    _side=side;
}
public override float GetArea(){
    return _side*_side;
}
}