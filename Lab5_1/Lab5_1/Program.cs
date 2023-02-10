using System;
using System.Collections.Generic;
namespace Lab5_1
{
    abstract class GameCharacter
    {
        protected string prName;
        protected int prStrength;
        protected string prIntelligence;

        public GameCharacter(string _Name, int _Strength, string _Intelligence)
        {
            prName = _Name;
            prStrength = _Strength;
            prIntelligence = _Intelligence;
        }

        public virtual void Play()
        {
            Console.WriteLine($" Character name: {prName}  \n\t Strength level: {prStrength}  \n\t Intelligence: {prIntelligence}");
        }
    }

    class MagicUsingCharacter : GameCharacter
    {

        public int MagicalEnergy;

        public MagicUsingCharacter(string _mName, int _mStrength, string _mIntelligence, int _MagicalEnergy) : base (_mName, _mStrength, _mIntelligence)
        {
            MagicalEnergy = _MagicalEnergy;
        }

        public override void Play()
        {
            Console.WriteLine($" Character name: {prName}  \n\tStrength level: {prStrength}  \n\tIntelligence: {prIntelligence}  \n\tMagical Energy {MagicalEnergy}");
        }
    }

    class Warrior : GameCharacter
    {
        public string WeaponType;

        public Warrior(string _wrName, int _wrStrength, string _wrIntelligence, string _WeaponType) : base(_wrName, _wrStrength, _wrIntelligence)
        {
            WeaponType = _WeaponType;
        }

        public override void Play()
        {
            Console.WriteLine($" Warrior:{prName}   \n\t Strength level: {prStrength}   \n\t Intelligence: {prIntelligence}   \n\t Weapon: {WeaponType}");
        }
    }


    class Wizard : MagicUsingCharacter
    {
        public int SpellNumber;

        public Wizard(string _wName, int _wStrength, string _wIntelligence, int _SpellNumber, int _wMagicalEnergy) : base (_wName, _wStrength, _wIntelligence, _wMagicalEnergy)
        {
            SpellNumber = _SpellNumber;
        }

        public override void Play()
        {
            Console.WriteLine($" Wizard: {prName}  \n\t Strength level: {prStrength}  \n\t Intelligence: {prIntelligence}  \n\t Magical Energy {MagicalEnergy}  \n\t Spells: {SpellNumber}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to the world of Dev.BuildCraft!\n\n");


            List<GameCharacter> gameCharacters = new List<GameCharacter>();

            Warrior war1 = new Warrior("Conan", 20, "9", "BroadSword");
            gameCharacters.Add(war1);

            Warrior war2 = new Warrior("Cron", 25, "12", "Battle Axe");
            gameCharacters.Add(war2);


            Wizard wiz1 = new Wizard("Gandolph", 30, "20", 40, 5);
            gameCharacters.Add(wiz1);

            Wizard wiz2 = new Wizard("Valarien", 20, "30", 35, 15);
            gameCharacters.Add(wiz2);

            Wizard wiz3 = new Wizard("Gloria the Great", 22, "35", 45, 25);
            gameCharacters.Add(wiz3);

            foreach (GameCharacter mycharacter in gameCharacters)
            {
                mycharacter.Play();
            }
        }
    }
}
