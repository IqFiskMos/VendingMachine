using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
	class Program {
		static void Main(string[] args) {
			VendingMachine vm = new VendingMachine();
			do {
				vm.Render();
			} while(vm.KeyHandler() != false);
			Console.Clear();
			vm.ReturnChange();
			Console.ReadKey();
			Console.WriteLine("Du svimmade av träffarna.");
			Console.ReadKey();
		}
	}
}
