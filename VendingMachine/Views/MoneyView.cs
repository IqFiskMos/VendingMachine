using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
	public class MoneyView : IVendingMachineView {
		public VendingMachine Machine { get; set; }
		public bool KeyHandler() {
			var key = Console.ReadKey(true);
			int parsedKey;
			if(int.TryParse(key.KeyChar.ToString(), out parsedKey) && parsedKey < VendingMachine.Money.Length) {
				Machine.MoneyPool += VendingMachine.Money[parsedKey - 1];
			} else {
				switch(key.Key) {
					case ConsoleKey.Escape:
					case ConsoleKey.X:
						Machine.CurrentMenu = Machine.MainMenu;
						break;
				}
			}
			return true;
		}

		public void Render() {
			Console.Clear();
			Console.WriteLine($"Saldo: {Machine.MoneyPool}");
			int index = 1;
			foreach(var coin in VendingMachine.Money) {
				Console.WriteLine($"Tryck {index} för att lägga till {coin}kr till ditt saldo.");
				index++;
			}
			Console.WriteLine($"X eller Esc - tillbaka till huvudmenyn\n");
		}
	}
}
