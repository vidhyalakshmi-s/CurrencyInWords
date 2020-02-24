using System;

namespace CurrencyNS
{
	public static class ConverToWords
	{
		public static string ToWords(this decimal value)
		{
			string decimalValue = "";
			//string input = Math.Round(value, 2).ToString();
			string input = value.ToString();

			if (input.Contains("."))
			{
				decimalValue = input.Substring(input.IndexOf(".") + 1);
				input = input.Remove(input.IndexOf("."));
			}

			string inWords = GetWords(input) + " Dollars";


			if (decimalValue.Length > 0)
			{
				inWords += " and " + GetWords(decimalValue) + " Cents";
			}

			return inWords;
		}

		private static string GetWords(string input)
		{
			string[] seperators = { "", " Thousand ", " Million ", " Billion " };

			int i = 0;

			string inWords = "";

			if (int.Parse(input) == 0)
			{
				inWords = "Zero";
				return inWords;

			}

			while (input.Length > 0)
			{
				// read last 3 digits
				string lastDigits = input.Length < 3 ? input : input.Substring(input.Length - 3);
				// remove the 3 last digits from input
				input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

				int no = int.Parse(lastDigits);
				// Convert 3 digit number into words.
				lastDigits = GetWord(no);

				lastDigits += seperators[i];
				inWords = lastDigits + inWords;

				i++;
			}
			return inWords;
		}

		// your method just to convert 3digit number into words.
		private static string GetWord(int no)
		{
			string[] Ones =
			{
			"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
			"Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"
		};

			string[] Tens = { "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

			string word = "";

			if (no > 99 && no < 1000)
			{
				int i = no / 100;
				word = word + Ones[i - 1] + " Hundred ";
				no = no % 100;
			}

			if (no > 19 && no < 100)
			{
				int i = no / 10;
				word = word + Tens[i - 1] + " ";
				no = no % 10;
			}

			if (no > 0 && no < 20)
			{
				word = word + Ones[no - 1];
			}

			return word;
		}
	}

	public class currencyToWords
	{
		public static void Main(string[] args)
		{
			bool quitApp = false;
			decimal parsedInput = 0;
			while (!quitApp)
			{
				Console.WriteLine("Please input currency value:");
				string input = Console.ReadLine();
				while (!decimal.TryParse(input, out parsedInput) || input.StartsWith("-"))
				{
					Console.Write("This is not valid input. \nPlease enter a valid currency value: ");
					input = Console.ReadLine();
				}

				string convertToWords = ConverToWords.ToWords(parsedInput);
				Console.WriteLine(convertToWords);
				Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
				if (Console.ReadLine() == "n") quitApp = true;

			}
			return;

		}
	}
}