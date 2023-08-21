namespace week2Project;
internal class Program
{
    private static Character player;
    private static item EquipItem;


    static void Main(string[] args)
    {
        DataSetting();
        DisplayFirst();

     
    }

    static void DataSetting()
    {
        //플레이어 정보 셋팅 (이름, 직업, 레벨, 공격력, 방어력, 체력, gold)
        player = new Character("HAM", "초보 개발자", 1, 10, 5, 100, 1500);

        EquipItem = new item("아이템 이름 1","아이템 이름 2", 10, 5); //인벤토리 내 아이템 설정 
    }

  


    static void DisplayFirst() //처음화면 
    {
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine("\n1. 상태보기\n2. 인벤토리.");
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

        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine();

        //레벨, 이름, 직업, 공격력, 방어력, 체력, gold
        //$"{변수명}"   (문자열 보간 이용)
        //어느정도 틀을 만들고 컬러배열 다르게 해보기 
        Console.WriteLine($"Lv : {player.Lv}");
        Console.WriteLine($"이름 : {player.Name}({player.Job})");
        Console.WriteLine($"공격력 : {player.Atk}");
        Console.WriteLine($"방어력 : {player.Def}");
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
        //글자 색상변경 
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("인벤토리");
        Console.ResetColor();

        Console.WriteLine("보유 중인 아이템을 관리 할 수 있습니다.");
        Console.WriteLine();

        //아이템 목록 
        Console.WriteLine("[아이템  목록]");
        Console.WriteLine("---이름---|----효과---|----설명----");//아이템의 이름 효과 설명 기능 구현 필요
        Console.WriteLine("---이름---|----효과---|----설명----");


        Console.WriteLine("\n1. 장착관리\n0. 돌아가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(">>");
        Console.ResetColor();

        //처음 화면으로 돌아가기와 아이템 장착 관리 
        int input = CheakInput(0, 1);
        switch (input)
        {
            case 0:
                DisplayFirst();
                break;
            case 1://장착관리 화면으로 이동 
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

        Console.WriteLine("보유 중인 아이템을 관리 할 수 있습니다.");
        Console.WriteLine();

        //아이템 목록 
        Console.WriteLine("[아이템  목록]"); // 목록 앞 색이 다른 숫자가 나타나서 누르면 장착 기능 
        Console.WriteLine("1."+(EquipItem.ItemName1)+"|방어력 +  "+(EquipItem.ItemDef)+"|----설명----");//장착중인 아이템의 확인 표시 구현 필요  (장착한 아이템이 상태보기 창에서도 반영되어야 함)
        Console.WriteLine("2." + (EquipItem.ItemName2) + "|공격력 + " + (EquipItem.ItemAtk) + "|----설명----");


        Console.WriteLine("\n0. 돌아가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(">>");
        Console.ResetColor();


        int input = CheakInput(0, 0);
        switch (input)
        {

            case 0://인벤토리 화면으로 이동 
                DisplayInven();
                break;
    
                
        }

      
    }

        
    public class item //아이템 정보 생성 
    {
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
        public Character(string name, string job, int lv , int atk , int def, int hp, int g)
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



