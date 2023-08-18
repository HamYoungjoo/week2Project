namespace week2Project;
internal class Program
{
    private static Character player;

    static void Main(string[] args)
    {
        DataSetting();
        DisplayFirst();
     
    }

    static void DataSetting()
    {
        //플레이어 정보 셋팅
        player = new Character();
    }



    static void DisplayFirst() //처음화면 
    {
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine("\n1. 상태보기\n2. 인벤토리.");
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");

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
        //글자 색상변경 
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("상태보기");
        Console.ResetColor();

        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine();

        //레벨, 이름, 직업, 공격력, 방어력, 체력, gold 
        Console.WriteLine();//레벨 
        Console.WriteLine();//이름 및 직업 
        Console.WriteLine();//공격력 
        Console.WriteLine();//방어력 
        Console.WriteLine();//체력 
        Console.WriteLine();//골드 
       
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
                DisplayFirst();
                break;


        }
        

    }

    public class Character
    {
    }
}



