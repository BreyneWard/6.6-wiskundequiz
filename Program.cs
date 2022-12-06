namespace _6._6_wiskundequiz;

using System;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.IO;


    class Program
    {
       
        static void Main(string[] args)
        {
            GameIntro();
            string playerName = AskPlayerName();
            WelcomePlayerMsg(playerName);
            int tableOfValue = MultiplicationOfNumber();
            WriteLine($"Je koos voor tafels van: {tableOfValue}");
            int score = DeployMultiplicactions(tableOfValue);
            StorePlayerResultInFile(score, playerName, tableOfValue);

        }

        // Methods
        //
        // Game intro
         public static void GameIntro()
        {
            WriteLine("Welkom in het oefenprogramma tafels van vermenivuldigen!");
            

        }

        // AskPlayerName input validation for playername
        public static string AskPlayerName()
        {
            string playerName;
            do
            {
                
                WriteLine("Geef je naam op: ");
                playerName = ReadLine();
            }
            while (string.IsNullOrWhiteSpace(playerName));

            return playerName;

        }
        // Welcome message to player
        public static void WelcomePlayerMsg(string playerName)
        {
            if(playerName != "")
            {

            WriteLine($"Welkom {playerName} ben je klaar voor de uitdaging? Let's go.");

            }
        }
        
        // Methods that validates input for which number of multiplication the player wishes to train
        public static int MultiplicationOfNumber()
        {
        
            WriteLine("Welke tafel van vermenigvuldigen wil je oefenen");
            WriteLine("Voorbeeld: Indien je de tafel van vermenigvuldigen van 5 wil, geef dan cijfer 5 in.");

          
            string? choiceStr;
            do
            {
                
                WriteLine("Maak je keuze: ");
                choiceStr = ReadLine();
            }
            while (string.IsNullOrWhiteSpace(choiceStr) && int.TryParse(choiceStr, out int choiceInt));

            return int.Parse(choiceStr);
        }

        // Method to return random multiplications of the number asked by player
        public static int DeployMultiplicactions(int choiceInt)
        {
            int faults = 0;
            //string result;
            WriteLine($"Tafels van vermenigvuldigen van {choiceInt}");
            WriteLine("");
            for (int i = 0; i < 11; i++)
            {
                WriteLine($"{i,2} * {choiceInt} = ");
                string? answer;
            do
            {
                
                answer = ReadLine();
            }
            while (string.IsNullOrWhiteSpace(answer) && int.TryParse(answer, out int answerInt));
            if(int.Parse(answer) == (i*choiceInt))
            {
                WriteLine(" => Juist");
            }
            else
            {
                WriteLine(" => Fout");
                    faults++;
                }

               
                
            }
                 int score = 11 - faults;
                WriteLine($"Je score is: {score}/11!");

               return score;
        }

        // Method to store the player results to a text file
        public static void StorePlayerResultInFile(int score, string playerName, int tableOfValue)
        {
            //WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()", arg1: GetTempPath());

            //create log file directory that takes the playerName as directoryname
            String newResultFolder = Combine(GetTempPath(), playerName);
        
            CreateDirectory(newResultFolder);

            if (Exists(newResultFolder))
            {
                WriteLine($"De map: {newResultFolder} zal gebruikt worden om de resultaten in op te slaan.");
            }
            else
            {
                WriteLine($"De map: {newResultFolder} kon niet aangemaakt worden.");
            }
    

            //create logfile in the created directory
            string tableOfValueStr = tableOfValue.ToString(); //convert tableValue to string with System.Convert
            WriteLine($"TableOfValue: {tableOfValue}");
            string timestamp = string.Format("{0:dd-MM-yyyy_hh-mm-ss-tt}.txt", DateTime.Now);//make a datatime string
            WriteLine($"TimeStamp: {timestamp}");
            string resultFile = Combine(newResultFolder, $"Result_tafels_van_getal_{tableOfValueStr}_{timestamp}"); //make outputfile in folder
            Write(resultFile);
            //Check if file exists
            WriteLine($"Is het bestand {resultFile} aangemaakt geweest?: {File.Exists(resultFile)}");

            //Create the file
            StreamWriter textWriter = File.CreateText(resultFile);
            textWriter.WriteLine($"Welkom {playerName} je score is: {score}/11!");
            textWriter.Close();
            //Check if file exists
            WriteLine($"Is het bestand {resultFile} aangemaakt geweest?: {File.Exists(resultFile)}");

            //Read from the text file
            WriteLine($"Lezen van de inhoud van bestand: {resultFile}:");
            StreamReader textReader = File.OpenText(resultFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();

        }

    }


