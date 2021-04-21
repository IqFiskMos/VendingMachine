using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
	abstract public class Product {
		public int Price { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }

		public abstract void Use();
		public override string ToString() {
			return $"({this.Type}) {this.Name}";
		}
	}

	public class Drink : Product {
		public Drink() {
			this.Type = "Drinka";
		}
		public override void Use() {
			Console.WriteLine($"Du tar en klunk av {this.Name}.");
		}
	}

	public class Snack : Product {
		public Snack() {
			this.Type = "Snacks";
		}
		public bool HasNuts { get; set; }
		public override void Use() {
			Console.WriteLine($"Du tuggar i dig din/ditt {this.Name}.");
			if(HasNuts) {
				Console.WriteLine("Det var nötter i och du är allergis och dör.");
			}
		}
	}
}