using System;
using System.Collections.Generic;

public class Menu{ //Formerly miscFunctions
    static int windowWidth = 35;
    static Menu()
    {
        string answer;
        Console.Clear();
        while(true){
            Menu temp = new();
            temp.TextBox("Please Choose a Textbox size. Recommended 35-55. Size is measured in the amount of characters. Note: Anything that isn't a number will be treated as a 0.");
            windowWidth = temp.StrToInt(Console.ReadLine());
            if(windowWidth < 20){
                temp.TextBox("A size less than 20 may cause runtime issues. The game will break, skipping the offending textbox. Understood? y/n");
                answer = Console.ReadLine().ToLower();
                if(answer == "y" || answer == "yes"){

                } else {
                    windowWidth = 35;
                }
            }
            temp.TextBox("Is this size acceptable? y/n");
            answer = Console.ReadLine().ToLower();
            if(answer == "y" || answer == "yes"){
                break;
                // Shops.windowWidth = windowWidth;
                // Inventory.windowWidth = windowWidth;
                // Fight.windowWidth = windowWidth;
            } else {
                windowWidth = 35;
            }   
        }
    }
    public Random genRandom = new Random();

    public int StrToInt(string text){
        int ParsedNumber;                                     //checks if the string can be used with int.parse
        int.TryParse(text, out ParsedNumber);                 //and if it can it does, otherwise it returns a 0
        return ParsedNumber;                                  //I did this because i didn't like how it worked, though at this point it might just be better to use eit as intended.
        
    }
    public bool GoBack(){        //Had to use this identical funciton for so many loops, so i made it a function
        TextBox("Go back? y/n");
        string answer = Console.ReadLine().ToLower();
        if(answer == "y" || answer == "yes"){
            return false;
        } else {
            return true;
        }
    } 

    public string PadEqual(string str, int desiredLength){   // if i have padRight and padLeft, why cant i have PadEqual
        string paddedString=str.PadLeft(((desiredLength-str.Length)/2)+str.Length);//Pads the left side, half of the total pad
        return paddedString.PadRight(desiredLength);                               //Pads the right side, other half of the total pad
    }

    // public string MiscInvList(string name, string type = "all", string slotType = "", bool count = false, string[] extraText = null){
    //     List<int> invType = MiscInvListType(type);
    //     bool ongoing = true;
    //     int invLength = invType.Count;
    //     string answer;
    //     int page=0;                                    //Keeps track of what page you're on
    //     int pageTotal=(invLength/12);                  //Keeps track of how many pages your inventory has
    //     while(ongoing){
    //         Console.Clear();
    //         BoxBorder(windowWidth);
    //         BoxLine("--={name}=--", windowWidth, "equal");
    //         if(invLength == 0){
    //         BoxLine("-=Empty=-", windowWidth, "equal");   //if there are no items in Misc inv
    //         } else if(count==false){    //if there are items in MiscInv && we don't want the number of items
    //             BoxLine("Page: "+(page+1), windowWidth);
    //             if(invLength<12){  //if there are less than 12/1 page of items. 1 page = 12 items
    //                 for(int i = 0; i < invLength; i++){
    //                     BoxLine($"{slotType}{i+1}: {InventoryLists.FetchMiscName(invType[i])}", windowWidth);
    //                 }
    //             } else if(invLength-page*12>12){   //when there are more than 12 items but not on the last page
    //                 for(int i = 0; i < 12; i++){
    //                     BoxLine($"{slotType}{i+1+(page*12)}: {InventoryLists.FetchMiscName(invType[i]+(page*12))}", windowWidth);
    //                 }
    //             } else {    //more than 12 items, on the last page. Have to make it like this to keep the var within List lenght
    //                 for (int i = 0; i < invLength%12; i++){
    //                     BoxLine($"{slotType}{i+1+(page*12)}: {InventoryLists.FetchMiscName(invType[i]+(page*12))}", windowWidth);
    //                 }
    //             }
    //         } else if(count==true){    //if there are items in MiscInv && we do want the number of items
    //             BoxLine("Page: "+(page+1), windowWidth);
    //             if(invLength<12){  //if there are less than 12/1 page of items. 1 page = 12 items
    //                 for(int i = 0; i < invLength; i++){
    //                     BoxLine($"{slotType}{i+1}: {InventoryLists.FetchMiscName(invType[i])} * {InventoryLists.FetchMiscAmount(invType[i])}", windowWidth);
    //                 }
    //             } else if(invLength-page*12>12){   //when there are more than 12 items but not on the last page
    //                 for(int i = 0; i < 12; i++){
    //                     BoxLine($"{slotType}{i+1+(page*12)}: {InventoryLists.FetchMiscName(invType[i]+(page*12))} * {InventoryLists.FetchMiscAmount(invType[i]+(page*12))}", windowWidth);
    //                 }
    //             } else {    //more than 12 items, on the last page. Have to make it like this to keep the var within List lenght
    //                 for (int i = 0; i < invLength%12; i++){
    //                     BoxLine($"{slotType}{i+1+(page*12)}: {InventoryLists.FetchMiscName(invType[i]+(page*12))} * {InventoryLists.FetchMiscAmount(invType[i]+(page*12))}", windowWidth);
    //                 }
    //             }
    //         }
    //         BoxBorder(windowWidth);
    //         if(invLength == 0){
    //             answer = Console.ReadLine();
    //         } else {
    //             string[] temp = MovePage(page, pageTotal, windowWidth, extraText).Split("|");
    //             if(temp[0] == "p"){
    //                 page = int.Parse(temp[1]);
    //             } else {
    //                 answer = temp[1];
    //             return answer;
    //             }
    //         }
    //     }
    //     return "no";
    // }

    // public List<int> MiscInvListType(string type = "all"){  // was gonna need more than 3 duplicates of this code, therefore it is now a function
    //     List<int> invType = new List<int>();
    //     for(int i = 0; i < InventoryLists.miscInventory.Count; i++){
    //         if(type == "all"){
    //             invType.Add(i);
    //         }else if(InventoryLists.FetchMiscType(i)==type){
    //             invType.Add(i);
    //         }
    //     }
    //     return invType;
    // }

    // public string MovePage(int page, int pageTotal, string[] extraText = null){
    //     if(pageTotal > 0){
    //         Console.WriteLine(PadEqual("Move between pages", windowWidth));
    //         Console.WriteLine(PadEqual("by typing '<' or '>'", windowWidth));
    //         if(extraText != null){
    //             for(int i = 0; i < extraText.Length; i++){
    //                 Console.WriteLine(PadEqual(extraText[i], windowWidth));
    //             }
    //         }
    //     }
    //     string answer = Console.ReadLine();   // a|{answer} something that isn't moving between pages
    //     if(pageTotal > 0 && (answer == "<" || answer == ">")){
    //         if(answer == "<"){
    //             if(page == 0){
    //                 Console.WriteLine("You're on the first page.");
    //                 Console.ReadKey();
    //             } else {
    //                 page--;
    //                 return $"p|{page}";
    //             }
    //         } else if(answer == ">"){
    //             if(page == pageTotal){
    //                 Console.WriteLine("You're on the last page.");
    //                 Console.ReadKey();
    //             } else {
    //                 page++;
    //                 return $"p|{page}";
    //             }
    //         }
    //     }
    //     return $"a|{answer}";
    // }

    bool getCorner = true;
    (int Left, int Top) Origin;
    // (int Left, int Top) CursorOffset;

    List<((int Left, int Top) position, string text)> listText = new(); //yes
    int lastPos = 0;
    int activeItem = 0;

    Stack<MenuSavestate> lastMenu = new();

    public int ListInput() //God save us all
    {   // I am assuming that it's is the latest textbox that calls this method
    Origin = Console.GetCursorPosition();
    if(lastPos == activeItem)
        {
            Console.SetCursorPosition(listText[activeItem].position.Left, listText[activeItem].position.Top);
            Console.Write(">"+listText[activeItem].text);
        }
        while(true)
        {
            ConsoleKey Input = Console.ReadKey(true).Key;
            switch(Input)
            {
                case(ConsoleKey.UpArrow):
                if(activeItem != 0) activeItem--;
                break;
                case(ConsoleKey.DownArrow):
                if(activeItem != listText.Count-1) activeItem++;
                break;
                case(ConsoleKey.Enter):
                Console.SetCursorPosition(Origin.Left, Origin.Top);
                return activeItem;
                default:
                break;
            }
            Console.SetCursorPosition(listText[lastPos].position.Left, listText[lastPos].position.Top);
            Console.Write(""+listText[lastPos].text+" ");
            Console.SetCursorPosition(listText[activeItem].position.Left, listText[activeItem].position.Top);
            Console.Write(">"+listText[activeItem].text);
            lastPos = activeItem;
        }
    }
    public void TextBox(string textInput)
    {
        TextBox(textInput, "equal");
    }   

    public void TextBox(string textInput, string padDir){
        BoxBorder();
        BoxLine(textInput, padDir);
        BoxBorder();
    }

    public void BoxBorder(){  //replaces Console.WriteLine("+------------=========------------+"); because of variable window width for non-simple text boxes
        string border = "";
        if(getCorner) 
        {
            // Origin = Console.GetCursorPosition();
            // CursorOffset = (0,0);
            listText = new();
            activeItem = 0;
            lastPos = 0;
        }
        getCorner = !getCorner;
        int thickLength = windowWidth/4;
        if(windowWidth%2 != 0 && thickLength%2 == 0){
            thickLength = thickLength + 1;
        }
        for(int i = 0; i < (windowWidth/2)-(windowWidth/4)/2; i++){
            border = border.Insert(border.Length, "-");
        }
        for(int i = 0; i < thickLength; i++){
            border = border.Insert(border.Length, "=");
        }
        while(border.Length<windowWidth){
            border = border.Insert(border.Length, "-");
        }
        border = border.Remove(0,1);
        border = border.Insert(0, "+");
        border = border.Remove(border.Length-1, 1);
        border = border.Insert(border.Length, "+");
        Console.WriteLine(border);
        

    }

    public void BoxLine(string textInput, string padDir = "right", bool setListPos = false){  // needed because of special boxes
        int weDied = 0;  //if we get stuck in an endless loop, this should stop it eventually.
        int splitTheWord = 0;
        int wordCount = 0;
        bool ongoing = true;
        bool force = false;
        List<string> text = new List<string>();

        string[] textWIP = textInput.Split(" ");
        string textInternal = "";
        while(ongoing){
            void AddTextInternal(){
                if(textInternal.Length != 0){
                    text.Add(textInternal);
                }
            }

            if(textWIP[wordCount].Contains("(")){  //TODO: FIX THE "KEEP WORDS ON ONE LINE"F UNCTION! maybe fixed? no, broke "force" split the word not functioning
                int wordCount1 = wordCount+1;      //TODO: fixed? fucking good job lad
                while(!textWIP[wordCount].Contains(")")){
                    textWIP[wordCount] = textWIP[wordCount].Insert(textWIP[wordCount].Length, " "+textWIP[wordCount1]);
                    textWIP[wordCount1] = textWIP[wordCount1].Insert(0, "½");
                    wordCount1++;
                }
                textWIP[wordCount] = textWIP[wordCount].Remove(0, 1);
                textWIP[wordCount] = textWIP[wordCount].Remove(textWIP[wordCount].Length-1, 1);
                force = true;
            }
            // if(textInternal.Length == 0){  //if it's the first "word"
            //     textInternal = textInternal.Insert(0, textWIP[wordCount]);
            //     wordCount++;
            // } else {  //otherwise it adds an " " at the beggining of a word.
            if(!textWIP[wordCount].Contains("½")){
                textInternal = textInternal.Insert(textInternal.Length, " "+textWIP[wordCount]);
            }
            wordCount++;
            //}
            
            if(textInternal.Length > windowWidth-4){  //Checks if the current line is too big/ bigger than the wanted window width
                wordCount--;
                if(wordCount < textWIP.Length-1){ // to make sure no array out of bounds exceptions trigger. and i'm lazy and this works
                    if(textWIP[wordCount+1].Contains("½")){
                        splitTheWord++;
                        if(splitTheWord>10){
                            force = true;
                        }
                        if(splitTheWord>15){
                            string[] tempText = textWIP[wordCount].Split(" ");
                            for(int i = 0; i < tempText.Length; i++){
                                textWIP[wordCount+i] = tempText[i];
                            }
                            splitTheWord = -1;
                        }
                    }
                }
                weDied++;
                if(splitTheWord == -1){
                    splitTheWord++;
                    textInternal = "";
                } else 
                textInternal = textInternal.Remove(textInternal.Length - textWIP[wordCount].Length - 1);
                textInternal.TrimStart();
                AddTextInternal();
                textInternal = "";
                // Console.WriteLine("line"+text.Count+" is finished");
            }
            if(wordCount == textWIP.Length){ // checks if it is the last word of the text input
                // Console.WriteLine("last line finished");
                AddTextInternal();
                ongoing=false;
            } else if(textInternal.Contains(".") || force || textInternal.Contains("?")){
                if(!(textInternal.Length > windowWidth-4)){
                    AddTextInternal();
                    textInternal = "";
                } else {
                    splitTheWord++;
                }
                force = false;
            }
            if(weDied > 500){
                throw new Exception($"The textbox function has stopped working due to a certain word not fitting within the allowed box size. Word: \"{textWIP[wordCount]}\" Word Length: {textWIP[wordCount].Length} Box Size: {windowWidth}");
            }
            weDied++;
        }

        if(setListPos)
        {
            listText.Add(new((Console.GetCursorPosition().Left+2, Console.GetCursorPosition().Top), text[0]));
        }
        switch(padDir.ToLower()){
            case "right":
                foreach(string output in text){
                    Console.WriteLine("| "+output.PadRight(windowWidth-4)+" |");
                }
                break;
            
            case "left":
                foreach(string output in text){
                    Console.WriteLine("| "+output.PadRight(windowWidth-4)+" |");
                }
                break;

            // case "spread":
            //     // foreach(string output in text){
            //     //     Console.WriteLine("| "+PadSpread(output,windowWidth-2)+" |");
            //     // }'
            //     int words = text[0].Split(' ').Count();
            //     int pad = windowWidth/words+1;
            //     int[] pads = new int[words+1];
            //     for (int i = 0; i < pads.Length; i++)
            //     {
            //         pads[i] = pad;
            //     }
            //     if()
            //     break;

            case "equal":
                foreach(string output in text){
                    Console.WriteLine("| "+PadEqual(output, windowWidth-4)+" |");
                }
                break;
            
            default:
                Console.WriteLine("| "+text+" |");
                break;
        }
    }

    public int choiceList(string[] choices, bool changeWidth = true)
    {
        if(changeWidth)
        {
            int minWidth = 0;
            foreach(string text in choices)
            {
                if(text.Length > minWidth) minWidth = text.Length;
            }
            WidthChange(minWidth+6);
            BoxBorder();
        }
        for (int i = 0; i < choices.Length; i++)
        {
            BoxLine(choices[i], "right", true);
        }
        BoxBorder();
        if(changeWidth) WidthChange();
        return ListInput();
    }

    public int choiceList(string[] choices, int length, bool changeWidth = true)
    {
        int offset=0;                                  //Keeps track of what page you're on
        int maxOffset=(length-12);                  //Keeps track of how many pages your inventory has
        if(changeWidth)
        {
            int minWidth = 0;
            foreach(string text in choices)
            {
                if(text.Length > minWidth) minWidth = text.Length;
            }
            WidthChange(minWidth+6);
            BoxBorder();
        }
        for (int i = 0; i < choices.Length; i++)
        {
            BoxLine(choices[i], "right", true);
        }
        BoxBorder();
        if(changeWidth) WidthChange();
        return ListInput();
    }

    public int ListInput(ref int offset, ref bool ongoing) //God save us all
    {   // I am assuming that it's is the latest textbox that calls this method
    Origin = Console.GetCursorPosition();
    if(lastPos == activeItem)
        {
            Console.SetCursorPosition(listText[activeItem].position.Left, listText[activeItem].position.Top);
            Console.Write(">"+listText[activeItem].text);
        }
        while(true)
        {
            ConsoleKey Input = Console.ReadKey(true).Key;
            switch(Input)
            {
                case(ConsoleKey.UpArrow):
                if(activeItem != 0) activeItem--;
                
                    
                break;
                case(ConsoleKey.DownArrow):
                if(activeItem != listText.Count-1) activeItem++;
                
                break;
                case(ConsoleKey.Enter):
                Console.SetCursorPosition(Origin.Left, Origin.Top);
                return activeItem+offset;
                default:
                break;
            }
            Console.SetCursorPosition(listText[lastPos].position.Left, listText[lastPos].position.Top);
            Console.Write(""+listText[lastPos].text+" ");
            Console.SetCursorPosition(listText[activeItem].position.Left, listText[activeItem].position.Top);
            Console.Write(">"+listText[activeItem].text);
            lastPos = activeItem;
        }
    }

    bool wSwitch = false;
    int oldWidth;
    void WidthChange(int newWidth = -1)
    {
        if(wSwitch)
        {
            windowWidth = oldWidth;
            wSwitch = false;
            return;
        }
        oldWidth = windowWidth;
        windowWidth = newWidth;
        wSwitch = true;
    }  
}

public class MenuSavestate
{
    (int Left, int Top) Origin;
    // (int Left, int Top) CursorOffset;

    List<((int Left, int Top) position, string text)> listText = new(); //yes
    int lastPos = 0;
    int activeItem = 0;
}









