using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
	public class DetailView : IVendingMachineView {
		public VendingMachine Machine { get; set; }
		public Product Product { get; set; }
		public int Amount { get; set; }
		public DetailView(KeyValuePair<Product, int> product, VendingMachine machine) {
			this.Product = product.Key;
			this.Amount = product.Value;
			this.Machine = machine;
		}

		public bool KeyHandler() {
			var key = Console.ReadKey(true);
			switch(key.Key) {
				case ConsoleKey.B:
					if(Machine.MoneyPool < Product.Price) {
						Console.WriteLine("Saldo lågt, lägg in mer pengar.");
						Console.WriteLine("Vill du fylla på ditt saldo? (y/n)");
						ConsoleKeyInfo cki;
						do {
							cki = Console.ReadKey(true);
						}
						while(!(cki.Key == ConsoleKey.N || cki.Key == ConsoleKey.Y));
						switch(cki.Key) {
							case ConsoleKey.N:
								this.Machine.CurrentMenu = Machine.MainMenu;
								break;
							case ConsoleKey.Y:
								this.Machine.CurrentMenu = Machine.MoneyMenu;
								break;
						}
					} else if(Amount == 0) {
						Console.WriteLine("Tyvär är denna produkt slut.");
						Console.ReadKey();
						this.Machine.CurrentMenu = Machine.MainMenu;
					} else {
						Machine.MoneyPool -= Product.Price;
						Machine.Products[Product] -= 1;
						Amount -= 1;
						this.Render();
						Console.WriteLine("Suget är för stort för att stå imot så du intog produkten direkt!");
						Product.Use();
						Console.ReadKey();
					}
					break;
				case ConsoleKey.Escape:
				case ConsoleKey.X:
					Machine.CurrentMenu = Machine.MainMenu;
					break;
			}
			return true;
		}

		public void Render() {
			Console.Clear();
			Console.WriteLine($"Produktnamn: {Product.Name}");
			Console.WriteLine($"Produkttyp: {Product.Type}");
			Console.WriteLine($"Pris: {Product.Price}");
			Console.WriteLine($"Antal kvar: {Amount}");
			if(Product is Snack) {
				if((Product as Snack).HasNuts) {
					Console.WriteLine($"Innehåller Nötter.");
				}
			}

			Console.WriteLine($"\nSaldo: {Machine.MoneyPool}");
			Console.WriteLine($"\nB - Köp produkten");
			Console.WriteLine($"X eller Esc - Gå tillbaka till huvudmenyn\n");
		}
	}
}
