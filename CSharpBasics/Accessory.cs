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
        // Ghi đè lại hàm DisplayInfo của Cha
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // In phần chung của Cha trước
            Console.WriteLine($" | [Bảo hành: {Warranty}]"); // In thêm phần riêng của Phụ kiện
        }

        public override decimal CalculateShippingFee()
        {
            return 15000m; // Phí ship phụ kiện là 15k
        }
    }
}
