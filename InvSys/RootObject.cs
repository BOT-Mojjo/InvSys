using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class RootObject
{
    public string Name { get; protected set; }
    public string Type { get; protected set; }
    public string SubType { get; protected set; }
    public string Description { get; protected set; }
    public int Value { get; protected set;}
    public static Dictionary <string, Dictionary<string, RootObject>> itemSchema { get; private set; }

    static RootObject()
    {
        itemSchema = new Dictionary<string, Dictionary<string, RootObject>>();
        var itemFile = Directory.EnumerateFiles(@".\Items", "*.json");
        foreach(string currentFile in itemFile)
        {
            Console.WriteLine("loading " + currentFile);
            var data = JsonSerializer.Deserialize<Dictionary<string, RootObject>>(currentFile);

        }
    }

    public RootObject(string name, string type, string subType, string description, int value)
    {
        Name = name;
        Type = type;
        SubType = subType;
        Description = description;
        Value = value;
    }
    public RootObject(string name, string type, string subType, string description)
    {
        Name = name;
        Type = type;
        SubType = subType;
        Description = description;
    }
    // public RootObject(){}
}

public class Potion : RootObject
{
    public int Health { get; private set; }
    public int Mana { get; private set; }
    public int AtkBuff { get; set; }
    public int DefBuff { get; set; }
    
    public Potion(string name, string type, string subType, string description, int value, (int health, int mana, int atkBuff, int defBuff) effect = new()) : base(name, type, subType, description, value)
    {
        if(effect.health != null) Health = effect.health;
        if(effect.mana != null) Mana = effect.mana;
        if(effect.atkBuff != null) AtkBuff = effect.atkBuff;
        if(effect.defBuff != null) DefBuff = effect.defBuff;
    }
}

public class Spell : RootObject
{
    public int ManaCost { get; set; }
    public int AoE { get; set; }
    public int Damage { get; set; }
    public int AcBuff { get; set; }
    public int AtkBuff { get; set; }
    public string Target { get; set; }
    public Spell(string name, string type, string subType, string description, int value, int manaCost, int aoE, string target) : base(name, type, subType, description, value)
    {
        ManaCost = manaCost;
        AoE = aoE;
        Target = target;
    }
}

public class UtilitySpell : Spell
{
    public UtilitySpell(string name, string type, string subType, string description, int value, int manaCost, int aoE, string target) : base(name, type, subType, description, value, manaCost, aoE, target)
    {
        
    }
}

public class OffensiveSpell : Spell
{
    public OffensiveSpell(string name, string type, string subType, string description, int value, int manaCost, int aoE, string target) : base(name, type, subType, description, value, manaCost, aoE, target)
    {
        
    }
}
