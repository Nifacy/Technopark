using System;


// интерфейс любого транспортного средства, которое умеет летать
interface Flyable
{
    void Fly();
	// чтобы транспорт взлетел, надо вызвать этот метод
}


// класс вертолета, реализующий интерфейс Flyable (т. е. он умеет летать)
class Helicopter : Flyable
{
    public void Fly()
    {
        Console.WriteLine("Лопасти крутятся...");
        Console.WriteLine("Вертолет взлетает");
    }
}


class Balloon : Flyable
{
    public void Fly()
    {
        Console.WriteLine("Зажигаем херню");
        Console.WriteLine("Шар надувается");
        Console.WriteLine("Шар взлетает");
    }
}


class Plane : Flyable
{
    public void Fly()
    {
        Console.WriteLine("Запускаются двигатели");
        Console.WriteLine("Самолет двигается");
        Console.WriteLine("Самолет взлетает");
    }
}


class HelloWorld
{
    static void Main()
    {
        Flyable transport = new Plane();
		// создаем переменную, которая в себе хранит в себе любой транспорт, который умеет летать
        
		transport.Fly();
		// запускаем транспорт
    }
}
