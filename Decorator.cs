namespace Lab_6;

using System;
using System.Collections.Generic;

public class DrawableDecorator : IDrawable
{
    protected IDrawable _obj;

    public DrawableDecorator(IDrawable obj)
    {
        _obj = obj;
    }

    public virtual void Draw()
    {
        _obj.Draw();
    }
}

public class Border : DrawableDecorator
{
    public Border(IDrawable o) : base(o) { }

    public override void Draw()
    {
        base.Draw();
        Console.Write(" +Border");
    }
}

public class Shadow : DrawableDecorator
{
    public Shadow(IDrawable o) : base(o) { }

    public override void Draw()
    {
        base.Draw();
        Console.Write(" +Shadow");
    }
}

public class Transparency : DrawableDecorator
{
    public Transparency(IDrawable o) : base(o) { }

    public override void Draw()
    {
        base.Draw();
        Console.Write(" +Alpha");
    }
}

public class Page
{
    private List<IDrawable> items = new();

    public void Add(IDrawable d) => items.Add(d);

    public void Render()
    {
        foreach (var i in items)
        {
            i.Draw();
            Console.WriteLine();
        }
    }
}

public class Document
{
    private List<Page> pages = new();
    private IRenderingEngine _e;

    public Document(IRenderingEngine e)
    {
        _e = e;
    }

    public Page AddPage()
    {
        var p = new Page();
        pages.Add(p);
        return p;
    }

    public void Render()
    {
        _e.BeginRender();

        foreach (var p in pages)
            p.Render();

        _e.EndRender();
    }
}