using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class Accessory : Product
    {
        public string Warranty { get; set; }

        public Accessory(int id, string name, decimal price, int quantity, string warranty)
            : base(id, name, price, quantity)
        {
            this.Warranty = warranty;
        }

        // Phương thức riêng của Laptop
        public void UpgradeRam(int extraRam)
        {
            Console.WriteLine($"thời hạn bảo hành của bạn là {Warranty}");
        }
    }
}
