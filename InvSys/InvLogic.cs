using System;

public class InvLogic
{

    public InvLogic()
    {
        foreach(KeyValuePair<string, RootObject> item in RootObject.itemSchema["Miscellaneous"])
        {
            MiscInv.Add(new(item.Value, 1));
        }
        for(int i = 0; i < potionBelt.Length; i++)
        {
            potionBelt[i] = (Potion) RootObject.itemSchema["Potion"]["Empty"];
        }
        potionBelt[0] = (Potion) RootObject.itemSchema["Potion"]["Minor Healing"];
    }
    int partyCoins = 89;
    List<(RootObject Item, int Count)> MiscInv = new();
    Potion[] potionBelt = new Potion[7];
    protected Menu rootMenu = new Menu();
    public void actionInventory()
    {
        
        bool ongoing = true;
        while (ongoing == true){
            Console.Clear();
            drawInventory();
            int openedInventory = rootMenu.StrToInt(Console.ReadLine());
            if(openedInventory>5 || openedInventory<1){                    
                ongoing = rootMenu.GoBack();
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
                case 4:
                    actionMiscellaneousInv();
                    break;
                // case 5:
                //     // actionSpellInventory(player);
                //     break;
                default:
                rootMenu.TextBox("Option not in use.");
                break;
            } 
        }
    }

    public void drawInventory(){
        string tempCoins = partyCoins.ToString().PadLeft(4, '0');
        rootMenu.TextBox("(--==Inventory==--) 1:/Weapons 2:/Armour 3:Potions 4:/Miscellaneous 5:/Spells Coins:" + tempCoins, "equal");
        // mFunc.BoxLine("1:Weapons 2:Armour", windowWidth, "spread");
        // mFunc.BoxLine("3:Potions 4:Miscellaneous", windowWidth, "spread");
        // mFunc.BoxLine("5:Spells Coins:" + tempCoins, windowWidth, "spread");
        // mFunc.BoxBorder(windowWidth);
        // Console.WriteLine();
    }

    public void actionPotionsInventory(){
        bool ongoing = true;
            Console.Clear();
        while(ongoing == true){
            rootMenu.BoxBorder();
            rootMenu.BoxLine("---==|Potion Belt|=-=--", "equal");
            // for (int i = 0; i < potionBelt.Length; i++)
            // {
            //     Menu.BoxLine($"Potion slot {i+1}: {potionBelt[i].Name}", "right", true);
            // }
            // string[] temp = new string[potionBelt.Length+1];
            // for (int i = 0; i < potionBelt.Length; i++)
            // {
            //     temp[i] = $"Potion slot {i+1}: {potionBelt[i].Name}";
            // }
            // temp[potionBelt.Length] = "Go Back";
            // int activeItem = Menu.choiceList(temp, false);
            // 'Cannot convert anonymous method block to type 'string[]' because it is not a delegate type'
            // What

            List<string> things = potionBelt.Select((n, i) => {
                return $"Potion slot {i+1}: {n.Name}";
            }).ToList();

            things.Add("Go back");
            int activeItem = rootMenu.choiceList(things.ToArray(), false);


            // Menu.choiceList((string[] t) => 
            // {
            //         string[] temp = new string[potionBelt.Length+1];
            //         for (int i = 0; i < potionBelt.Length; i++)
            //         {
            //             t[i] = $"Potion slot {i+1}: {potionBelt[i].Name}";
            //         }
            //         t[potionBelt.Length+1] = "Go Back";
            //         return temp;
            //     };
            // );
            // Menu.BoxBorder();
            // int activeItem = Menu.ListInput();
            if(activeItem >= potionBelt.Length) break;
            rootMenu.BoxBorder();
            rootMenu.BoxLine("---=|"+potionBelt[activeItem].Name+"|=---", "equal");
            rootMenu.BoxLine(potionBelt[activeItem].Description, "equal");
            rootMenu.BoxBorder();

            if(potionBelt[activeItem].Name == "Empty")
            {
                rootMenu.choiceList(new string[]{"Go Back"});
                Console.Clear();
                continue;
            }

            int action = rootMenu.choiceList(new string[]{"Move", "Use", "Go Back"});
            switch(action)
            {
                case(0):
                break;
                case(1):
                potionBelt[activeItem] = (Potion) RootObject.itemSchema["Potion"]["Empty"];
                rootMenu.TextBox("yum");
                Console.ReadKey();
                break;
            }

            Console.Clear();
        }
    }

    void actionMiscellaneousInv()
    {
        int invLength = MiscInv.Count();
        // B'oring.
        Console.Clear();
        while(true)
        {
            rootMenu.BoxBorder();
            rootMenu.BoxLine("Misc Inv", "equal");
            string[] temp = new string[MiscInv.Count+1];
            for (int i = 0; i < MiscInv.Count; i++)
            {
                temp[i] = $"Potion slot {i+1}: {MiscInv[i].Item.Name}";
            }
            temp[MiscInv.Count] = "Go Back";
            int activeItem = rootMenu.choiceList(temp, false);
            if(activeItem >= MiscInv.Count) break;
            rootMenu.BoxBorder();
            rootMenu.BoxLine("---=|"+MiscInv[activeItem].Item.Name+"|=---", "equal");
            rootMenu.BoxLine(MiscInv[activeItem].Item.Description, "equal");
            rootMenu.BoxBorder();
            rootMenu.choiceList(new string[]{"Go Back"});
            Console.Clear();
        }
    }
}