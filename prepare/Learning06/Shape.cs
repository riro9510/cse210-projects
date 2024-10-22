using System.Drawing;

class abstract Shape{
string private _color;

public Shape(string color){
    _color=color;
}
public string GetColor(){
    return _color;
}
public void setColor(string color){
    _color=color;
}
public abstract float GetArea();
}