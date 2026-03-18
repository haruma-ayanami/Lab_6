namespace Lab_6;

using System;

public interface IRenderingEngine
{
    void BeginRender();
    void EndRender();
    void Rect(float x, float y, float w, float h);
    void Ellipse(float x, float y, float rx, float ry);
    void Line(float x1, float y1, float x2, float y2);
}

public class ScreenRenderer : IRenderingEngine
{
    public void BeginRender() => Console.WriteLine("[Screen] Start");
    public void EndRender() => Console.WriteLine("[Screen] End");
    public void Rect(float x, float y, float w, float h) =>
        Console.WriteLine($"Rect {x},{y}");
    public void Ellipse(float x, float y, float rx, float ry) =>
        Console.WriteLine($"Ellipse {x},{y}");
    public void Line(float x1, float y1, float x2, float y2) =>
        Console.WriteLine($"Line {x1}->{x2}");
}

public abstract class GraphicObject : IDrawable
{
    protected IRenderingEngine _e;

    public GraphicObject(IRenderingEngine e)
    {
        _e = e;
    }

    public abstract void Draw();
}

public class Rectangle : GraphicObject
{
    float x, y, w, h;

    public Rectangle(IRenderingEngine e, float x, float y, float w, float h) : base(e)
    {
        this.x = x; this.y = y; this.w = w; this.h = h;
    }

    public override void Draw()
    {
        _e.Rect(x, y, w, h);
    }
}

public class Ellipse : GraphicObject
{
    float x, y, rx, ry;

    public Ellipse(IRenderingEngine e, float x, float y, float rx, float ry) : base(e)
    {
        this.x = x; this.y = y; this.rx = rx; this.ry = ry;
    }

    public override void Draw()
    {
        _e.Ellipse(x, y, rx, ry);
    }
}