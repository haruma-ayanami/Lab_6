namespace Lab_6;

using System;

class Program
{
    static void Main()
    {
        // Flyweight
        var f = new CharacterFactory();
        var a1 = f.Get('A', "Arial", 12);
        var a2 = f.Get('A', "Arial", 12);

        a1.Draw(1, 1);
        a2.Draw(2, 2);

        // Proxy
        IImage img = new ImageProxy("pic.png");
        img.Draw();

        // Bridge + Decorator
        var engine = new ScreenRenderer();
        var doc = new Document(engine);

        var page = doc.AddPage();

        IDrawable r = new Rectangle(engine, 10, 10, 50, 50);
        r = new Border(new Shadow(r));

        page.Add(r);

        doc.Render();
    }
}