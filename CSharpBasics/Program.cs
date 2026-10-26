using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            //Bai1();
            //Bai2();
            Bai3();


            Console.ReadLine();
        }

        public static void Bai1()
        {
            
            string Phone = "iPhone 15 Pro Max";
            decimal Price = 30000000m;
            int Quantity = 25;
            decimal RateSale = 0.1m;
            bool IsAvailable = true;
            decimal AfterSale = Price * (1 - RateSale);
            Console.WriteLine("=== THÔNG TIN SẢN PHẨM ===");
            Console.WriteLine($"Tên máy: {Phone}");
            Console.WriteLine($"Giá niêm yết: {Price:N0} VNĐ"); // In ra: 30,000,000 VNĐ
            Console.WriteLine($"Giảm giá: {RateSale * 100}%");
            Console.WriteLine($"Giá khuyến mãi: {AfterSale:N0} VNĐ");
            Console.WriteLine($"Số lượng còn: {Quantity}");
            Console.WriteLine($"Trạng thái: {(IsAvailable ? "Còn hàng" : "Hết hàng")}");
        }

        public static void Bai2()
        {
            string phoneName = "iPhone 15 Pro Max";
            decimal price = 30000000m;
            int quantity = 25;
            decimal discountRate = 0.1m;
            bool isAvailable = true;
            decimal finalPrice = price * (1 - discountRate);
            decimal totalPrice = 0;

            Console.Write("Nhập số lượng bạn muốn mua: ");
            string input = Console.ReadLine();
            int buyQuantity = int.Parse(input);

            if (buyQuantity <= 0)
            {
                Console.WriteLine("Số lượng mua phải lớn hơn 0.");
                return;
            }

            if (buyQuantity > quantity)
            {
                Console.WriteLine($"Kho chỉ còn {quantity} máy, không đủ bán!");
                return;
            }


            if (buyQuantity < 3 && buyQuantity >= 1)
            {
               totalPrice = price * buyQuantity;
            }
            else
            {
                totalPrice = finalPrice * buyQuantity;
            }

            quantity -= buyQuantity;
            isAvailable = quantity > 0;

            Console.WriteLine("=== THÔNG TIN SẢN PHẨM ===");
            Console.WriteLine($"Tên máy: {phoneName}");
            Console.WriteLine($"Giá niêm yết: {price:N0} VNĐ");
            Console.WriteLine($"Giảm giá: {discountRate * 100}%");
            Console.WriteLine($"Giá khuyến mãi: {totalPrice:N0} VNĐ");
            Console.WriteLine($"Số lượng còn lại: {quantity}");
            Console.WriteLine($"Trạng thái: {(isAvailable ? "Còn hàng" : "Hết hàng")}");

        }

        public static void Bai3()
        {
            string phoneName = "iPhone 15 Pro Max";
            decimal price = 30000000m;
            int quantity = 25;
            decimal discountRate = 0.1m;
            bool isAvailable = true;
            decimal finalPrice = price * (1 - discountRate);
            decimal totalPrice = 0;

            vitrimualai:

            if (!isAvailable)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sản phẩm đã hết hàng!");
                Console.ResetColor();
                return;
            }
            int buyQuantity;
            while (true)
            {
                Console.Write("Nhập số lượng bạn muốn mua: ");
                if (int.TryParse(Console.ReadLine(), out buyQuantity) && buyQuantity > 0 && buyQuantity <= quantity)
                {
                    break; // Hợp lệ 100% thì thoát khỏi vòng lặp nhập liệu
                }

                // Nếu xuống được đây nghĩa là nhập sai:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vui lòng nhập số hợp lệ từ 1 đến {quantity}!");
                Console.ResetColor();
            }

            if (buyQuantity < 3 && buyQuantity >= 1)
            {
                totalPrice = price * buyQuantity;
            }
            else
            {
                totalPrice = finalPrice * buyQuantity;
            }

            quantity -= buyQuantity;
            isAvailable = quantity > 0;

            Console.WriteLine("=== THÔNG TIN SẢN PHẨM ===");
            Console.WriteLine($"Tên máy: {phoneName}");
            Console.WriteLine($"Giá niêm yết: {price:N0} VNĐ");
            Console.WriteLine($"Giảm giá: {discountRate * 100}%");
            Console.WriteLine($"Giá khuyến mãi: {totalPrice:N0} VNĐ");
            Console.WriteLine($"Số lượng còn lại: {quantity}");
            Console.WriteLine($"Trạng thái: {(isAvailable ? "Còn hàng" : "Hết hàng")}");

            Console.WriteLine("Bạn có muốn mua tiếp không Y/N ?");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "y":
                    goto vitrimualai;
                case "n":
                    Console.WriteLine("Cảm ơn bạn đã mua hàng!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Kết thúc chương trình.");
                    break;
            }
        }
    }
}
