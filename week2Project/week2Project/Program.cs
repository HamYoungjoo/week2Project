namespace week2Project;
internal class Program
{
    private static Character player; //캐릭터 정보 
    private static item equipItem;//아이템 정보 
    

    
 

    static void Main(string[] args)
    {
        DataSetting();
        DisplayIntro();

    }

    static void DataSetting()
    {
        //플레이어 정보 셋팅 (이름, 직업, 레벨, 공격력, 방어력, 체력, gold)
        player = new Character("HAM", "초보 개발자", 1, 10, 5, 100, 1500);

        equipItem = new item("아이템 이름 1","아이템 이름 2", 7 , 5); //인벤토리 내 아이템 설정 
    }

    static void DisplayIntro()
    {
        Console.Clear();


        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        Console.ResetColor();
        Console.WriteLine();

        Console.WriteLine("           ::::::::  :::::::::      :::     :::::::::  :::::::::::     :::     ::::    :::");
        Console.WriteLine("          :+:    :+: :+:    :+:   :+: :+:   :+:    :+:     :+:       :+: :+:   :+:+:   :+:");
        Console.WriteLine("          +:+        +:+    +:+  +:+   +:+  +:+    +:+     +:+      +:+   +:+  :+:+:+  +:+");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("          +#++:++#++ +#++:++#+  +#++:++#++: +#++:++#:      +#+     +#++:++#++: +#+ +:+ +#+");
        Console.WriteLine("                 +#+ +#+        +#+     +#+ +#+    +#+     +#+     +#+     +#+ +#+  +#+#+#");
        Console.WriteLine("          #+#    #+# #+#        #+#     #+# #+#    #+#     #+#     #+#     #+# #+#   #+#+#");
        Console.WriteLine("           ########  ###        ###     ### ###    ###     ###     ###     ### ###    ####");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("    :::     :::::::::  :::     ::: :::::::::: ::::    ::: ::::::::::: :::    ::: :::::::::  ::::::::::");
        Console.WriteLine("  :+: :+:   :+:    :+: :+:     :+: :+:        :+:+:   :+:     :+:     :+:    :+: :+:    :+: :+:       ");
        Console.WriteLine(" +:+   +:+  +:+    +:+ +:+     +:+ +:+        :+:+:+  +:+     +:+     +:+    +:+ +:+    +:+ +:+       ");
        Console.ResetColor();
        Console.WriteLine("+#++:++#++: +#+    +:+ +#+     +:+ +#++:++#   +#+ +:+ +#+     +#+     +#+    +:+ +#++:++#:  +#++:++#  ");
        Console.WriteLine("+#+     +#+ +#+    +#+  +#+   +#+  +#+        +#+  +#+#+#     +#+     +#+    +#+ +#+    +#+ +#+       ");
        Console.WriteLine("#+#     #+# #+#    #+#   #+#+#+#   #+#        #+#   #+#+#     #+#     #+#    #+# #+#    #+# #+#       ");
        Console.WriteLine("###     ### #########      ###     ########## ###    ####     ###      ########  ###    ### ##########");
        

        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> '1'을 입력하고 입장하기 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        Console.ResetColor();
        Console.WriteLine();

        int input = CheakInput(0, 1);
        switch (input)
        {
            case 1:
                DisplayFirst();
                break;

        }
    }


    static void DisplayFirst() //처음화면 
    {

        Console.Clear();
      
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("☻ 스파르타 마을에 오신 여러분 환영합니다 ☻");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n던전으로 들어가기 전에 이곳에서 활동을 고를 수 있습니다.");
        Console.ResetColor();


        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\n1. ");
        Console.ResetColor();

        Console.WriteLine("상태보기");

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\n2. ");
        Console.ResetColor();

        Console.WriteLine("인벤토리");
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(">>");
        Console.ResetColor();

        int input = CheakInput(1, 2);
        switch(input)
        {
            case 1:
                DisplayInfo();
                break;

            case 2:
                DisplayInven();
                break;

        }

        
    }

    static int CheakInput(int min,int max)
    { //입력한 숫자가 선택범위인지 체크 
        while (true)
        {
            string input = Console.ReadLine();
            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if (ret >= min && ret <= max)
                    return ret;
            }

            Console.WriteLine("잘못된 입력 입니다.");
        }
    }



   static void DisplayInfo()
    {
        Console.WriteLine();
        //글자 색상변경 
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("상태보기");
        Console.ResetColor();
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.ResetColor();

        Console.WriteLine();

        //레벨, 이름, 직업, 공격력, 방어력, 체력, gold
        //$"{변수명}"   (문자열 보간 이용)

        int totalAtk = player.Atk + equipItem.ItemAtk; //기본 공격력 + 아이템 효과 공격력의 합 
        int totalDef = player.Def + equipItem.ItemDef; //기본 방력 + 아이템 효과 방어력의 합 
        string TotalAtk = equipItem.IsEquipped1 ? totalAtk.ToString() : ""; //아이템 장착 시 보이게 설정 
        string TotalDef = equipItem.IsEquipped2 ? totalDef.ToString() : "";
        string OriginAtk = !equipItem.IsEquipped1 ? player.Atk.ToString() : "";// 캐릭터 원래의 기본 공격력 , 아이템 장착시 보이지 않게 설정 
        string OriginDef = !equipItem.IsEquipped2 ? player.Def.ToString() : "";// 캐릭터 원래의 기본 방어력 
        string equippedItemAtk = equipItem.IsEquipped1 ? "( + " + equipItem.ItemAtk.ToString() + " )" : "";//공격 아이템 장착 시
        string equippedItemDef = equipItem.IsEquipped2 ? "( + " + equipItem.ItemDef.ToString() + " )" : "";//방어 아이템 장착 시

        Console.WriteLine($"Lv : {player.Lv}");
        Console.WriteLine($"이름 : {player.Name}({player.Job})");
        Console.Write($"공격력 : {OriginAtk}{TotalAtk}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" {equippedItemAtk}");
        Console.ResetColor();
        Console.Write($"방어력 : {OriginDef}{TotalDef}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" {equippedItemDef}");
        Console.ResetColor();
        Console.WriteLine($"HP : {player.Hp}");
        Console.WriteLine($"Gold : {player.G}");
       
        Console.WriteLine("\n0. 돌아가기");
        //처음 화면으로 돌아가기 
        int input = CheakInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayFirst();
                break;
        }

    }

    static void DisplayInven()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("인벤토리");
        Console.ResetColor();
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("보유 중인 아이템을 확인 할 수 있습니다.");
        Console.ResetColor();


        //아이템 목록 
        Console.WriteLine();
        Console.WriteLine("[아이템  목록]");

        string equippedSymbol1 = equipItem.IsEquipped1 ? "[E]" : "";
        string equippedSymbol2 = equipItem.IsEquipped2 ? "[E]" : ""; //장착관리에서 장착 해제시 인벤토리 화면에서도 확인 가능 

        Console.WriteLine($"{equippedSymbol1} {equipItem.ItemName1}|공격력 +{equipItem.ItemAtk}|----설명----"); // 아이템 만들어보기 
        Console.WriteLine($"{equippedSymbol2} {equipItem.ItemName2}|방어력 +{equipItem.ItemDef}|----설명----");

        Console.WriteLine("\n1. 장착관리\n0. 돌아가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(">>");
        Console.ResetColor();
        
        int input = CheakInput(0, 1);
        switch (input)
        {
            case 0: //돌아가기 
                DisplayFirst();
                break;
            case 1://장착관리 화면으로 
                InvenSetting();
                break;
        }
    }

    static void InvenSetting() //인벤토리 장착관리 
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("인벤토리");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("- 장착관리");
        Console.ResetColor();
        Console.WriteLine();

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("보유 중인 아이템의 착용을 관리 할 수 있습니다.");
        Console.ResetColor();
        //아이템 목록 
        Console.WriteLine();
        Console.WriteLine("[아이템  목록]");
       
        string equippedSymbol1 = equipItem.IsEquipped1 ? "[E]" : ""; // 1번 아이템 장착 표시 
        string equippedSymbol2 = equipItem.IsEquipped2 ? "[E]" : ""; 

        Console.WriteLine($"- 1 {equippedSymbol1} {equipItem.ItemName1}|공격력 +{equipItem.ItemAtk}|----설명----");
        Console.WriteLine($"- 2 {equippedSymbol2} {equipItem.ItemName2}|방어력 +{equipItem.ItemDef}|----설명----");

        Console.WriteLine("\n0. 돌아가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(">>");
        Console.ResetColor();

        int input = CheakInput(0, 2);
        switch (input)
        {
            case 0:
                DisplayInven();
                break;
            case 1: // 장착관리 화면에서 [E] 표시 켰다 끄기
                CheckEquipped(1);
                InvenSetting();
                if(equipItem.IsEquipped1 = !equipItem.IsEquipped1)
                {
                    CheckEquipped(1);
                    DisplayInven();
                }
                break;
            case 2:
                CheckEquipped(2);
                InvenSetting();
                if (equipItem.IsEquipped2 = !equipItem.IsEquipped2)
                {
                    CheckEquipped(2);
                    DisplayInven();
                }
                break;
        }

        static void CheckEquipped(int itemNumber) // [E] 표시 켰다 끄기 확인
        {
            if (itemNumber == 1)
            {
                equipItem.IsEquipped1 = !equipItem.IsEquipped1;
            }
            else if (itemNumber == 2)
            {
                equipItem.IsEquipped2 = !equipItem.IsEquipped2;
            }
        }
    }

    public class item //아이템 정보 생성 
    {
        internal bool IsEquipped1; //아이템 장착 확인 bool 
        internal bool IsEquipped2;

        public item(string itemName1, string itemName2, int itemAtk, int itemDef)
        {
            ItemName1 = itemName1;
            ItemName2 = itemName2;
            ItemAtk = itemAtk;
            ItemDef = itemDef;
        }

        public string ItemName1 { get; }
        public string ItemName2 { get; }
        public int ItemAtk { get; }
        public int ItemDef { get; }
    }



    public class Character // 캐릭터 정보 생성

    {
        //플레이어 정보 셋팅 (이름, 직업, 레벨, 공격력, 방어력, 체력, gold)
        public Character(string name, string job, int lv, int atk, int def, int hp, int g)
        {
            Name = name;
            Job = job;
            Lv = lv;
            Atk = atk;
            Def = def;
            Hp = hp;
            G = g;
        }

        public string Name { get; }
        public string Job { get; }
        public int Lv { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int G { get; }
    }



}


