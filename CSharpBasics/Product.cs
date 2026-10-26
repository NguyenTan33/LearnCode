using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    // Bản thiết kế của một Sản phẩm
    public class Product
    {
        // 1. Các thuộc tính (Properties) - Đặc điểm của sản phẩm
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // 2. Constructor (Hàm khởi tạo) - Chạy mỗi khi tạo một sản phẩm mới bằng chữ "new"
        public Product(int id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        // 3. Phương thức (Method) - Hành động của sản phẩm
        public void DisplayInfo()
        {
            Console.WriteLine($"[{Id}] {Name} | Giá: {Price:N0} VNĐ | Còn lại: {Quantity} chiếc | Trạng thái: {(Quantity > 0 ? "Còn hàng" : "Hết hàng")}");
        }

        // Hành động giảm tồn kho khi có khách mua
        public bool ReduceQuantity(int amount)
        {
            if (amount <= 0 || amount > Quantity)
            {
                return false; // Mua không hợp lệ
            }

            Quantity -= amount;
            return true; // Trừ kho thành công
        }
    }
}
