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



    static void DisplayFirst()
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
    {
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
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("상태보기");
        Console.ResetColor();


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

    }

    public class Character
    {
    }
}



