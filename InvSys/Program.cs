using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
int partyCoins = 89;

List<RootObject> MiscInv = new();
Potion[] potionBelt = new Potion[7];

var testInvSchema = new Dictionary<string, RootObject>();
RootObject.itemSchema.TryGetValue("Potion", out testInvSchema);
potionBelt[0] = (Potion) testInvSchema["Minor Healing"];
// Potion[] potionBelt = new Potion[7];
// for(int i = 0; i < potionBelt.Length; i++)
// {
//     potionBelt[i] = RootObject.itemSchema["Potion"]["Empty"];
// }

// string untangleType = "";
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
    actionInventory();
}
// Methods

void actionInventory()
{
    bool ongoing = true;
    while (ongoing == true){
        Console.Clear();
        drawInventory();
        int openedInventory = Menu.StrToInt(Console.ReadLine());
        if(openedInventory>5 || openedInventory<1){                    
            ongoing = Menu.GoBack();
        }
        Console.Clear();
        switch (openedInventory){
            // case 1:
            //     // actionWeaponsInventory(player);
            //     break;
            // case 2:
            //     // actionArmourInventory(player);
            //     break;
            case 3:
                actionPotionsInventory();
                break;
            // case 4:
            //     // actionMiscellaneousInv(player);
            //     break;
            // case 5:
            //     // actionSpellInventory(player);
            //     break;
            default:
            Menu.TextBox("Option not in use.");
            break;
        } 
    }
}

void drawInventory(){
    string tempCoins = partyCoins.ToString().PadLeft(4, '0');
    Menu.TextBox("(--==Inventory==--) 1:/Weapons 2:/Armour 3:Potions 4:/Miscellaneous 5:/Spells Coins:" + tempCoins, "equal");
    // mFunc.BoxLine("1:Weapons 2:Armour", windowWidth, "spread");
    // mFunc.BoxLine("3:Potions 4:Miscellaneous", windowWidth, "spread");
    // mFunc.BoxLine("5:Spells Coins:" + tempCoins, windowWidth, "spread");
    // mFunc.BoxBorder(windowWidth);
    // Console.WriteLine();
}

void actionPotionsInventory(){
    bool ongoing = true;
    while(ongoing == true){
        Console.Clear();
        Menu.BoxBorder();
        Menu.BoxLine("--=|Potion Belt|=--", "equal");
        for (int i = 0; i < potionBelt.Length; i++)
        {
            Menu.BoxLine($"Potion slot {i+1}: {potionBelt[i].Name}");
        }
    }
        // mFunc.BoxBorder(windowWidth);
        // mFunc.BoxLine("--=Potion Belt=--", windowWidth, "equal");
        // for(int i = 0; i < 7; i++){
        //     Console.WriteLine($"| Potion slot {i+1}: {InvLists[player].FetchPotionName(i)}".PadRight(windowWidth-1)+"|");
        // }
        // mFunc.BoxBorder(windowWidth);
    //     Console.WriteLine(mFunc.PadEqual("'Move' to move potions around", windowWidth));
    //     Console.WriteLine(mFunc.PadEqual("'Use' to use a potion", windowWidth));
    //     answer=Console.ReadLine().ToLower();
    //     if(answer == "move"){
    //         int[] temp = new int[4];
    //         Console.Clear();
    //         mFunc.BoxBorder(windowWidth);
    //         Console.WriteLine("|        --=Potion Belt=--        |");
    //         for(int i = 0; i < 7; i++){
    //             Console.WriteLine($"| Potion slot {i+1}: {InvLists[player].FetchPotionName(i)}".PadRight(windowWidth-1)+"|");
    //         }
    //         mFunc.BoxBorder(windowWidth);
    //         Console.WriteLine();
    //         Console.WriteLine("            Move Potion");
    //         temp[0]=mFunc.StrToInt(Console.ReadLine())-1;
    //         Console.WriteLine("              To Slot");
    //         temp[1]=mFunc.StrToInt(Console.ReadLine())-1;
    //         temp[2]=InvLists[player].potionInventory[temp[0],0];  //puts pot 1 into temp storage
    //         temp[3]=InvLists[player].potionInventory[temp[0],1];
    //         InvLists[player].potionInventory[temp[0],0] = InvLists[player].potionInventory[temp[1],0]; //moves pot 2 into pot 1s old place
    //         InvLists[player].potionInventory[temp[0],1] = InvLists[player].potionInventory[temp[1],1];
    //         InvLists[player].potionInventory[temp[1],0] = temp[2];  // moves pot 1 from storage int pot 2s old place
    //         InvLists[player].potionInventory[temp[1],1] = temp[3];

    //         } else if(acted == true && answer=="use" && Fight.ongoing == true){
    //             Console.Clear();
    //             mFunc.TextBox("You've already used the inventory this turn. Your time is running out.", windowWidth);
    //             Console.ReadLine();
    //         } else if(answer == "use"){   // using potions
    //             bool ongoing1 = true;
    //             Console.Clear();
    //             mFunc.BoxBorder(windowWidth);
    //             Console.WriteLine("|  --=What potion do you Use?=--  |");
    //             for(int i = 0; i < 7; i++){
    //             Console.WriteLine($"| Potion slot {i+1}: {InvLists[player].FetchPotionName(i)}".PadRight(windowWidth-1)+"|");
    //         }
    //         mFunc.BoxBorder(windowWidth);
    //         while(ongoing1){
    //             int potionUsed = mFunc.StrToInt(Console.ReadLine());
    //             if(potionUsed>0 && potionUsed<8){  //a potion is used
    //                 potionUsed--; //nudges the variable so it lines up with the array, since it starts at 0 and the meny at 1.
    //                 if(InvLists[player].FetchPotionName(potionUsed)=="Empty"){
    //                     mFunc.TextBox("That vial is empty.", windowWidth);
    //                     Console.ReadLine();
    //                     ongoing1 = false;
    //                 } else {
    //                     int temp2;
    //                     switch(InvLists[player].potionInventory[potionUsed,1]){  //differentiates what happens based on potion type
    //                         case 0:
    //                             temp2 = Characters[player].health;
    //                             Characters[player].health = Characters[player].health + InvLists[player].FetchHealpotAmount(potionUsed);
    //                             if(Characters[player].health>Characters[player].maxHealth){
    //                                 Characters[player].health=Characters[player].maxHealth;
    //                             }
    //                             temp2 = Characters[player].health - temp2;
    //                             mFunc.TextBox("You Regained "+temp2+"Hp!", windowWidth);
    //                             break;
    //                         case 1:
    //                             temp2 = Characters[player].mana;
    //                             Characters[player].mana = Characters[player].mana + InvLists[player].FetchManapotAmount(potionUsed);
    //                             if(Characters[player].mana>Characters[player].maxMana){
    //                                 Characters[player].mana=Characters[player].maxMana;
    //                             }
    //                             temp2 = Characters[player].mana - temp2;
    //                             mFunc.TextBox("Your Replenished "+temp2+"Mp!", windowWidth);
    //                             break;
    //                         case 2:
    //                             int[] temp3 = new int[2];
    //                             temp3 = InvLists[player].FetchBuffPotEffect(potionUsed);
    //                             Characters[player].atkBuff = Characters[player].atkBuff+temp3[0];
    //                             Characters[player].defBuff = Characters[player].defBuff+temp3[1];
    //                             mFunc.TextBox("You feel strength surge through you.", windowWidth);
    //                             break;
    //                         default:   
    //                             //Only fires if there is a potion with a type outside of the Health/Mana/Buff Trifecta, and the array doesn't spit out a failure
    //                             //honsetly never expect this to work since the file data list will throw an out of array exeption and crash
    //                             Console.WriteLine("potions are malfunctioning?");
    //                             Console.WriteLine("what did you even do?");
    //                             break;
    //                     }
    //                     InvLists[player].potionInventory[potionUsed,0] = 0;  //Removes the potion from the inventory
    //                     InvLists[player].potionInventory[potionUsed,1] = 0;
    //                     Console.ReadLine();
    //                     acted=true;
    //                     ongoing1=false;
    //                 } 
    //             } else {
    //                 ongoing1 = mFunc.GoBack(windowWidth);
    //             }
    //         }
    //     } else {
    //         ongoing = mFunc.GoBack(windowWidth);
    //     }
    // }
}

