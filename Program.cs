using System;
using static System.Random;
using System.Collections;
namespace UTS_2;

class Program
{
    // Game Hangman 
    private static void printHangman(int wrong)
    {
         if(wrong == 0)
         {
            Console.WriteLine("\n+--------+"); 
         } else if(wrong == 1)
          {
            Console.WriteLine("\n+--------+");
            Console.WriteLine("        |");          
         } else if(wrong == 2)
         {
            Console.WriteLine("\n+--------+");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
         } else if(wrong == 3)
         {
            Console.WriteLine("\n+--------+");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("       ===");
         } else if(wrong == 4)
         {
            Console.WriteLine("\n+--------+");
            Console.WriteLine("  |     |");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("       ===");
         } else if(wrong == 5)
         {
            Console.WriteLine("\n+--------+");
            Console.WriteLine("  |     |");
            Console.WriteLine("  O     |");
            Console.WriteLine("        |");
            Console.WriteLine("        |");
            Console.WriteLine("       ===");
         } else if(wrong == 6)
         {
            Console.WriteLine("\n+--------+");
            Console.WriteLine("  |     |");
            Console.WriteLine("  O     |");
            Console.WriteLine("  |     |");
            Console.WriteLine("        |");
            Console.WriteLine("       ===");
         } else if(wrong == 7)
         {
            Console.WriteLine("\n+--------+");
            Console.WriteLine("  |     |");
            Console.WriteLine("  O     |");
            Console.WriteLine(" /|\\    |");
            Console.WriteLine("        |");
            Console.WriteLine("       ===");
         } else if(wrong == 8)
         {
            Console.WriteLine("\n+--------+");
            Console.WriteLine("  |     |");
            Console.WriteLine("  O     |");
            Console.WriteLine(" /|\\    |");
            Console.WriteLine(" /      |");
            Console.WriteLine("       ===");
         }else if(wrong == 9)
         {
            Console.WriteLine("\n+--------+");
            Console.WriteLine("  |     |");
            Console.WriteLine("  O     |");
            Console.WriteLine(" /|\\    |");
            Console.WriteLine(" / \\    |");
            Console.WriteLine("       ===");
         } else if(wrong == 10)
         {
            Console.WriteLine("\n+--------+");
            Console.WriteLine("  |     |");
            Console.WriteLine("  O     |");
            Console.WriteLine(" /|\\    |");
            Console.WriteLine(" / \\    |");
            Console.WriteLine("       ===");
            Console.WriteLine(" Anda kalah!");
            Console.WriteLine(" Coba lagi.");
         }
    }
    private static int printWord(List<char>kataTebakan, String kataRandom)
    {
        int sisa = 0;
        int tebakanBenar = 0;
        Console.Write("\r\n");
        foreach (char c in kataRandom)
        {
            if(kataTebakan.Contains(c))
            {
                Console.Write(c + " ");
                tebakanBenar +=1;
            }else
            {
                Console.Write("_ ");
            }
            sisa += 1;
        }
        return tebakanBenar;
    }
    static int kesempatan = 10;


private static void printLines(String kataRandom)
    {
        Console.Write("\n");
        foreach (char c in kataRandom)
       {
       }
    }

//   start game
    static void Main(string[] args)
    {
        Console.WriteLine("Selamat datang di Hangman Game!!!");
        Console.WriteLine("=-----------------------------------------=");
        // prodiFt
        List<string> prodiFt = new List<string> { "informatika","arsitektur","elektro","kimia","mesin","sipil","lingkungan","pulpdankertas" };
        Random random = new Random();
        int indeks = random.Next(prodiFt.Count);
        String kataRandom = prodiFt[indeks];
        int amountOftebakanSalah = 0;
        int currenttebakanBenar = 0;
        int lenghtofkataTebakan = kataRandom.Length;
        List<char> currentLettersGuessed = new List<char>();
        // vokal
        char[] vokal = {'a', 'i', 'u', 'e', 'o'};
    
        while(amountOftebakanSalah != 10 && currenttebakanBenar != lenghtofkataTebakan)
        {
            try {
            Console.Write("Tebak huruf pada kata berikut! ");
            Console.WriteLine("\nSisa kesempatan anda: "+kesempatan);
            foreach(char letter in currentLettersGuessed){
                Console.Write(" " +letter);
            }
            Console.Write("\nSilahkan tebak Prodi FT dalam bentuk huruf: ");
            char kataTebakan = Console.ReadLine()[0];

            if (!char.IsLetter(kataTebakan)) {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\r\nMasukkan huruf!");
                Console.ForegroundColor = ConsoleColor.Gray; 
                printHangman(amountOftebakanSalah);
                currenttebakanBenar = printWord(currentLettersGuessed, kataRandom);
                printLines(kataRandom);
                continue;
            }
            //Kata ditebak
            if(currentLettersGuessed.Contains(kataTebakan)){
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\r\nAnda sudah menebak huruf ini!");
                Console.ForegroundColor = ConsoleColor.Gray; 
                printHangman(amountOftebakanSalah);
                currenttebakanBenar = printWord(currentLettersGuessed, kataRandom);
                printLines(kataRandom);
                
            }else{
               //jawaban
               bool right = false;
               for(int i = 0; i < kataRandom.Length; i++) { if(kataTebakan == kataRandom[i]) { right = true; } }

               if(right) {
                    // huruf vokal
                    if (vokal.Contains(kataTebakan)) {
                        amountOftebakanSalah++;
                        kesempatan--;
                    }
                     printHangman(amountOftebakanSalah);
                     currentLettersGuessed.Add(kataTebakan);
                     currenttebakanBenar = printWord(currentLettersGuessed, kataRandom);
                       printLines(kataRandom);
                      Console.Write("\r\n");
               }else{
                   amountOftebakanSalah++;
                   kesempatan--;
                   currentLettersGuessed.Add(kataTebakan);
                   printHangman(amountOftebakanSalah);
                    currenttebakanBenar = printWord(currentLettersGuessed, kataRandom);
                    Console.Write("\r\n");
                    printLines(kataRandom);
               }
            }
            } 
            //test error 
            catch (Exception e) {
                Console.WriteLine($"Terjadi kesalahan {e.Message}");
            }
         }
         //sisa kesempatan
            if (kesempatan > 0){  
                Console.WriteLine("Selamat Anda menang!");
             Console.WriteLine($"Kamu menang dengan sisa kesempatan: {kesempatan}");
        }
        else{   
             Console.WriteLine("Kesempatan Anda habis!Anda kalah!!!");
             Console.WriteLine($"Kata yang benar adalah: {kataRandom}.");   
        }
             Console.ForegroundColor = ConsoleColor.Gray;
             Console.WriteLine("\r\nGame Over!Terima Kasih sudah bermain Game Hangman!!!");
    }       
}
