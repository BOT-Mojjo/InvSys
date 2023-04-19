using System;
using System.IO;
// using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;

        
RootObject.ItemSchemaInit();
InvLogic Inventory = new();

Console.CursorVisible = false;
Console.Title = "Inventory Prototype";
// string untangleType = "Potion";
// string[] untangle = File.ReadAllLines(@".\Items\"+ untangleType + ".txt");
// foreach(string item in untangle)
// {
//     if(item[0] == '/')
//     {
//         continue;
//     }
//     string[] itemData = item.Split("|");
//     RootObject tempItem = new Potion(itemData[1], untangleType, itemData[0], itemData[2], int.Parse(itemData[7]), new(int.Parse(itemData[3]), int.Parse(itemData[4]), int.Parse(itemData[5]), int.Parse(itemData[6])));
//     if(!RootObject.itemSchema.ContainsKey(tempItem.Type)) RootObject.itemSchema.Add(tempItem.Type, new Dictionary<string, RootObject>());
//     RootObject.itemSchema[tempItem.Type].Add(tempItem.Name, tempItem);

// }



// var testInvSchema = new Dictionary<string, RootObject>();
// RootObject.itemSchema.TryGetValue("Potion", out testInvSchema);
// Potion[] potionBelt = new Potion[7];
// potionBelt[0] = (Potion) testInvSchema["Minor Healing"];

// var options = new JsonSerializerOptions
// {
//     IncludeFields = true,
// };
// string file = JsonSerializer.Serialize<Dictionary<string, RootObject>>(RootObject.itemSchema[untangleType], options);
// File.WriteAllText(@".\Items\"+ untangleType + ".json", file);

// See https://aka.ms/new-console-template for more information

// Console.ReadLine();
while(true)
{
    Inventory.actionInventory();
}