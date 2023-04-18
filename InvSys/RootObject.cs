using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public class RootObject
{
    public string Name { get; protected set; }
    public string Type { get; protected set; }
    public string SubType { get; protected set; }
    public string Description { get; protected set; }
    public int Value { get; protected set;}
    public static Dictionary <string, Dictionary<string, RootObject>> itemSchema = new();
    public static void ItemSchemaInit()
    {
        string[] itemFile = Directory.EnumerateFiles(@".\Items", "*.json").ToArray();

        //Misc Iteam init
        Console.WriteLine("loading " + itemFile[0]);
        string data = File.ReadAllText(itemFile[0]);
        RootObject.itemSchema.Add(itemFile[0].Substring(8, itemFile[0].Length-13), JsonConvert.DeserializeObject<Dictionary<string, RootObject>>(data));

        //Potions Init
        Console.WriteLine("loading " + itemFile[1]);
        data = File.ReadAllText(itemFile[1]);
        var pots = new Dictionary<string, Potion>(JsonConvert.DeserializeObject<Dictionary<string, Potion>>(data));
        RootObject.itemSchema.Add(itemFile[1].Substring(8, itemFile[1].Length-13), pots);
    }
    static RootObject()
    {
        // itemSchema = new Dictionary<string, Dictionary<string, RootObject>>();
        // var itemFile = Directory.EnumerateFiles(@".\Items", "*.json");
        // foreach(string currentFile in itemFile)
        // {
        //     Console.WriteLine("loading " + currentFile);
        // }
        // itemSchema.Add("test", new Dictionary<string, RootObject>());
        // itemSchema.Add("Potion", InitPotion("Potion"));

        //TODO: It's so funny I can't initialize the itemSchema in the RootObject Initializer because Rootobject isn't initialized yet. :)
    }
    [JsonConstructor]
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
    //Uses System.Text.JsonSerializer, not newtonsoft.Json Serializer
    // static public Dictionary<string, RootObject> InitPotion(string fileLocation)
    // {
    //     if(fileLocation != "Potion") throw new Exception();
    //     Dictionary<string, Potion> data = JsonSerializer.Deserialize<Dictionary<string, Potion>>(File.ReadAllText("./Items/"+fileLocation+".json"));
    //     Dictionary<string, RootObject> polyData = new();
    //     foreach (var pot in data)
    //     {
    //         polyData.Add(pot.Key, pot.Value);
    //     }
    //     return polyData;
    // }
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
