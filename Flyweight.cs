namespace Lab_6;

using System;
using System.Collections.Generic;

public class Character
{
    private char _symbol;
    private string _font;
    private int _fontSize;

    public Character(char symbol, string font, int fontSize)
    {
        _symbol = symbol;
        _font = font;
        _fontSize = fontSize;
    }

    public void Draw(int x, int y)
    {
        Console.WriteLine($"'{_symbol}' { _font} { _fontSize} at ({x},{y})");
    }
}

public class CharacterFactory
{
    private Dictionary<string, Character> _cache = new();

    public Character Get(char s, string f, int size)
    {
        string key = $"{s}_{f}_{size}";

        if (!_cache.ContainsKey(key))
        {
            _cache[key] = new Character(s, f, size);
            Console.WriteLine("Создан: " + key);
        }

        return _cache[key];
    }
}