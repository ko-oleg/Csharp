using System;
using System.Collections.Generic;

namespace Exam_4.Class
{
    public class Cat : ICatState

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int LevelSatiety { get; set; }
        public int LevelMood { get; set; }
        public int LevelHealth { get; set; }
        public int AverageLevel;
        public int PlusRank { get; set; }
        public int MinusRank { get; set; }
        public char Action { get; set; }

        private Random _random = new Random();

        // public Cat(, int levelSatiety, int levelMood, int levelHealth, int plusRank, int minusRank)
        // {
        //     Id = id;
        //     Name = name;
        //     Age = age;
        //     LevelSatiety = levelSatiety;
        //     LevelMood = levelMood;
        //     LevelHealth = levelHealth;
        //     PlusRank = plusRank;
        //     MinusRank = minusRank;
        // }
        public Cat(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
            LevelSatiety = _random.Next(20, 81);
            LevelMood = _random.Next(20, 81);
            LevelHealth = _random.Next(20, 81);
            AverageLevel = (LevelMood + LevelSatiety + LevelHealth) / 3;
            Action = ' ';

            if (age >= 1 && age <= 5)
            {
                LevelSatiety -= 7;
                PlusRank = 7;
                MinusRank = 3;
            }

            else if (age > 5 && age <= 10)
            {
                PlusRank = 5;
                MinusRank = 5;
            }
            else if (age >= 11)
            {
                PlusRank = 4;
                MinusRank = 6;
            }
        }



        public void Eat()
        {
            LevelSatiety += PlusRank;
            LevelMood += PlusRank;
            AverageLevel = (LevelMood + LevelSatiety + LevelHealth) / 3;
            Action = '*';
        }

        public void Play()
        {
            LevelMood += PlusRank;
            LevelHealth += PlusRank;
            LevelSatiety -= MinusRank;
            AverageLevel = (LevelMood + LevelSatiety + LevelHealth) / 3;
            Action = '*';
        }

        public void Heal()
        {
            LevelHealth += PlusRank;
            LevelMood -= MinusRank;
            LevelSatiety -= MinusRank;
            AverageLevel = (LevelMood + LevelSatiety + LevelHealth) / 3;
            Action = '*';
        }
        
        public void NewDay()
        {
            LevelSatiety -= _random.Next(1, 6);
            LevelMood -= _random.Next(-3, 4);
            LevelHealth -= _random.Next(-3, 4);
            AverageLevel = (LevelMood + LevelSatiety + LevelHealth) / 3;
            Action = ' ';
        }


        public override string ToString()
        {
            return
                $"| {Id}\t | {Action} {Name}\t | {Age}\t\t | {LevelHealth}\t\t | {LevelMood}\t\t | {LevelSatiety}\t\t | {AverageLevel}\t\t\t |";
        }

    }
}