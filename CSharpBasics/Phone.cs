using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class Phone : Product, IRechargeable
    {
        // Thuộc tính riêng của Laptop mà Điện thoại không có
        public int phoneNumber { get; set; }

        // Constructor của con: nhận thông tin, sau đó dùng 'base(...)' để chuyển phần của Cha lên cho Cha giữ!
        public Phone(int id, string name, decimal price, int quantity, int phoneNumber)
            : base(id, name, price, quantity) // Gọi Constructor của class Product
        {          
            this.phoneNumber = phoneNumber;
        }

        // Phương thức riêng của Laptop
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // In phần chung của Cha trước
            Console.WriteLine($"Có mã số là {phoneNumber}");
        }

        public override decimal CalculateShippingFee()
        {
            return 50000m; // Phí ship laptop là 50k
        }

        public void Charge()
        {
            throw new NotImplementedException();
        }
    }
}
