using CharSheet20DataBinding.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Text;
using System.Windows.Input;

namespace CharSheet20DataBinding.ViewModels
{

    class CharSheetViewModel : BaseViewModel
    {


        private string _cName;
        public string CName
        {
            get { return _cName; }
            set
            {
                if (_cName != value)
                {
                    _cName = value;
                    OnPropertyChanged(nameof(CName));
                }
            }
        }

        private string _race;
        public string Race
        {
            get { return _race; }
            set
            {
                if (_race != value)
                {
                    _race = value;
                    OnPropertyChanged(nameof(Race));
                }
            }
        }

        private string _class;
        public string Class
        {
            get { return _class; }
            set
            {
                if (_class != value)
                {
                    _class = value;
                    OnPropertyChanged(nameof(Class));
                }
            }
        }

        private string _background;
        public string Background
        {
            get { return _background; }
            set
            {
                if (_background != value)
                {
                    _background = value;
                    OnPropertyChanged(nameof(Background));
                }
            }
        }

        private string _alignment;
        public string Alignment
        {
            get { return _alignment; }
            set
            {
                if (_alignment != value)
                {
                    _alignment = value;
                    OnPropertyChanged(nameof(Alignment));
                }
            }
        }

        private string _playername;
        public string Playername
        {
            get { return _playername; }
            set
            {
                if (_playername != value)
                {
                    _playername = value;
                    OnPropertyChanged(nameof(Playername));
                }
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    OnPropertyChanged(nameof(Notes));
                }
            }
        }

        private string _experiencePoints;
        public string ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                if (_experiencePoints != value)
                {
                    _experiencePoints = value;
                    OnPropertyChanged(nameof(ExperiencePoints));
                }
            }
        }

        private string _hitDice;
        public string HitDice
        {
            get { return _hitDice; }
            set
            {
                if (_hitDice != value)
                {
                    _hitDice = value;
                    OnPropertyChanged(nameof(HitDice));
                }
            }
        }
        #region Strength
        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                CalcedStrength = CalculateNumber(strength, 0, false);
                STStrength = CalculateNumber(strength, Proficiency, STRSavingThrow);
                AthleticsNumber = CalculateNumber(Strength, Proficiency, athletics);
            }
        }

        private int calcedStrength;
        public int CalcedStrength
        {
            get { return calcedStrength; }
            set
            {
                calcedStrength = value;
                OnPropertyChanged(nameof(CalcedStrength));

            }
        }
        #endregion

        #region Dext
        private int dexterity;
        public int Dexterity
        {
            get { return dexterity; }
            set
            {
                dexterity = value;
                CalcedDexterity = CalculateNumber(dexterity, 0, false);
                STDexterity = CalculateNumber(dexterity, Proficiency, DEXSavingThrow);
                AcrobaticsNumber = CalculateNumber(Dexterity, Proficiency, acrobatics);
                SleightofHandNumber = CalculateNumber(Dexterity, Proficiency, sleightOfHand);
                StealthNumber = CalculateNumber(Dexterity, Proficiency, stealth);
            }
        }
        private int calcedDexterity;
        public int CalcedDexterity
        {
            get { return calcedDexterity; }
            set
            {
                calcedDexterity = value;
                OnPropertyChanged(nameof(CalcedDexterity));
            }
        }
        #endregion

        #region Constit
        private int constitution;
        public int Constitution
        {
            get { return constitution; }
            set
            {
                constitution = value;
                CalcedConstitution = CalculateNumber(constitution, 0, false);
                STConstitution = CalculateNumber(constitution, Proficiency, CONSavingThrow);
            }
        }
        private int calcedConstitution;
        public int CalcedConstitution
        {
            get { return calcedConstitution; }
            set
            {
                calcedConstitution = value;
                OnPropertyChanged(nameof(CalcedConstitution));
            }
        }
        #endregion

        #region Intel

        private int intelligence;
        public int Intelligence
        {
            get { return intelligence; }
            set
            {
                intelligence = value;
                CalcedIntelligence = CalculateNumber(intelligence, 0, false);
                STIntelligence = CalculateNumber(intelligence, Proficiency, INTSavingThrow);
                ArcanaNumber = CalculateNumber(Intelligence, Proficiency, arcana);
                DeceptionNumber = CalculateNumber(Intelligence, Proficiency, deception);
                InvestigationNumber = CalculateNumber(Intelligence, Proficiency, investigation);
                NatureNumber = CalculateNumber(Intelligence, Proficiency, nature);
                ReligionNumber = CalculateNumber(Intelligence, Proficiency, religion);
                HistoryNumber = CalculateNumber(Intelligence, Proficiency, history);
            }
        }
        private int calcedIntelligence;
        public int CalcedIntelligence
        {
            get { return calcedIntelligence; }
            set
            {
                calcedIntelligence = value;
                OnPropertyChanged(nameof(CalcedIntelligence));
            }
        }
        #endregion

        #region Wisdom
        private int wisdom;
        public int Wisdom
        {
            get { return wisdom; }
            set
            {
                wisdom = value;
                CalcedWisdom = CalculateNumber(wisdom, 0, false);
                STWisdom = CalculateNumber(wisdom, Proficiency, WISSavingThrow);
                InsightNumber = CalculateNumber(Wisdom, Proficiency, insight);
                MedicineNumber = CalculateNumber(Wisdom, Proficiency, medicine);
                PerceptionNumber = CalculateNumber(Wisdom, Proficiency, perception);
                AnimalHandlingNumber = CalculateNumber(Wisdom, Proficiency, animalHandling);
                SurvivalNumber = CalculateNumber(Wisdom, Proficiency, survival);
            }
        }
        private int calcedWisdom;
        public int CalcedWisdom
        {
            get { return calcedWisdom; }
            set
            {
                calcedWisdom = value;
                OnPropertyChanged(nameof(CalcedWisdom));
            }
        }
        #endregion

        #region Charisma
        private int charisma;
        public int Charisma
        {
            get { return charisma; }
            set
            {
                charisma = value;
                CalcedCharisma = CalculateNumber(charisma, 0, false);
                stCharisma = CalculateNumber(charisma, Proficiency, CHASavingThrow);
                IntimidationNumber = CalculateNumber(Charisma, Proficiency, intimidation);
                PerformanceNumber = CalculateNumber(Charisma, Proficiency, performance);
                PersuasionNumber = CalculateNumber(Charisma, Proficiency, persuasion);
            }
        }
        private int calcedCharisma;
        public int CalcedCharisma
        {
            get { return calcedCharisma; }
            set
            {
                calcedCharisma = value;
                OnPropertyChanged(nameof(CalcedCharisma));
            }
        }
        #endregion

        #region SavingThrows
        private int stStrength;

        public int STStrength
        {
            get { return stStrength; }
            set
            {
                stStrength = value;
                OnPropertyChanged(nameof(STStrength));
            }
        }
        private int stDexterity;

        public int STDexterity
        {
            get { return stDexterity; }
            set
            {
                stDexterity = value;
                OnPropertyChanged(nameof(STDexterity));
            }
        }
        private int stConstitution;

        public int STConstitution
        {
            get { return stConstitution; }
            set
            {
                stConstitution = value;
                OnPropertyChanged(nameof(STConstitution));
            }
        }
        private int stIntelligence;

        public int STIntelligence
        {
            get { return stIntelligence; }
            set
            {
                stIntelligence = value;
                OnPropertyChanged(nameof(STIntelligence));
            }
        }
        private int stWisdom;

        public int STWisdom
        {
            get { return stWisdom; }
            set
            {
                stWisdom = value;
                OnPropertyChanged(nameof(STWisdom));
            }
        }
        private int stCharisma;

        public int STCharisma
        {
            get { return stCharisma; }
            set
            {
                stCharisma = value;
                OnPropertyChanged(nameof(STCharisma));
            }
        }
        #endregion

        private string _armorPro;
        public string ArmorPro
        {
            get { return _armorPro; }
            set
            {
                if (_armorPro != value)
                {
                    _armorPro = value;
                    OnPropertyChanged(nameof(ArmorPro));
                }
            }
        }

        private string _weaponsPro;
        public string WeaponsPro
        {
            get { return _weaponsPro; }
            set
            {
                if (_weaponsPro != value)
                {
                    _weaponsPro = value;
                    OnPropertyChanged(nameof(WeaponsPro));
                }
            }
        }

        private string _toolsPro;
        public string ToolsPro
        {
            get { return _toolsPro; }
            set
            {
                if (_toolsPro != value)
                {
                    _toolsPro = value;
                    OnPropertyChanged(nameof(ToolsPro));
                }
            }
        }
        private string _languagesPro;
        public string LanguagesPro
        {
            get { return _languagesPro; }
            set
            {
                if (_languagesPro != value)
                {
                    _languagesPro = value;
                    OnPropertyChanged(nameof(LanguagesPro));
                }
            }
        }

        private string _defenses;
        public string Defenses
        {
            get { return _defenses; }
            set
            {
                if (_defenses != value)
                {
                    _defenses = value;
                    OnPropertyChanged(nameof(Defenses));
                }
            }
        }

        private string _conditions;
        public string Conditions
        {
            get { return _conditions; }
            set
            {
                if (_conditions != value)
                {
                    _conditions = value;
                    OnPropertyChanged(nameof(Conditions));
                }
            }
        }

        private string _advantages;
        public string Advantages
        {
            get { return _advantages; }
            set
            {
                if (_advantages != value)
                {
                    _advantages = value;
                    OnPropertyChanged(nameof(Advantages));
                }
            }
        }

        private int _proficiency;

        public int Proficiency
        {
            get { return _proficiency; }
            set
            {
                _proficiency = value;
                STStrength = CalculateNumber(strength, value, STRSavingThrow);
                STDexterity = CalculateNumber(Dexterity, value, DEXSavingThrow);
                STCharisma = CalculateNumber(Charisma, value, CHASavingThrow);
                STConstitution = CalculateNumber(Constitution, value, CONSavingThrow);
                STWisdom = CalculateNumber(Wisdom, value, WISSavingThrow);
                STIntelligence = CalculateNumber(Intelligence, value, INTSavingThrow);
                AthleticsNumber = CalculateNumber(Strength, Proficiency, athletics);
                IntimidationNumber = CalculateNumber(Charisma, Proficiency, intimidation);
                PerformanceNumber = CalculateNumber(Charisma, Proficiency, performance);
                PersuasionNumber = CalculateNumber(Charisma, Proficiency, persuasion);
                AcrobaticsNumber = CalculateNumber(Dexterity, Proficiency, acrobatics);
                SleightofHandNumber = CalculateNumber(Dexterity, Proficiency, sleightOfHand);
                StealthNumber = CalculateNumber(Dexterity, Proficiency, stealth);
                ArcanaNumber = CalculateNumber(Intelligence, Proficiency, arcana);
                DeceptionNumber = CalculateNumber(Intelligence, Proficiency, deception);
                InvestigationNumber = CalculateNumber(Intelligence, Proficiency, investigation);
                NatureNumber = CalculateNumber(Intelligence, Proficiency, nature);
                ReligionNumber = CalculateNumber(Intelligence, Proficiency, religion);
                HistoryNumber = CalculateNumber(Intelligence, Proficiency, history);
                InsightNumber = CalculateNumber(Wisdom, Proficiency, insight);
                MedicineNumber = CalculateNumber(Wisdom, Proficiency, medicine);
                PerceptionNumber = CalculateNumber(Wisdom, Proficiency, perception);
                AnimalHandlingNumber = CalculateNumber(Wisdom, Proficiency, animalHandling);
                SurvivalNumber = CalculateNumber(Wisdom, Proficiency, survival);
            }
        }


        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set
            {
                if (_speed != value)
                {
                    _speed = value;
                    OnPropertyChanged(nameof(Speed));
                }
            }
        }

        private int _initiativ;
        public int Initiativ
        {
            get { return _initiativ; }
            set
            {
                if (_initiativ != value)
                {
                    _initiativ = value;
                    OnPropertyChanged(nameof(Initiativ));
                }
            }
        }

        private int _armorClass;
        public int ArmorClass
        {
            get { return _armorClass; }
            set
            {
                if (_armorClass != value)
                {
                    _armorClass = value;
                    OnPropertyChanged(nameof(ArmorClass));
                }
            }
        }

        private int _currentHP;
        public int CurrentHP
        {
            get { return _currentHP; }
            set
            {
                if (_currentHP != value)
                {
                    _currentHP = value;
                    OnPropertyChanged(nameof(CurrentHP));
                }
            }
        }

        private int _tempHP;
        public int TempHP
        {
            get { return _tempHP; }
            set
            {
                if (_tempHP != value)
                {
                    _tempHP = value;
                    OnPropertyChanged(nameof(TempHP));
                }
            }
        }

        private int _maxHP;
        public int MaxHP
        {
            get { return _maxHP; }
            set
            {
                if (_maxHP != value)
                {
                    _maxHP = value;
                    OnPropertyChanged(nameof(MaxHP));
                }
            }
        }

        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> items 
        { 
            get 
            { 
                return _items;
            } 
            set
            {
                _items = value;
                OnPropertyChanged(nameof(items));
            }
        }   

        #region Skills
        private bool acrobatics;

        public bool Acrobatics
        {
            get { return acrobatics; }
            set 
            { 
                acrobatics = value; 
                AcrobaticsNumber = CalculateNumber(Dexterity, Proficiency, acrobatics); 
                OnPropertyChanged(nameof(Acrobatics));
            }
        }

        private int acrobaticsNumber;

        public int AcrobaticsNumber
        {
            get { return acrobaticsNumber; }
            set
            {
                acrobaticsNumber = value;
                OnPropertyChanged(nameof(AcrobaticsNumber));
            }
        }


        private bool animalHandling;

        public bool AnimalHandling
        {
            get { return animalHandling; }
            set { animalHandling = value; AnimalHandlingNumber = CalculateNumber(Wisdom, Proficiency, animalHandling); OnPropertyChanged(nameof(AnimalHandling)); }
        }
        private int animalHandlingNumber;

        public int AnimalHandlingNumber
        {
            get { return animalHandlingNumber; }
            set
            {
                animalHandlingNumber = value;
                OnPropertyChanged(nameof(AnimalHandlingNumber));
            }
        }

        private bool arcana;

        public bool Arcana
        {
            get { return arcana; }
            set { arcana = value; ArcanaNumber = CalculateNumber(Intelligence, Proficiency, arcana); OnPropertyChanged(nameof(Arcana)); }
        }
        private int arcanaNumber;

        public int ArcanaNumber
        {
            get { return arcanaNumber; }
            set
            {
                arcanaNumber = value;
                OnPropertyChanged(nameof(ArcanaNumber));
            }
        }

        private bool athletics;

        public bool Athletics
        {
            get { return athletics; }
            set { athletics = value; AthleticsNumber = CalculateNumber(Strength, Proficiency, athletics); OnPropertyChanged(nameof(Athletics)); }
        }
        private int athleticsNumber;

        public int AthleticsNumber
        {
            get { return athleticsNumber; }
            set
            {
                athleticsNumber = value;
                OnPropertyChanged(nameof(AthleticsNumber));
            }
        }

        private bool deception;

        public bool Deception
        {
            get { return deception; }
            set { deception = value; DeceptionNumber = CalculateNumber(Intelligence, Proficiency, deception); OnPropertyChanged(nameof(Deception)); }
        }
        private int deceptionNumber;

        public int DeceptionNumber
        {
            get { return deceptionNumber; }
            set
            {
                deceptionNumber = value;
                OnPropertyChanged(nameof(DeceptionNumber));
            }
        }
        private bool history;

        public bool History
        {
            get { return history; }
            set { history = value; HistoryNumber = CalculateNumber(Intelligence, Proficiency, history); OnPropertyChanged(nameof(Arcana)); }
        }

        private int historyNumber;

        public int HistoryNumber
        {
            get { return historyNumber; }
            set
            {
                historyNumber = value;
                OnPropertyChanged(nameof(HistoryNumber));
            }
        }
        private bool insight;

        public bool Insight
        {
            get { return insight; }
            set { insight = value; InsightNumber = CalculateNumber(Wisdom, Proficiency, insight); OnPropertyChanged(nameof(Insight)); }
        }

        private int insightNumber;

        public int InsightNumber
        {
            get { return insightNumber; }
            set
            {
                insightNumber = value;
                OnPropertyChanged(nameof(InsightNumber));
            }
        }

        private bool intimidation;

        public bool Intimidation
        {
            get { return intimidation; }
            set { intimidation = value; IntimidationNumber = CalculateNumber(Charisma, Proficiency, intimidation); OnPropertyChanged(nameof(Intimidation)); }
        }

        private int intimidationNumber;

        public int IntimidationNumber
        {
            get { return intimidationNumber; }
            set
            {
                intimidationNumber = value;
                OnPropertyChanged(nameof(IntimidationNumber));
            }
        }

        private bool investigation;

        public bool Investigation
        {
            get { return investigation; }
            set { investigation = value; InvestigationNumber = CalculateNumber(Intelligence, Proficiency, investigation); OnPropertyChanged(nameof(Investigation)); }
        }
        private int investigationNumber;

        public int InvestigationNumber
        {
            get { return investigationNumber; }
            set
            {
                investigationNumber = value;
                OnPropertyChanged(nameof(InvestigationNumber));
            }
        }

        private bool medicine;

        public bool Medicine
        {
            get { return medicine; }
            set { medicine = value; MedicineNumber = CalculateNumber(Wisdom, Proficiency, medicine); OnPropertyChanged(nameof(Medicine)); }
        }
        private int medicineNumber;

        public int MedicineNumber
        {
            get { return medicineNumber; }
            set
            {
                medicineNumber = value;
                OnPropertyChanged(nameof(MedicineNumber));
            }
        }

        private bool nature;

        public bool Nature
        {
            get { return nature; }
            set { nature = value; NatureNumber = CalculateNumber(Intelligence, Proficiency, nature); OnPropertyChanged(nameof(Nature)); }
        }
        private int natureNumber;

        public int NatureNumber
        {
            get { return natureNumber; }
            set
            {
                natureNumber = value;
                OnPropertyChanged(nameof(NatureNumber));
            }
        }

        private bool perception;

        public bool Perception
        {
            get { return perception; }
            set { perception = value; PerceptionNumber = CalculateNumber(Wisdom, Proficiency, perception); OnPropertyChanged(nameof(Perception)); }
        }

        private int perceptionNumber;

        public int PerceptionNumber
        {
            get { return perceptionNumber; }
            set
            {
                perceptionNumber = value;
                OnPropertyChanged(nameof(PerceptionNumber));
            }
        }

        private bool performance;

        public bool Performance
        {
            get { return performance; }
            set { performance = value; PerformanceNumber = CalculateNumber(Charisma, Proficiency, performance); OnPropertyChanged(nameof(Performance)); }
        }

        private int performanceNumber;

        public int PerformanceNumber
        {
            get { return performanceNumber; }
            set
            {
                performanceNumber = value;
                OnPropertyChanged(nameof(PerformanceNumber));
            }
        }
        private bool persuasion;

        public bool Persuasion
        {
            get { return persuasion; }
            set
            {
                persuasion = value;
                PersuasionNumber = CalculateNumber(Charisma, Proficiency, persuasion);
                OnPropertyChanged(nameof(Persuasion));
            }
        }
        private int persuasionNumber;

        public int PersuasionNumber
        {
            get { return persuasionNumber; }
            set
            {
                persuasionNumber = value;
                OnPropertyChanged(nameof(PersuasionNumber));
            }
        }

        private bool religion;

        public bool Religion
        {
            get { return religion; }
            set { religion = value; ReligionNumber = CalculateNumber(Intelligence, Proficiency, religion); OnPropertyChanged(nameof(Religion)); }
        }
        private int religionNumber;

        public int ReligionNumber
        {
            get { return religionNumber; }
            set
            {
                religionNumber = value;
                OnPropertyChanged(nameof(ReligionNumber));
            }
        }

        private bool sleightOfHand;

        public bool SleightOfHand
        {
            get { return sleightOfHand; }
            set { sleightOfHand = value; SleightofHandNumber = CalculateNumber(Dexterity, Proficiency, sleightOfHand); OnPropertyChanged(nameof(SleightOfHand)); }
        }
        private int sleightofHandNumber;

        public int SleightofHandNumber
        {
            get { return sleightofHandNumber; }
            set
            {
                sleightofHandNumber = value;
                OnPropertyChanged(nameof(SleightofHandNumber));
            }
        }
        private bool stealth;

        public bool Stealth
        {
            get { return stealth; }
            set { stealth = value; StealthNumber = CalculateNumber(Dexterity, Proficiency, stealth); OnPropertyChanged(nameof(Stealth)); }
        }
        private int stealthNumber;

        public int StealthNumber
        {
            get { return stealthNumber; }
            set
            {
                stealthNumber = value;
                OnPropertyChanged(nameof(StealthNumber));
            }
        }
        private bool survival;

        public bool Survival
        {
            get { return survival; }
            set { survival = value; SurvivalNumber = CalculateNumber(Wisdom, Proficiency, survival); OnPropertyChanged(nameof(Survival)); }
        }
        private int survivalNumber;

        public int SurvivalNumber
        {
            get { return survivalNumber; }
            set
            {
                survivalNumber = value;
                OnPropertyChanged(nameof(SurvivalNumber));
            }
        }

        #endregion

        private bool _inspiration;
        public bool Inspiration
        {
            get { return _inspiration; }
            set
            {
                if (_inspiration != value)
                {
                    _inspiration = value;
                    OnPropertyChanged(nameof(Inspiration));
                }
            }
        }


        private bool strSavingThrow;

        public bool STRSavingThrow
        {
            get { return strSavingThrow; }
            set
            {
                strSavingThrow = value;
                STStrength = CalculateNumber(Strength, Proficiency, value);
            }
        }


        private bool dexSavingThrow;

        public bool DEXSavingThrow
        {
            get { return dexSavingThrow; }
            set
            {
                dexSavingThrow = value;
                STDexterity = CalculateNumber(Dexterity, Proficiency, value);
            }
        }

        private bool conSavingThrow;

        public bool CONSavingThrow
        {
            get { return conSavingThrow; }
            set
            {
                conSavingThrow = value;
                STConstitution = CalculateNumber(Constitution, Proficiency, value);
            }
        }

        private bool intSavingThrow;

        public bool INTSavingThrow
        {
            get { return intSavingThrow; }
            set
            {
                intSavingThrow = value;
                STIntelligence = CalculateNumber(Intelligence, Proficiency, value);
            }
        }

        private bool wisSavingThrow;

        public bool WISSavingThrow
        {
            get { return wisSavingThrow; }
            set
            {
                wisSavingThrow = value;
                STWisdom = CalculateNumber(Wisdom, Proficiency, value);
            }
        }

        private bool chaSavingThrow;

        public bool CHASavingThrow
        {
            get { return chaSavingThrow; }
            set
            {
                chaSavingThrow = value;
                STCharisma = CalculateNumber(Charisma, Proficiency, value);
            }
        }


        public bool[] DS_succ { get; set; } = new bool[3] { false, false, false };

        public bool[] DS_fail { get; set; } = new bool[3] { false, false, false };
        public ObservableCollection<Attacks> attacks = new ObservableCollection<Attacks>();
        public ObservableCollection<Spells> spells = new ObservableCollection<Spells>();

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public int ItemAmount { get; set; }

        public int ItemWeight { get; set; }

        private int modifier;

        public int Modifier
        {
            get { return modifier; }
            set { modifier = value; OnPropertyChanged(nameof(modifier)); }
        }
        private int countD4;

        public int CountD4
        {
            get { return countD4; }
            set { countD4 = value; OnPropertyChanged(nameof(countD4)); }
        }

        private int countD6;

        public int CountD6
        {
            get { return countD6; }
            set { countD6 = value; OnPropertyChanged(nameof(countD6)); }
        }
        private int countD8;

        public int CountD8
        {
            get { return countD8; }
            set { countD8 = value; OnPropertyChanged(nameof(countD8)); }
        }
        private int countD10;

        public int CountD10
        {
            get { return countD10; }
            set { countD10 = value; OnPropertyChanged(nameof(countD10)); }
        }
        private int countD12;

        public int CountD12
        {
            get { return countD12; }
            set { countD12 = value; OnPropertyChanged(nameof(countD12)); }
        }
        private int countD20;

        public int CountD20
        {
            get { return countD20; }
            set { countD20 = value; OnPropertyChanged(nameof(countD20)); }
        }
        private int countD100;

        public int CountD100
        {
            get { return countD100; }
            set { countD100 = value; OnPropertyChanged(nameof(countD100)); }
        }
        private string diceText;

        public string DiceText
        {
            get { return diceText; }
            set { diceText = value; OnPropertyChanged(nameof(diceText)); }
        }
        public ICommand PlusModifier { get; set; }
        public ICommand MinusModifier { get; set; }
        public ICommand SaveCmd { get; set; }
        public ICommand LoadCmd { get; set; }
        public ICommand SaveItemCmd { get; set; }


        private int CalculateNumber(int baseStat, int prof, bool isProf)
        {
            int result = Convert.ToInt32(Math.Floor((Convert.ToDouble(baseStat) - 10) / 2)); ;
            return (isProf) ? result + prof : result;
        }
        private void AddModifier()
        {
            Modifier++;
        }
        private void SubModifier()
        {
            Modifier--;
        }
        private void Save()
        {
            Character character = new Character()
            {
                CName = CName,
                Race = Race,
                Class = Class,
                Background = Background,
                Alignment = Alignment,
                Playername = Playername,
                Notes = Notes,
                ExperiencePoints = ExperiencePoints,
                HitDice = HitDice,
                Strength = Strength,
                Dexterity = Dexterity,
                Constitution = Constitution,
                Intelligence = Intelligence,
                Wisdom = Wisdom,
                Charisma = Charisma,
                ArmorClass = ArmorClass,
                ArmorPro = ArmorPro,
                WeaponsPro = WeaponsPro,
                ToolsPro = ToolsPro,
                LanguagesPro = LanguagesPro,
                Defenses = Defenses,
                Conditions = Conditions,
                Advantages = Advantages,
                Proficiency = Proficiency,
                Speed = Speed,
                Initiativ = Initiativ,
                CurrentHP = CurrentHP,
                items = items.ToList(),
                Acrobatics = Acrobatics,
                AnimalHandling = AnimalHandling,
                Arcana = Arcana,
                Athletics = Athletics,
                Deception = Deception,
                History = History,
                Insight = Insight,
                Intimidation = Intimidation,
                Investigation = Investigation,
                Medicine = Medicine,
                Nature = Nature,
                Perception = Perception,
                Performance = Performance,
                Persuasion = Persuasion,
                Religion = Religion,
                SleightOfHand = SleightOfHand,
                Stealth = Stealth,
                Survival = Survival,
                Inspiration = Inspiration,
                STRSavingThrow = STRSavingThrow,
                INTSavingThrow = INTSavingThrow,
                CONSavingThrow = CONSavingThrow,
                WISSavingThrow = WISSavingThrow,
                DEXSavingThrow = DEXSavingThrow,
                CHASavingThrow = CHASavingThrow,
                DS_succ = DS_succ,
                DS_fail = DS_fail,
                attacks = attacks.ToList(),
                spells = spells.ToList(),

            };
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV - File (*.csv)|*.csv|Text - File (*.txt)|*.txt";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream stream = new(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                using (StreamWriter writer = new(stream, Encoding.UTF8))
                {
                    writer.WriteLine(character.ToCsv());
                    writer.Write("\n@\n");
                    writer.WriteLine(CsvSerializer.SerializeToCsv(items));
                }
            }
        }

        private void Load()
        {
            Character character = new();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV - File (*.csv)|*.csv|Text - File (*.txt)|*.txt";
            openFileDialog.AddExtension = true;
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream stream = new(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                using(StreamReader reader = new(stream, Encoding.UTF8))
                {
                    string input;
                    string twoCSV = "";
                    while((input = reader.ReadLine()) != null)
                    {
                        twoCSV += input + "\r\n";
                    }
                    string[] split = twoCSV.Split("\n@\r\n");
                    character = split[0].FromCsv<Character>();
                    items = split[1].FromCsv<ObservableCollection<Item>>();
                    //character = split[1].FromCsv<Character>();  
                    //string[] splited = twoCSV.Split("\r\n");
                    //character = splited[0].FromCsv<Character>();
                    //items = splited[1].FromCsv<ObservableCollection<Item>>();
                    CName = character.CName;
                    Race = character.Race;
                    Class = character.Class;
                    Background = character.Background;
                    Alignment = character.Alignment;
                    Playername = character.Playername;
                    Notes = character.Notes;
                    ExperiencePoints = character.ExperiencePoints;
                    HitDice = character.HitDice;
                    Strength = character.Strength;
                    Dexterity = character.Dexterity;
                    Constitution = character.Constitution;
                    Intelligence = character.Intelligence;
                    Wisdom = character.Wisdom;
                    Charisma = character.Charisma;
                    ArmorClass = character.ArmorClass;
                    ArmorPro = character.ArmorPro;
                    WeaponsPro = character.WeaponsPro;
                    ToolsPro = character.ToolsPro;
                    LanguagesPro = character.LanguagesPro;
                    Defenses = character.Defenses;
                    Conditions = character.Conditions;
                    Advantages = character.Advantages;
                    Proficiency = character.Proficiency;
                    Speed = character.Speed;
                    Initiativ = character.Initiativ;
                    CurrentHP = character.CurrentHP;
                    MaxHP = character.MaxHP;
                    TempHP = character.TempHP;
                    character.items = items.ToList();
                    Acrobatics = character.Acrobatics;
                    AnimalHandling = character.AnimalHandling;
                    Arcana = character.Arcana;
                    Athletics = character.Athletics;
                    Deception = character.Deception;
                    History = character.History;
                    Insight = character.Insight;
                    Intimidation = character.Intimidation;
                    Investigation = character.Investigation;
                    Medicine = character.Medicine;
                    Nature = character.Nature;
                    Perception = character.Perception;
                    Performance = character.Performance;
                    Persuasion = character.Persuasion;
                    Religion = character.Religion;
                    SleightOfHand = character.SleightOfHand;
                    Stealth = character.Stealth;
                    Survival = character.Survival;
                    Inspiration = character.Inspiration;
                    STRSavingThrow = character.STRSavingThrow;
                    INTSavingThrow = character.INTSavingThrow;
                    CONSavingThrow = character.CONSavingThrow;
                    WISSavingThrow = character.WISSavingThrow;
                    DEXSavingThrow = character.DEXSavingThrow;
                    CHASavingThrow = character.CHASavingThrow;
                    DS_succ = character.DS_succ;
                    DS_fail = character.DS_fail;
                    character.attacks = attacks.ToList();
                    character.spells = spells.ToList();
                }
            }
        }
        private void SaveItem()
        {
            items.Add(new Item(ItemName, ItemDescription, ItemAmount, ItemWeight));
        }

        public CharSheetViewModel()
        {
            items = new ObservableCollection<Item>();
            PlusModifier = new RelayCommand(AddModifier);
            MinusModifier = new RelayCommand(SubModifier);
            SaveCmd = new RelayCommand(Save);
            SaveItemCmd = new RelayCommand(SaveItem);
            LoadCmd = new RelayCommand(Load);
        }
    }
}

