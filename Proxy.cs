namespace Lab_6;

using System;
using System.Threading;

public interface IDrawable
{
    void Draw();
}

public interface IImage : IDrawable
{
    int GetWidth();
    int GetHeight();
}

public class HighResolutionImage : IImage
{
    private string _file;
    private int _w, _h;

    public HighResolutionImage(string file)
    {
        _file = file;
        Console.Write("Загрузка... ");
        Thread.Sleep(1000);
        _w = 1920; _h = 1080;
        Console.WriteLine("готово");
    }

    public void Draw() => Console.WriteLine("Draw " + _file);
    public int GetWidth() => _w;
    public int GetHeight() => _h;
}

public class ImageProxy : IImage
{
    private string _file;
    private HighResolutionImage _real;

    public ImageProxy(string file)
    {
        _file = file;
    }

    private void Load()
    {
        if (_real == null)
            _real = new HighResolutionImage(_file);
    }

    public void Draw()
    {
        Load();
        _real.Draw();
    }

    public int GetWidth()
    {
        Load();
        return _real.GetWidth();
    }

    public int GetHeight()
    {
        Load();
        return _real.GetHeight();
    }
}