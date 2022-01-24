using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DS_Final_Project
{ 
    public class DiseaseEffect
    {
        string name;
        bool IsPositive;
        public DiseaseEffect(string name, bool isGood)
        {
            this.name = name;
            this.IsPositive = isGood;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        public bool IsPositiveFunc { get => IsPositive; set => IsPositive = value; }

        public override string ToString()
        {
            return string.Format("Drug : " + name);
        }
    }
    class Disease 
    {
        string name;
        List<DiseaseEffect> effects;
        public List<DiseaseEffect> Effects { get => effects; }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public Disease(string name)
        {
            this.name = name;
            effects = new List<DiseaseEffect>();
        }
        public void addEffect(DiseaseEffect e)
        {
            effects.Add(e);
        }
        public void deleteEffect(string name)
        {
            effects = effects.Where(x => x.Name != name).ToList();
        }
        public override string ToString()
        {
            string aux = string.Format("Dis_" + name + " : ");
            foreach (var x in effects)
            {
                aux += string.Format("(Drug_{0},{1}) ; ", x.Name, x.IsPositiveFunc ? "+" : "-");
            }
            return aux.Substring(0, aux.Length - 3);
        }

        public List<bool> drugHasEffect(string name)
        {
            List<bool> aux = new List<bool>();
            aux.Add(false);
            var eff = effects.Where(x => x.Name == name).ToArray();
            if (eff.Length != 0)
            {
                aux[0] = true;
                aux.Add(eff.First().IsPositiveFunc);
            }
            return aux;
            //[0] = drug effect on disease (if tru the -> [1] : positive or negative effect)
        }
    }

    public class DrugEffect
    {
        string drug, DrgEffect;

        public DrugEffect(string drug, string e)
        {
            this.drug = drug;
            this.DrgEffect = e;
        }

        public string Drug
        {
            get => drug;
            set => drug = value;
        }
        public string Eff
        { 
            get => DrgEffect;
            set => DrgEffect = value;
        }

        public override string ToString()
        {
            return string.Format("Drug : {0}, Effect : {1}", drug, DrgEffect);
        }
    }
    class Drug
    {
        string name;
        float price;
        List<DrugEffect> effects = new List<DrugEffect>();
        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        //drugs that have effects on this specific drug
        public List<DrugEffect> Effects
        {
            get => effects;
        }
        public Drug(string name, float price)
        {
            this.price = price;
            this.name = name;
            effects = new List<DrugEffect>();
        }
        public void addEffect(DrugEffect effect)
        {
            effects.Add(effect);
        }
        public void deleteEffect(string name)
        {
            effects = effects.Where(x => x.Drug != name).ToList();
        }

        public override string ToString()
        {
            string aux = string.Format("Drug_" + name + " : ");
            foreach (var x in effects)
            {
                aux += string.Format("(Drug_{0},Eff_{1}) ; ", x.Drug, x.Eff);
            }
            return aux.Substring(0, aux.Length - 3);
        }
    }

    class cnsl
    {
        static private ConsoleColor mainConsoleBackgroundColor = ConsoleColor.Black;
        static private ConsoleColor mainConsoleForegroundColor = ConsoleColor.DarkRed;
        static private string DashedLine = "----";
        static private string PointerLine = ">>>";
        static public ConsoleColor MainConsoleBackgroundColor { get => mainConsoleBackgroundColor; set => mainConsoleBackgroundColor = value; }
        static public ConsoleColor MainConsoleForegroundColor { get => mainConsoleForegroundColor; set => mainConsoleForegroundColor = value; }
        static public void Initialize()
        {
            Console.BackgroundColor = MainConsoleBackgroundColor;
            Console.ForegroundColor = MainConsoleForegroundColor;
            Console.Clear();
        }
        static public void Clear()
        {
            Console.BackgroundColor = MainConsoleBackgroundColor;
            Console.ForegroundColor = MainConsoleForegroundColor;
            Console.Clear();
        }
        static public void ResetColor()
        {
            Console.BackgroundColor = MainConsoleBackgroundColor;
            Console.ForegroundColor = MainConsoleForegroundColor;
        }
        static public void WriteError(string Massage)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(PointerLine + " <ERROR>" + Massage);
            ResetColor();
        }
        static public void WriteLine(string Massage)
        {
            Console.WriteLine(PointerLine + Massage);
            ResetColor();
        }
        static public void Write(string Massage)
        {
            Console.Write(Massage);
            ResetColor();
        }
        static public void WriteTitle(string Massage)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(DashedLine + " " + Massage + " " + DashedLine);
            ResetColor();
        }
        static public void WriteLog(string Massage)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Massage);
            ResetColor();
        }
        static public void WriteSubTitle(string Massage)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine(PointerLine + Massage);
            ResetColor();
        }
        static public void PrintErrorLine(int kind = 1)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            if (kind == 1)
                Console.WriteLine("=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=");
            else
                Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            ResetColor();
        }
        static public void PrintLine(int kind = 1)
        {
            if (kind == 1)
                Console.WriteLine("=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=||=");
            else
                Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
        }
        static public void ReadKey()
        {
            Write("Press Any Key To Return ... ");
            Console.ReadKey();
        }
        static public string ReadLine()
        {
            string Massage;
            Console.BackgroundColor = ConsoleColor.White;
            Massage = Console.ReadLine();
            ResetColor();
            return Massage;
        }
        static public void WriteListGuide(string TitleOfMenu, params string[] MenuItems)
        {
            WriteTitle(TitleOfMenu);
            WriteSubTitle(DashedLine);
            foreach (string MenuItem in MenuItems)
            {
                WriteSubTitle(MenuItem);
            }
            WriteSubTitle(DashedLine);
        }
    }

    partial class Program
    {
        //Files
        static string pathURL = "../../../DATA/DataSets/";
        static string alergies = "alergies.txt";
        static string diseases = "diseases.txt";
        static string drugs = "drugs.txt";
        static string effects = "effects.txt";

        static string error = "";

        // Don't read files again
        static bool isRead = false;

        // total time
        static double time = 0;

        //init function
        static void initiat()
        {
            Console.Title = "DSFinalProject";
            cnsl.Initialize();
            for (int i = 0; i < size; i++)
            {
                Drugs[i] = new List<Drug>();
                Diseases[i] = new List<Disease>();
            }
        }

        static int size = 100;

        static List<Drug>[] Drugs = new List<Drug>[size];
        static List<Disease>[] Diseases = new List<Disease>[size];

        // Put into Hashtable
        static int getIndex(string name) => name.ToCharArray().Sum(x => x) % size;

        // Search In Lists
        static Disease getDisease(ref List<Disease> list, string name) //=> remove first input 
        {
            //var list = Diseases[getIndex(name)];
            foreach (var x in list)
                if (x.Name == name)
                    return x;
            throw new Exception("No such a disease!");
        }
        static Drug getDrug(ref List<Drug> list, string name) //=> remove first input 
        {
            //var list = Drugs[getIndex(name)];
            foreach (var x in list)
                if (x.Name == name)
                    return x;
            throw new Exception("No such a drug!");
        }
        static void removeDisease(ref List<Disease> list, string name) //=> remove first input 
        {
            //var list = Diseases[getIndex(name)];
            int index = -1;
            for (int i = 0; i < list.Count; i++)
                if (list[i].Name == name)
                    index = i;
            if (index == -1)
                throw new Exception("No such a disease !");
            list.RemoveAt(index);
        }
        static void removetDrug(ref List<Drug> list, string name) //=> remove first input 
        {
            //var list = Drugs[getIndex(name)];
            int index = -1;
            for (int i = 0; i < list.Count; i++)
                if (list[i].Name == name)
                    index = i;
            if (index == -1)
                throw new Exception("No such a drug !");
            var drugs = list[index].Effects.Select(x => x.Drug);
            foreach (var drug in drugs)
                getDrug(ref Drugs[getIndex(drug)], drug).deleteEffect(name);
            for (int listIndex = 0; listIndex < size; listIndex++)
                for (int disease = 0; disease < Diseases[listIndex].Count; disease++)
                    Diseases[listIndex][disease].deleteEffect(name);
            list.RemoveAt(index);
        }
        //Enum
        enum commands
        {
            startToRead = 1,
            checkDrugsIntraction,
            checkAllergyInDrugs,
            TotalPrice,
            changePriceOfDrug,
            AddOrDeleteADrugAndDisease,
            searchInDrugsOrDiseases,
            Exit = 8
        }

        enum choices
        {
            Drug = 1,
            Disease,

            Back = 9
        }

        enum CDcommand
        {
            Add = 1,
            Delete,

            Back = 9
        }
        enum files
        {
            alergies,
            diseases,
            drugs,
            effects
        }

        // to print an enum and get one
        static T pagEnum<T>(string message = "Orders") where T : Enum
        {
            T temp = default;

            while (true)
            {
                cnsl.Clear();
                printError();
                try
                {
                    PrintEnum<T>(message);
                    temp = GetEnum<T>();
                    break;
                }
                catch (ArgumentException)
                {
                    error += "Enter correct command !!";
                }
                catch (Exception e)
                {
                    error += e.Message;
                }
            }
            return temp;
        }
        // to print an Enum
        static void PrintEnum<T>(string message) where T : Enum
        {
            int counter = 1;

            cnsl.WriteTitle(message);
            foreach (T temp in Enum.GetValues(typeof(T)))
            {
                if (temp.ToString() == "Print_Sizes")
                    continue;

                if (temp.ToString() == "Back" || temp.ToString() == "Exit")
                {
                    Console.WriteLine();
                    counter = 8;
                }

                cnsl.WriteSubTitle(String.Format(" ({0}){1}", counter, temp));
                counter++;
            }

        }

        //to get an enum from user
        static T GetEnum<T>()
        {
            Console.Write("\nEnter Name or its Number : ");
            string tempStr = Console.ReadLine().ToLower();
            if (String.IsNullOrEmpty(tempStr))
                throw new Exception("Enter number or word correctly !!");
            int tempInt = 0;
            bool isUsingInt = true;
            try
            {
                tempInt = int.Parse(tempStr);
            }
            catch { isUsingInt = false; }
            if (isUsingInt)
                if (Enum.IsDefined(typeof(T), tempInt))
                    tempStr = Enum.GetName(typeof(T), tempInt);
                else
                    throw new Exception(" Out of range!");
            return (T)Enum.Parse(typeof(T), tempStr, true);
        }

        //print error
        static void printError()
        {
            if (!String.IsNullOrEmpty(error))
            {
                cnsl.PrintErrorLine();
                cnsl.WriteError(string.Format("{0,-50}", error));
                error = "";
                cnsl.PrintErrorLine();
            }
        }
        //doesn't have underlines
        static void notFoundError()
        {
            if (!String.IsNullOrEmpty(error))
            {
                cnsl.WriteError(error);
                error = "";
            }
        }

        //to create a wait and remain previous orders
        static void wait()
        {
            Console.Write("Press Enter or anything else to continue ... ");
            Console.ReadKey();
        }

        // to find effects of a drug on diseases
        //get a drug name and find p and n effects of that on diseases
        static Dictionary<string, List<string>> effectsOfDrugOnDiseases(string name)
        {
            Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();
            List<string> positives = new List<string>();
            List<string> negatives = new List<string>();

            foreach (var list in Diseases)
                foreach (var disease in list)
                {
                    var temp = disease.drugHasEffect(name);
                    if (temp[0])
                    {
                        if (temp[1])
                            positives.Add(disease.Name);
                        else
                            negatives.Add(disease.Name);
                    }
                }
            //Add to dictionary
            output.Add("positive", positives);
            output.Add("negative", negatives);
            return output;
        }

        // to read a file
        static void readFiles(string path, files fileKind)
        {
            using (StreamReader file = new StreamReader(path))
            {
                string line;
                double auxTime;
                Stopwatch stopwatch = new Stopwatch();

                switch (fileKind)
                {
                    case files.alergies:
                        stopwatch.Start();
                        while ((line = file.ReadLine()) != null)
                        {
                            string[] temp = line.Split(' ', ':', ';').Where(z => !String.IsNullOrWhiteSpace(z)).ToArray();
                            string name = temp[0].Substring(4); // disease
                            int index = getIndex(name);
                            //x is disease and if it couldn't find that it will give an exception 
                            var x = getDisease(ref Diseases[index], name);
                            //cause we don't know the number of effects
                            for (int i = 1; i < temp.Length; i++)
                            {
                                temp[i] = temp[i].Substring(6, temp[i].Length - 7); //remove () and ...
                                string[] eff = temp[i].Split(',');
                                x.addEffect(new DiseaseEffect(eff[0], eff[1] == "+")); // drug    +-
                            }
                        }
                        stopwatch.Stop();
                        auxTime = stopwatch.Elapsed.TotalSeconds;
                        time += auxTime;
                        Console.WriteLine("Allergies file time : " + auxTime + " s");
                        stopwatch.Reset(); //if we don't stop it, it will continue ...
                        break;

                    case files.diseases:
                        stopwatch.Start();
                        while ((line = file.ReadLine()) != null)
                        {
                            string name = line.Substring(4); //remove Dis_
                            int index = getIndex(name);
                            Diseases[index].Add(new Disease(name));
                        }
                        stopwatch.Stop();
                        auxTime = stopwatch.Elapsed.TotalMilliseconds / 1000;
                        time += auxTime;
                        Console.WriteLine("Diseases file time : " + auxTime + " s");
                        stopwatch.Reset();
                        break;

                    case files.drugs:
                        stopwatch.Start();
                        while ((line = file.ReadLine()) != null)
                        {
                            string[] temp = line.Split(' ', ':');
                            string name = temp[0].Substring(5); //remove Drug_
                            int index = getIndex(name);
                            Drugs[index].Add(new Drug(name, float.Parse(temp[3])));
                        }
                        stopwatch.Stop();
                        auxTime = stopwatch.Elapsed.TotalSeconds;
                        time += auxTime;
                        Console.WriteLine("Drugs file time : " + auxTime + " s");
                        stopwatch.Reset();
                        break;

                    case files.effects:
                        stopwatch.Start();
                        while ((line = file.ReadLine()) != null)
                        {
                            var temp = line.Split(' ', ':', ';').Where(z => !String.IsNullOrWhiteSpace(z)).ToArray();
                            string name = temp[0].Substring(5); //remove Drug_
                            int index = getIndex(name);
                            var x = getDrug(ref Drugs[index], name);
                            for (int i = 1; i < temp.Length; i++)
                            {
                                temp[i] = temp[i].Substring(6, temp[i].Length - 7);
                                string[] eff = temp[i].Split(',');
                                x.addEffect(new DrugEffect(eff[0], eff[1].Substring(4)));
                            }
                        }
                        stopwatch.Stop();
                        auxTime = stopwatch.Elapsed.TotalSeconds;
                        time += auxTime;
                        Console.WriteLine("Effects file time : " + auxTime + " s");
                        stopwatch.Reset();
                        break;
                }
            }
        }
        // generate random effect
        static string randomEffect()
        {
            Random rnd = new Random();
            string temp = "";
            for (int i = 0; i < 10; i++)
                temp += (char)rnd.Next(97, 123);
            return temp;
        }
        // add a item
        static void addDrug(string name, float price)
        {
            //random effect
            Random rnd = new Random();

            int[] weightedNumbers = { 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 4, 5 };

            int index = getIndex(name);
            Drug temp = new Drug(name, price);

            List<Drug> randomEffects = new List<Drug>();
            int count = weightedNumbers[rnd.Next(weightedNumbers.Length)];
            while (true)
            {
                if (count == 0)
                    break;
                int selectedIndex = rnd.Next(0, size);
                int n = Drugs[selectedIndex].Count;
                if (n == 0)
                    continue;
                int number = rnd.Next(0, n);
                Drug selected = Drugs[selectedIndex][number];
                if (!randomEffects.Contains(selected))
                {
                    randomEffects.Add(selected);
                    temp.addEffect(new DrugEffect(selected.Name, randomEffect()));
                    count--;
                }
            }
            Drugs[index].Add(temp);
            cnsl.PrintLine(2);
            cnsl.WriteSubTitle("Details :");
            Console.WriteLine("Name : {0}\nPrice : {1}", name, price);
            Console.WriteLine("\nEffects :");
            foreach (var x in temp.Effects)
                Console.WriteLine(" " + x);
            using (StreamWriter sw = File.AppendText(pathURL + effects))
                sw.WriteLine(temp.ToString());
            using (StreamWriter sw = File.AppendText(pathURL + drugs))
                sw.WriteLine(String.Format("Drug_{0} : {1}", name, price));
            cnsl.PrintLine(2);
        }
        static void addDisease(string name)
        {
            Random rnd = new Random();
            //random drugs
            int[] weightedNumbers = { 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 4, 5 };

            int index = getIndex(name);
            Disease temp = new Disease(name);

            List<Disease> randomEffects = new List<Disease>();
            int count = weightedNumbers[rnd.Next(weightedNumbers.Length)];
            while (true)
            {
                if (count == 0)
                    break;
                int selectedIndex = rnd.Next(0, size);
                int n = Drugs[selectedIndex].Count;
                if (n == 0)
                    continue;
                int number = rnd.Next(0, n);
                Disease selected = Diseases[selectedIndex][number];
                if (!randomEffects.Contains(selected))
                {
                    randomEffects.Add(selected);
                    temp.addEffect(new DiseaseEffect(selected.Name, rnd.Next(2) == 0));
                    count--;
                }
            }
            Diseases[index].Add(temp);
            cnsl.PrintLine(2);
            cnsl.WriteSubTitle("Details :");
            Console.WriteLine("Name : {0}", name);
            Console.WriteLine("\nAllergies :");
            foreach (var x in temp.Effects)
                Console.WriteLine(" " + x);
            using (StreamWriter sw = File.AppendText(pathURL + alergies))
                sw.WriteLine(temp.ToString());
            using (StreamWriter sw = File.AppendText(pathURL + diseases))
                sw.WriteLine(String.Format("Dis_{0}", name));
            cnsl.PrintLine(2);
        }
        static void Main(string[] args)
        {
            initiat();
            bool exit = false;
            while (!exit)
            {
                var command = pagEnum<commands>(); //use list
                Stopwatch sw = new Stopwatch();
                double exeTime = 0;
                int index = 0;
                try
                {
                    switch (command)
                    {
                        case commands.startToRead:
                            if (isRead)
                                throw new Exception("you've already read files!");
                            isRead = true;
                            Console.Clear();
                            cnsl.WriteTitle("Reading files and creating datasets!");
                            readFiles(pathURL + diseases, files.diseases);
                            readFiles(pathURL + drugs, files.drugs);
                            readFiles(pathURL + effects, files.effects);
                            readFiles(pathURL + alergies, files.alergies);
                            cnsl.PrintLine();
                            cnsl.WriteLog("total time = " + time + " s");
                            cnsl.PrintLine();
                            wait();
                            break;

                        case commands.checkDrugsIntraction:
                            Console.Clear();
                            List<Drug> drugPrescription = new List<Drug>();
                            List<string> interactions = new List<string>();
                            cnsl.WriteTitle("Enter {Drug's Name} or End or Enter key to see the result!");
                            while (true)
                            {
                                notFoundError();
                                Console.Write("Drug Name : ");
                                string inputDrug = Console.ReadLine();
                                if (inputDrug.ToLower() == "exit" || inputDrug.ToLower() == "finish" || inputDrug.ToLower() == "end" || String.IsNullOrEmpty(inputDrug))
                                    break;
                                sw.Start();
                                index = getIndex(inputDrug);
                                try
                                {
                                    drugPrescription.Add(getDrug(ref Drugs[index], inputDrug));
                                }
                                catch
                                {
                                    error += "There's no drug with this name!";
                                }
                                sw.Stop();
                                exeTime += sw.Elapsed.TotalSeconds;
                            }
                            sw.Start();
                            //drug collissions
                            for (int i = 0; i < drugPrescription.Count - 1; i++)
                            {
                                var effects = drugPrescription[i].Effects.Select(x => x.Drug);
                                for (int j = i + 1; j < drugPrescription.Count; j++)
                                    if (effects.Contains(drugPrescription[j].Name))
                                        interactions.Add(String.Format("{0} & {1}", drugPrescription[i].Name, drugPrescription[j].Name));
                            }
                            cnsl.PrintLine(2);
                            cnsl.WriteSubTitle("Interactions :");
                            if (interactions.Count == 0)
                                Console.WriteLine("no interactions!");
                            else
                                foreach (var x in interactions)
                                    Console.WriteLine(x);
                            sw.Stop();
                            exeTime += sw.Elapsed.TotalSeconds;
                            cnsl.PrintLine(2);
                            Console.WriteLine("Time : " + exeTime + " s");
                            cnsl.PrintLine(2);
                            exeTime = 0;
                            sw.Reset();
                            wait();
                            break;

                        case commands.checkAllergyInDrugs:
                            Console.Clear();
                            List<Disease> clientDiseases = new List<Disease>();
                            List<Drug> clientDrugPrescription = new List<Drug>();
                            List<String> mediacalAllergy = new List<string>();
                            cnsl.WriteTitle("Enter {Disease's Name} or End or Enter key to see the result!");
                            while (true)
                            {
                                notFoundError();
                                Console.Write("Disease Name : ");
                                string inputDisease = Console.ReadLine();

                                if (inputDisease.ToLower() == "exit" || inputDisease.ToLower() == "finish" || inputDisease.ToLower() == "end" || String.IsNullOrEmpty(inputDisease))
                                    break;

                                sw.Start();
                                index = getIndex(inputDisease);
                                try
                                {
                                    clientDiseases.Add(getDisease(ref Diseases[index], inputDisease));
                                }
                                catch
                                {
                                    error += "there's no disease with this name!";
                                }
                                sw.Stop();
                                exeTime += sw.Elapsed.TotalSeconds;
                            }

                            cnsl.WriteTitle("Enter {Drug's Name} or End or Enter key to see the result!");
                            while (true)
                            {
                                notFoundError();
                                Console.Write("Drug Name : ");
                                string inputDrug = Console.ReadLine();

                                if (inputDrug.ToLower() == "exit" || inputDrug.ToLower() == "finish" || inputDrug.ToLower() == "end" || String.IsNullOrEmpty(inputDrug))
                                    break;

                                sw.Start();
                                index = getIndex(inputDrug);
                                try
                                {
                                    clientDrugPrescription.Add(getDrug(ref Drugs[index], inputDrug));
                                }
                                catch
                                {
                                    error += "there's no drug with this name!";
                                }
                                sw.Stop();
                                exeTime += sw.Elapsed.TotalSeconds;
                            }
                            sw.Start();
                            foreach (var disease in clientDiseases)
                                foreach (var drug in clientDrugPrescription)
                                {
                                    var temp = disease.drugHasEffect(drug.Name);
                                    if (temp[0] && !temp[1])
                                        mediacalAllergy.Add(string.Format("Disease : {0} & Drug : {1}", disease.Name, drug.Name));
                                }
                            cnsl.PrintLine(2);
                            cnsl.WriteSubTitle("allergy :");
                            if (mediacalAllergy.Count == 0)
                                Console.WriteLine("no allergies!");
                            else
                                foreach (var x in mediacalAllergy)
                                    Console.WriteLine(x);
                            sw.Stop();
                            exeTime += sw.Elapsed.TotalSeconds;
                            cnsl.PrintLine(2);
                            Console.WriteLine("Time : " + exeTime + " s");
                            cnsl.PrintLine(2);
                            exeTime = 0;
                            sw.Reset();
                            wait();
                            break;

                        case commands.TotalPrice:
                            Console.Clear();
                            cnsl.WriteTitle("Enter {Drug's Name} or End or Enter key to see the result!");
                            float price = 0;
                            while (true)
                            {
                                printError();
                                Console.Write("Drug Name : ");
                                string inputDrug = Console.ReadLine();

                                if (inputDrug.ToLower() == "exit" || inputDrug.ToLower() == "finish" || inputDrug.ToLower() == "end" || String.IsNullOrEmpty(inputDrug))
                                    break;

                                sw.Start();
                                index = getIndex(inputDrug);
                                try
                                {
                                    price += getDrug(ref Drugs[index], inputDrug).Price;
                                }
                                catch
                                {
                                    error += "there's no drug with this name!";
                                }
                                sw.Stop();
                                exeTime += sw.Elapsed.TotalSeconds;
                            }
                            cnsl.PrintLine();
                            cnsl.WriteSubTitle("Total Price : " + price);
                            cnsl.PrintLine(2);
                            Console.WriteLine("Time : " + exeTime + " s");
                            cnsl.PrintLine(2);
                            exeTime = 0;
                            sw.Reset();
                            wait();
                            break;

                        case commands.changePriceOfDrug:
                            Console.Clear();
                            cnsl.WriteTitle("Change the price of drugs");
                            try
                            {
                                Console.Write("Enter Amount in percentage (for example 50.4) : ");
                                float percent = int.Parse(Console.ReadLine());
                                if (percent != 0)
                                {
                                    sw.Start();
                                    float ratio = 1.0f + (float)percent / 100;
                                    File.WriteAllText(pathURL + drugs, String.Empty);
                                    using (StreamWriter file = new StreamWriter(pathURL + drugs))
                                    {
                                        for (int list = 0; list < size; list++)
                                            for (int drug = 0; drug < Drugs[list].Count; drug++)
                                            {
                                                Drugs[list][drug].Price = ratio * Drugs[list][drug].Price;
                                                file.WriteLine(String.Format("{0}{1} : {2}", "Drug_", Drugs[list][drug].Name, Drugs[list][drug].Price));
                                            }
                                    }
                                    sw.Stop();
                                    cnsl.PrintLine(2);
                                    Console.WriteLine("Time : " + sw.Elapsed.TotalSeconds + " s");
                                    cnsl.PrintLine(2);
                                    sw.Reset();
                                    wait();
                                }
                            }
                            catch
                            {
                                throw new Exception("Enter your input in correct format!");
                            }
                            break;

                        case commands.AddOrDeleteADrugAndDisease:
                            while (true)
                            {
                                var CD = pagEnum<CDcommand>();
                                if (CD == CDcommand.Back)
                                    break;
                                var typeCD = pagEnum<choices>("Choose one to " + CD.ToString().ToLower() + " :");
                                if (typeCD != choices.Back)
                                {
                                    Console.Write("Enter name of {0} : ", typeCD.ToString());
                                    //get a name
                                    string inputName = Console.ReadLine();

                                    switch (CD)
                                    {
                                        case CDcommand.Add:
                                            switch (typeCD)
                                            {
                                                case choices.Disease:
                                                    sw.Start();
                                                    addDisease(inputName);
                                                    sw.Stop();
                                                    Console.WriteLine("Adding {0} took about {1} seconds!", inputName, sw.Elapsed.TotalSeconds);
                                                    break;

                                                case choices.Drug:
                                                    Console.Write("Enter price of drug : ", typeCD.ToString());
                                                    int inputPrice = 0;
                                                    try
                                                    {
                                                        inputPrice = int.Parse(Console.ReadLine());
                                                    }
                                                    catch
                                                    {
                                                        throw new Exception("Pls enter the price in the correct format!");
                                                    }
                                                    sw.Start();
                                                    addDrug(inputName, inputPrice);
                                                    sw.Stop();
                                                    Console.WriteLine("Adding {0} took about {1} seconds!", inputName, sw.Elapsed.TotalSeconds);
                                                    break;
                                            }
                                            break;

                                        case CDcommand.Delete:
                                            switch (typeCD)
                                            {
                                                case choices.Disease:
                                                    sw.Start();
                                                    index = getIndex(inputName);
                                                    removeDisease(ref Diseases[index], inputName);
                                                    File.WriteAllText(pathURL + diseases, String.Empty);
                                                    File.WriteAllText(pathURL + alergies, String.Empty);
                                                    using (StreamWriter diseasesFile = new StreamWriter(pathURL + diseases))
                                                    {
                                                        using (StreamWriter alergiesFile = new StreamWriter(pathURL + alergies))
                                                        {
                                                            foreach (var list in Diseases)
                                                                foreach (var disease in list)
                                                                {
                                                                    diseasesFile.WriteLine("Dis_" + disease.Name);
                                                                    if (disease.Effects.Count != 0)
                                                                        alergiesFile.WriteLine(disease.ToString());
                                                                }
                                                        }
                                                    }
                                                    sw.Stop();
                                                    Console.WriteLine("Delete " + inputName + " time : " + sw.Elapsed.TotalSeconds + " s");
                                                    sw.Reset();
                                                    break;

                                                case choices.Drug:
                                                    sw.Start();
                                                    index = getIndex(inputName);
                                                    removetDrug(ref Drugs[index], inputName);
                                                    File.WriteAllText(pathURL + drugs, String.Empty);
                                                    File.WriteAllText(pathURL + effects, String.Empty);
                                                    File.WriteAllText(pathURL + alergies, String.Empty);
                                                    using (StreamWriter drugsFile = new StreamWriter(pathURL + drugs))
                                                    {
                                                        using (StreamWriter effectsFile = new StreamWriter(pathURL + effects))
                                                        {
                                                            foreach (var list in Drugs)
                                                                foreach (var drug in list)
                                                                {
                                                                    drugsFile.WriteLine(string.Format("Drug_{0} : {1}", drug.Name, drug.Price));
                                                                    if (drug.Effects.Count != 0)
                                                                        effectsFile.WriteLine(drug.ToString());
                                                                }
                                                        }
                                                    }
                                                    using (StreamWriter alergiesFile = new StreamWriter(pathURL + alergies))
                                                    {
                                                        foreach (var list in Diseases)
                                                            foreach (var disease in list)
                                                                if (disease.Effects.Count != 0)
                                                                    alergiesFile.WriteLine(disease.ToString());
                                                    }
                                                    sw.Stop();
                                                    cnsl.PrintLine(2);
                                                    Console.WriteLine("Delete " + inputName + " time : " + sw.Elapsed.TotalSeconds + " s");
                                                    cnsl.PrintLine(2);
                                                    sw.Reset();
                                                    break;
                                            }
                                            break;
                                    }
                                    wait();
                                    break;
                                }
                            }
                            break;

                        case commands.searchInDrugsOrDiseases:
                            var typeS = pagEnum<choices>("Search In ...");
                            string name = null;
                            if (typeS != choices.Back)
                            {
                                Console.Write("Enter name of {0} : ", typeS.ToString());
                                name = Console.ReadLine();
                                index = getIndex(name);
                                Console.Clear();
                                cnsl.WriteTitle(name);
                            }
                            switch (typeS)
                            {
                                case choices.Disease:
                                    var disease = getDisease(ref Diseases[index], name);
                                    sw.Start();
                                    var positives = disease.Effects.Where(x => x.IsPositiveFunc);
                                    var negatives = disease.Effects.Where(x => !x.IsPositiveFunc);
                                    Console.WriteLine();
                                    cnsl.WriteSubTitle("POS :");
                                    foreach (var x in positives)
                                        Console.WriteLine(x);
                                    Console.WriteLine();
                                    cnsl.WriteSubTitle("NEG :");
                                    foreach (var x in negatives)
                                        Console.WriteLine(x);
                                    sw.Stop();
                                    cnsl.PrintLine(2);
                                    cnsl.WriteLog("Time : " + sw.Elapsed.TotalSeconds + " s");
                                    cnsl.PrintLine(2);
                                    sw.Reset();
                                    wait();
                                    break;

                                case choices.Drug:
                                    var drug = getDrug(ref Drugs[index], name);
                                    double time = 0;
                                    sw.Start();
                                    Console.WriteLine();
                                    cnsl.WriteSubTitle("On Drugs :");
                                    if (drug.Effects.Count == 0)
                                        Console.WriteLine("no effect on this drugs!");
                                    else
                                        foreach (var eff in drug.Effects)
                                            Console.WriteLine(eff);
                                    sw.Stop();
                                    time = sw.Elapsed.TotalSeconds;
                                    sw.Reset();
                                    sw.Start();
                                    Console.WriteLine();
                                    cnsl.WriteSubTitle("On Diseases :");
                                    Console.WriteLine();
                                    var effectsOnDiseases = effectsOfDrugOnDiseases(name);
                                    Console.WriteLine(" positive :");
                                    if (effectsOnDiseases["positive"].Count == 0)
                                        Console.WriteLine("No positive effect on this diseases!");
                                    else
                                        foreach (var x in effectsOnDiseases["positive"])
                                            Console.WriteLine("Disease : {0}", x);
                                    Console.WriteLine();
                                    Console.WriteLine(" negative :");
                                    if (effectsOnDiseases["negative"].Count == 0)
                                        Console.WriteLine("No negative effect on diseases!");
                                    else
                                        foreach (var x in effectsOnDiseases["negative"])
                                            Console.WriteLine("Disease : {0}", x);
                                    sw.Stop();
                                    cnsl.PrintLine(2);
                                    Console.WriteLine("Drug Time : " + time + " s");
                                    Console.WriteLine("Disease elapsed time : " + sw.Elapsed.TotalSeconds + " s");
                                    cnsl.PrintLine();
                                    cnsl.WriteLog("Total Time : " + (sw.Elapsed.TotalSeconds + time) + " s");
                                    cnsl.PrintLine(2);
                                    sw.Reset();
                                    wait();
                                    break;
                            }
                            break;
                        case commands.Exit:
                            Console.Clear();
                            cnsl.WriteTitle("See you again!");
                            exit = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    if (e is FormatException)
                        error += "Please enter correct Number!";
                    else
                        error += e.Message;
                }
            }
        }
    }
}
