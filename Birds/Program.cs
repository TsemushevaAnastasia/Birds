using System;


namespace Birds
{
    class Program
    {
        static void Main(string[] args)
        {
            Сhicken Bob = new Сhicken();
            Bob.Name = "Бобик";

            Duck D1 = new Duck("Кусак", Gender.male);

            Duck D2 = new Duck("Катя", Gender.female);

            Eagle E = new Eagle("Гоша", 55.09, 1000);

            Duck D3 = D2.LayEgg(D1, "Уточка", Gender.female);

            D3.PrintInfo();

            Bob.PrintInfo();

            Pinguin P1 = new Pinguin ("Лала", Gender.female);
            Pinguin P2 = new Pinguin ("Тото", Gender.male);

            Pinguin Lolo = new Pinguin ("Лоло", Gender.male, P1, P2, 200, 800);
            Lolo.PrintInfo();

            Console.ReadLine();
        }
    }
}
