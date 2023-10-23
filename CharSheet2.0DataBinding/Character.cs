using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharSheet20DataBinding
{
    /// <summary>
    /// A class for saving the sheets
    /// </summary>
    internal class Character
    {

        public string CName { get; set; }

        public string Race { get; set; }

        public string Class { get; set; }

        public string Background { get; set; }

        public string Alignment { get; set; }

        public string Playername { get; set; }

        public string Notes { get; set; }

        public string ExperiencePoints { get; set; }

        public string HitDice { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public int Charisma { get; set; }



        public string ArmorPro { get; set; }

        public string WeaponsPro { get; set; }

        public string ToolsPro { get; set; }

        public string LanguagesPro { get; set; }

        public string Defenses { get; set; }

        public string Conditions { get; set; }

        public string Advantages { get; set; }

        public int Proficiency { get; set; }

        public int Speed { get; set; }

        public int Initiativ { get; set; }

        public int ArmorClass { get; set; }

        public int CurrentHP { get; set; }

        public int TempHP { get; set; }

        public int MaxHP { get; set; }

        public List<Item> items = new List<Item>();



        public bool Acrobatics { get; set; }

        public bool AnimalHandling { get; set; }

        public bool Arcana { get; set; }

        public bool Athletics { get; set; }

        public bool Deception { get; set; }

        public bool History { get; set; }

        public bool Insight { get; set; }

        public bool Intimidation { get; set; }

        public bool Investigation { get; set; }

        public bool Medicine { get; set; }

        public bool Nature { get; set; }

        public bool Perception { get; set; }

        public bool Performance { get; set; }

        public bool Persuasion { get; set; }

        public bool Religion { get; set; }

        public bool SleightOfHand { get; set; }

        public bool Stealth { get; set; }

        public bool Survival { get; set; }

        public bool Inspiration { get; set; }



        public bool STRSavingThrow { get; set; }

        public bool DEXSavingThrow { get; set; }

        public bool CONSavingThrow { get; set; }

        public bool INTSavingThrow { get; set; }

        public bool WISSavingThrow { get; set; }

        public bool CHASavingThrow { get; set; }



        /* Death Saves  

              / Ds Succ = 3 length, false false false as DEFAULT 

              / Ds Fail = 3 lenght, false false false as DEFAULT 

              / DS_succ = new bool[3] { false, false, false }; 

              / DS_fail = new bool[3] { false, false, false }; 

              */

        public bool[] DS_succ { get; set; } = new bool[3] {false, false, false};

        public bool[] DS_fail { get; set; } = new bool[3] { false, false, false };
        public List<Attacks> attacks = new List<Attacks>();
        public List<Spells> spells = new List<Spells>();
        public string AttackExtras { get; set; }
    }
}
