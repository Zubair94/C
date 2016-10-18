using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Console
{
	class Game
	{
		static string[] array = {"Apple", "Mango","Guava","Lemon","Olive"};
		static int length = array.Length;
		static int missCount = 6;
		static int wordCount = 0;
		static bool gameOver = false;
		static int choice;
		static string s;
		static char[] arrayShow = { '-', '-', '-', '-', '-'};
		static char temp = '-';

		static void game_start()
		{
			Console.WriteLine("Singleplayer:Type 1 and Enter");
			Console.WriteLine("Multiplayer:Type 2 and Enter");
			string mode = Console.ReadLine();
			if(mode == "1")
			{
				Random r = new Random();
				choice = r.Next(0, length - 1);
				s = array[choice];
				s = s.ToLower();
				for (int i = 0; i < arrayShow.Length; i++)
				{
					Console.Write("{0}   ", arrayShow[i]);
				}
				Console.WriteLine("\n");
			}
			else if(mode == "2")
			{
				Console.WriteLine("Enter a string to guess: ");
				s = Console.ReadLine();
				s = s.ToLower();
				Console.WriteLine("OK");
				arrayShow = new char[s.Length];
				for (int i = 0; i < arrayShow.Length; i++)
				{
					arrayShow[i] = '-';
				}
				Console.Clear();
				for (int i = 0; i < arrayShow.Length; i++)
				{
					Console.Write("{0}   ", arrayShow[i]);
				}
				Console.WriteLine("\n");
			}

		}
		static void makeTurn()
		{
			Console.Write("Please Enter A Letter :");
			string input_user = Console.ReadLine();
			int x1;
			bool parse1 = Int32.TryParse(input_user, out x1);

			while (parse1 || input_user.Length != 1)
			{
				int x;
				bool parse = Int32.TryParse(input_user, out x);
				Console.Clear();
				Console.WriteLine("Don't input number or more than one letters");
				//Console.WriteLine (x);
				for (int i = 0; i < arrayShow.Length; i++)
				{
					Console.Write("{0}   ", arrayShow[i]);
				}
				Console.WriteLine("\n");
				Console.Write("Please Enter a Letter :");
				input_user = Console.ReadLine();


				if (!parse && input_user.Length == 1) 
				{
					break;
				}
			}
			checkTurn(input_user);
		}
		static void checkTurn(string input_string)
		{
			
			char input_char = Convert.ToChar(input_string);
			/*Same1 = Same;
			Same = input_char;

			if (Same1 == Same) 
			{
				makeTurn ();
			}*/
			char temp1 = input_char;
			for (int i = 0; i < arrayShow.Length; i++)
            {
                if(input_char == arrayShow[i])
                {
                    Console.WriteLine("{0} is already a correct guess", input_char);
                    makeTurn();
                    wordCount--;
                }
            }
            bool letterGuess = false;
            for (int i = 0; i < s.Length; i++)
			{
				char check_char = s[i];
				if(check_char == input_char)
				{
					Console.WriteLine("Correct");
					letterGuess = true;
					wordCount++;
					showProgress(i,input_char);
				}
			}
			if(letterGuess == false)
			{
				if (temp1 != temp) 
				{
					showFailure ();
					temp = input_char;
				} 
				else 
				{
					Console.WriteLine("You already mistook {0} once",temp);
					makeTurn ();
				}
					
			}

		}
		static void showFailure()
		{
			missCount--;
			if (missCount == 0)
			{
				gameOver = true;
			}
			Console.Clear();
			Console.WriteLine("Failed");
			for (int i = 0; i < arrayShow.Length; i++)
			{
				Console.Write("{0}   ", arrayShow[i]);
			}
			Console.WriteLine("\n");
			Console.WriteLine("{0} Turns Until Hangman", missCount);
			Console.WriteLine("\n");

		}
		static void showProgress(int posiiton, char letterCorrect)
		{
			arrayShow[posiiton] = letterCorrect;
			Console.Clear();
			for (int i =0; i<arrayShow.Length; i++)
			{
				Console.Write("{0}   ", arrayShow[i]);
			}
			Console.WriteLine("\n");
		}
		static void Main(string[] args)
		{
			game_start();
			while (wordCount != s.Length)
			{
				if (gameOver)
				{
					Console.WriteLine("GAME OVER");
					break;
				}
				//Console.WriteLine("turn");
				makeTurn();
			}
			if (wordCount == s.Length)
			{
				Console.WriteLine("GAME WON");
				//break;
			}
		}
	}
}
