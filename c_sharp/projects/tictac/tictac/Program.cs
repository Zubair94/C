using System;


namespace tictac

{

	class Program
	{
		static bool flagwin = false;
		static bool flagdraw = false;
		static char[] array = {'-','-','-','-','-','-','-','-','-'};
		static int movePosition;
		static int player = 2;

		static void displayArray()
		{
			Console.WriteLine("HINT:Enter number from 1-9 board postion to insert a move");
			Console.WriteLine ("\n");
			for (int i = 0; i < 9; i++) {
				if (i == 3 || i == 6) {
					Console.WriteLine("\n");
				}
				Console.Write ("    {0}",array[i]);
			}
		}

		static bool Turn()
		{
			bool turn = false; 
			if (player % 2 == 0) {
				Console.WriteLine ("\n");
				Console.WriteLine ("Player 1 gets X");
				turn = true;
				return turn;
			}
			else {
				Console.WriteLine ("\n");
				Console.WriteLine ("Player 2 gets O");
				return turn;
			}
		}


		static void win_Func(){

			if (((array[0] == 'O') && (array[1] == 'O') && (array[2] == 'O')) || ((array [3] == 'O') && (array [4] == 'O') && (array [5] == 'O')) || ((array [6] == 'O') && (array [7] == 'O') && (array [8] == 'O')) ||((array [0] == 'O') && (array [3] == 'O') && (array [6] == 'O')) ||((array [1] == 'O') && (array [4] == 'O') && (array [7] == 'O')) ||((array [2] == 'O') && (array [5] == 'O') && (array [8] == 'O')) ||((array [0] == 'O') && (array [4] == 'O') && (array [8] == 'O')) ||((array [2] == 'O') && (array [4] == 'O') && (array [6] == 'O'))){
				flagwin = true;
			} 
			else if (((array[0] == 'X') && (array[1] == 'X') && (array[2] == 'X')) || ((array [3] == 'X') && (array [4] == 'X') && (array [5] == 'X')) || ((array [6] == 'X') && (array [7] == 'X') && (array [8] == 'X')) ||((array [0] == 'X') && (array [3] == 'X') && (array [6] == 'X')) ||((array [1] == 'X') && (array [4] == 'X') && (array [7] == 'X')) ||((array [2] == 'X') && (array [5] == 'X') && (array [8] == 'X')) ||((array [0] == 'X') && (array [4] == 'X') && (array [8] == 'X')) ||((array [2] == 'X') && (array [4] == 'X') && (array [6] == 'X'))){
				flagwin = true;
			} else {
				flagwin = false;
			}

		}
		static void draw_Func()
		{
			if (array [0] != '-' && array [1] != '-' && array [2] != '-' && array [3] != '-' && array [4] != '-' && array [5] != '-' && array [6] != '-' && array [7] != '-' && array [8] != '-') {
				flagdraw = true;
			} else {
				flagdraw = false;
			}
		}
		static void MakeMove()
		{
			try{
				
			Console.WriteLine("\n");
			Console.Write("Player {0} Pls Enter a Board Position:",(player%2)+1);
			movePosition = int.Parse(Console.ReadLine());
			if (array [movePosition-1] != 'X' && array [movePosition-1] != 'O') {
				if (Turn ()) {
					array[movePosition-1] = 'X';
					player++;
				} else {
					array[movePosition-1] = 'O';
					player++;
				}
			} else {
					Console.WriteLine ("Invalid Move, Can't place X or O");
				}
			}catch{
				Console.WriteLine ("Move Error Enter Only Numbers");
			}
		}

		static void Game(){

			while ((flagwin !=true)) {
				if (flagdraw) {
					break;
				}
				Console.Clear ();
				displayArray();
				Turn ();
				MakeMove ();
				win_Func ();
				draw_Func ();
			}
			int r = (player % 2) + 1;
			Console.Clear ();
			if (flagwin) {
				Console.WriteLine ("Player {0} has Won the Game!!!!!!", r);
			} else if (flagdraw) {
				Console.WriteLine ("The Game is a Draw");
			} else {
				Console.WriteLine ("Invalid");
			}
		}
		static void Main(string[] args)
		{
			Game();	
		}

	}

}  