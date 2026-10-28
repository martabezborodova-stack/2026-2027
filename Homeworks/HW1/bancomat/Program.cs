using System;

class Program
{
    static void Print_Balance(decimal balance)
    {
        Console.WriteLine($"Ваш баланс: {balance}");
    }
    static decimal Account_Top_Up(ref List<string> history, decimal balance)
    {
        Console.WriteLine("Введите на сколько вы хотите пополнить:");
        decimal plus = decimal.Parse(Console.ReadLine());
        if (plus >= 0)
        {
            balance +=plus;
            Transaction_History(ref history, "Баланс пополне на:", plus);
            return balance;
        }
        else
        {
            Console.WriteLine("Сумма не коректна. Ошибка.");
            plus = 0;
            Transaction_History(ref history, "Ошибка пополнения.", plus);
            return balance;
        }

    }
    static decimal Сash_Withdrawal(ref List<string> history, decimal balance)
    {
        Console.WriteLine("Введите сколько вы хотите снять:");
        decimal plus = decimal.Parse(Console.ReadLine());
        if (plus <= balance)
        {
            balance -=plus;
            Transaction_History(ref history, "Снято:", plus);
            return balance;
        }
        else
        {
            Console.WriteLine("Недостаточно средств. Ошибка.");
            plus = 0;
            Transaction_History(ref history, "Ошибка снятия", plus);
            return balance;
        }

    }
    static void  Transaction_History(ref List<string> history, string r, decimal money)
    {
        if (money != 0) history.Add($"{r} {money}");
        else history.Add($"{r}");
        
    }
    static void Print_Transaction_History(List<string> history)
    {
        Console.WriteLine(" \n История баланса \n");
        for (int i = 0; i < history.Count; i+=1)
        {
            Console.WriteLine(history[i]);
        }
    }


    static void Main()
    {
        Console.WriteLine("Напишите свой текуший баланс:");
        decimal balance = decimal.Parse(Console.ReadLine());
        List<string> history = new List<string> {};
        while (true)
        {
            Console.WriteLine("Выберите команду:\n 1. Показать баланс \n 2. Пополнить счёт \n 3. Снять деньги \n 4. Показать историю операций \n 5. Выйти");
            int m = int.Parse(Console.ReadLine());
            switch (m)
            {
                case 1:
                    Print_Balance(balance);
                    break;
                case 2:
                    balance = Account_Top_Up(ref history, balance);
                    break;
                case 3:
                    balance = Сash_Withdrawal(ref history, balance);
                    break;
                case 4:
                    Print_Transaction_History(history);
                    break;
            }
            if (m == 5) break;
        }
    }
}