using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    // Laptop kế thừa từ Product (Laptop là một Sản phẩm)
    public class Laptop : Product
    {
        // Thuộc tính riêng của Laptop mà Điện thoại không có
        public int RamGB { get; set; }
        public string Cpu { get; set; }

        // Constructor của con: nhận thông tin, sau đó dùng 'base(...)' để chuyển phần của Cha lên cho Cha giữ!
        public Laptop(int id, string name, decimal price, int quantity, int ramGB, string cpu)
            : base(id, name, price, quantity) // Gọi Constructor của class Product
        {
            RamGB = ramGB;
            Cpu = cpu;
        }

        // Phương thức riêng của Laptop
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // In phần chung của Cha trước
            Console.WriteLine($"Đã nâng cấp RAM cho {Name}. RAM hiện tại: {RamGB}GB");
        }

        public override decimal CalculateShippingFee()
        {
            return 50000m; // Phí ship laptop là 50k
        }

    }
}
