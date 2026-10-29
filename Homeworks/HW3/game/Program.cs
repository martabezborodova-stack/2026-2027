using System;

class Program
{
    class Character
    {
        private static int count;
        private string name;
        private int hp;
        private int power;
        public string Name => name;
        public int Hp => hp;
        public Character(string name, int hp, int power,int count)
        {
            this.name = name;
            if (hp >= 0){this.hp = hp;}
            this.power = power;
            count = count + 1;

        }
        public Character()
        {
            this.name = "A";
            this.hp = 100;
            this.power = 5;
            count = count + 1;
        }
        public int Power { get; set; } 
        public virtual void Attack(Character target)
        {
            target.hp =target.TakeDamage(target.power);
            Console.WriteLine($"hp {target.name} уменьшился на {target.power}");

        }
        public int TakeDamage(int damage)
        {
            if (hp - damage >= 0)
            {
                return (this.hp = Hp - damage);
            }
            else
            {
                return this.hp = 0;
            }
        }
        public bool IsAlive()
        {
            if (hp > 0)return true;
            else return false;
        }
        public void GetStatus()
        {
           Console.WriteLine($"У персонажа {Name} hp {Hp}");
        }
        static int HowMany()
        {
            return(Character.count);
        }
        static void IsValidStats(int hp, int power)
        {
            if (hp < 0){ hp = 0;}else{hp = hp;}
            if (power < 0){ power = 0;}else{power = power;}
        }
    }
    class Player : Character
    {
        public Player(string name, int hp, int power,int count) : base(name, hp, power,count) {}
        public Player() : base(){}
        public override void Attack(Character target)
        {
            target.TakeDamage(target.Power);
            Console.WriteLine($"hp {target.Name} уменьшился на целых {target.Power}");
        }
    }
    class Enemy : Character
    {
        public Enemy(string name, int hp, int power,int count) : base(name, hp, power,count) {}
        public Enemy() : base(){}
        public override void Attack(Character target)
        {
            target.TakeDamage(target.Power);
            Console.WriteLine($"hp {target.Name} уменьшился всего на {target.Power}");
        }
    }
    static void Main()
    {
        List<Character> list = new List<Character>();
        Player hero = new Player("D",100,6,1);
        list.Add(hero);
        Enemy hero1 = new Enemy();
        list.Add(hero1);
        while (hero.IsAlive() == true & hero1.IsAlive() == true)
        {
            hero.Attack(hero1);
            hero.GetStatus();
            hero1.GetStatus();
            hero1.Attack(hero);
            hero.GetStatus();
            hero1.GetStatus();
        }


    }
}