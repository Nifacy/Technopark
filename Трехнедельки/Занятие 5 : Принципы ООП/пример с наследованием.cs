using System;
using System.Threading;


// класс лошади - бегуна
class Horse
{
    private float _speed; // скорость лошади
    private float _pasted = 0.0f; // сколько лошадь прошла
    private int _endurance = 100; // выносливость лошади
    
    // добавляет выносливость лошади
    private void AddEndurance(int count)
    {
        _endurance += count;
        
        if(_endurance > 100)
        {
            _endurance = 100;
        }
    }
    
    // тратит выносливость лошади
    private void RemoveEndurance(int count)
    {
        _endurance -= count;
        
        if(_endurance < 0)
        {
            _endurance = 0;
        }
    }
    
    // устанавливает скорость лошади
    public void SetSpeed(float speed)
    {
        if(speed > 0.0f)
        {
            _speed = speed;
        }
        else
        {
            Console.WriteLine("Скорость лошади может быть только положительной!");
        }
    }
    
    // получает информацию о скорости лошади
    public float GetSpeed()
    {
        return _speed;
    }
    
    // возвращает пройденное бегуном расстояние
    public float GetPastedDistance()
    {
        return _pasted;
    }
    
    public void Run()
    {
        float coef;
        
        if(_endurance > 50)
        {
            Console.WriteLine("Лошадь полна сил");
            coef = 1.0f;
        }
        else if(_endurance > 20)
        {
            Console.WriteLine("Лошадь немного устала.");
            coef = 0.5f;
        }
        else
        {
            Console.WriteLine("Лошадь очень устала и не может двигаться");
            coef = 0.0f;
        }
        
        _pasted += GetSpeed() * coef;
        RemoveEndurance(15);
    }
    
    public void Relax()
    {
        if(_endurance >= 100)
        {
            Console.WriteLine("Лошадь достаточно отдохнула");
        }
        else
        {
            AddEndurance(10);
        }
    }
    
    public bool IsTired()
    {
        return _endurance < 20;
    }
}


// класс единорога, созданного на основе класса лошади
class Unicorn : Horse
{
    private string _cornType;
    private string[] _availableCornMaterials = {"золото", "серебро", "обсидиан"};
    
    public void SetCornType(string cornType)
    {
        if(Array.IndexOf(_availableCornMaterials, cornType) == -1)
        {
            _cornType = cornType;
        }
        else
        {
            Console.WriteLine("Неизвестный тип рога");
        }
    }
    
    public void UseMagic()
    {
        float coef = 1.0f;
        
        if(_cornType == "золото")
        {
            coef = 2.0f;
        }
        
        if(_cornType == "серебро")
        {
            coef = 1.5f;
        }
        
        if(_cornType == "обсидиан")
        {
            coef = 1.25f;
        }
        
        Console.WriteLine("Единорог воспользовался магией и увеличил скорость!");
        SetSpeed(coef * GetSpeed());
    }
}


class Races
{
    static void Main()
    {
        Unicorn runner = new Unicorn();
        runner.SetSpeed(15.0f);
        
        while(true)
        {
            if(runner.IsTired())
            {
                Console.WriteLine("Лошадь отдыхает");
                runner.Relax();
            }
            else
            {
                runner.Run();
                Console.WriteLine("Лошадь пробежала : " + runner.GetPastedDistance());
            }
            
            float pastedDistance = runner.GetPastedDistance();
            
            if(90 < pastedDistance && pastedDistance < 100)
            {
                runner.UseMagic();
            }
            
            Thread.Sleep(1000);
        }
    }
}
