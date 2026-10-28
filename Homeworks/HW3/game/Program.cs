using System;

class Program
{
    class Character
    {
        private static int count;
        private string name;
        private int hp;
        private int power;
        public Character(string name, int hp, int power,int count)
        {
            this.name = name;
            if (hp >= 0){this.hp = hp;}
            this.power = power;
            count = count + 1;

        }
        public int Hp  
        {
            get {return hp;}
            set {if (value < 0){ hp = 0;}else{hp = value;}}
        }
        public int Power { get; set; } 
        public int Name { get; set; } 
        static int Attack(Character target)
        {
            target.hp = target.hp - target.power;
            Console.WriteLine($"hp {target.name} уменьшился на один");
            return(target.hp);

        }
        void GetStatus()
        {
           Console.WriteLine($"У персонажа {name} hp {hp}");
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
    }
    class Enemy : Character
    {
        public Enemy(string name, int hp, int power,int count) : base(name, hp, power,count) {}
    }
    static void Main()
    {
    }
}