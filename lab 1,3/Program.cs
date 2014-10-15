using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_3
{
    class Program
    {
        static void Main(string[] args)
        {

            int of= 0; 

            


            do
            {
                
                    of = ReadInt("Ange antal löner att mata in: "); // blir prompt alltså ner

                    if (of < 2)  // man kommer få den meddelandet om man mata in värdet som är mindre än 2
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Du måste mata in minst två löner för att göra en beräkning.");
                        Console.ResetColor();
                    }
                    else
                    {
                        ProcessSalaries(of);
                    }
            

                Console.WriteLine();

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tryck på valfri tangent för att göra en ny beräkning - Escape avslutar programmet.");
                Console.ResetColor();
     
              
                

                             
               }

             while (Console.ReadKey().Key != ConsoleKey.Escape); // för att avsluta så ska man trycka på ESC och Entre för att..

            
        }

        static void ProcessSalaries(int count) 
        {
            // skapar variablar som jag använder 
            int räkn = 0; 
            int total = 0;
            int median = 0;
            int högstalön = 0;
            int mindre = 0;
            int spred = 0;
            int genom = 0;
            // skapar arrayer som jag kommer använda för att sortera och att lägga in värde
            int[] lön;
            int[] sorti;

        

            lön=new int[count];
            sorti= new int[count];

            for (int i = 0; i < count; i++)   //Loopa i arrayen och  sedan kör ReadInt för att läsa in  
            {
                lön[i] = ReadInt(String.Format("Ange lön nummer {0}: ", i + 1)); // mata in värde(lön)

  
                total += lön[i]; 

                sorti[i] = lön[i]; 
            }

            Array.Sort(sorti); // arrayen gör beräkning

            // här så börjar sortering 
            högstalön =sorti.Max();      
            mindre=sorti.Min();     
           spred = högstalön - mindre;
            genom = total / count;



            räkn = sorti.Count();

            int a =sorti.Count() / 2;  // a = det som finns i arrayen delat med 2

           
            if (räkn% 2 == 0)
            {
                median = (sorti[a - 1] + sorti[a]) / 2; // uträkning för att få fram median 
            }

            else
            {
                median = sorti[a]; 
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Medianlön:          {0:c0}", median);
            Console.WriteLine("Medellön:           {0:c0}", genom);
            Console.WriteLine("Lönespridning:              {0:c0}", spred);
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

            for (int r = 1; r <= count; r++)   
            {
                Console.Write(" {0, 5}   ", lön[r - 1]); // skriver ut det värde som vi har lagt in 



                if (r % 3 == 0) // mellan slag 
                {
                    Console.WriteLine();
                }
            }
        }

        static int ReadInt(string prompt)   // tar in input av användare
        {   
            string input;
            int ReadInt;

            input = null;

            while (true)
            {
                try
                {
                    // om readint är mindre än 1 så får man fel medelande och om et är mer än 1 så går den vidare 
                    Console.Write(prompt);
                    input = Console.ReadLine();
                    ReadInt = int.Parse(input); 

                    if (ReadInt < 1)  
                    {
                        Console.WriteLine("Skriv in ett högre värde än 0.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Fel! '{0}' tolkas inte som ett heltal.", input); // input = string alltså det ska vara icke siffra
                    Console.ResetColor();
                }
            }
            return ReadInt;  // den går upp igen

       
        }
    }
}
