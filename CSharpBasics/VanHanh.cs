using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class VanHanh
    {

        public void ThemKhach(List<string> customersName, Queue<string> ticketQueue)
        {

            foreach (string name in customersName)
            {
                ticketQueue.Enqueue(name);
            }

        }

        public string GoiKhach(Queue<string> ticketQueue)
        {
            if (ticketQueue.Count > 0)
            {
                string nextCustomer = ticketQueue.Dequeue();
                Console.WriteLine($"Xin mời khách hàng tiếp theo là: {nextCustomer}");
                return nextCustomer;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hiện tại chưa có khách hàng nào lấy số thứ tự.");
                Console.ResetColor();
                return null;
            }
        }

        public void HienThiDanhSachKhach(Queue<string> ticketQueue)
        {
            if (ticketQueue.Count > 0)
            {
                Console.WriteLine("=== DANH SÁCH KHÁCH HÀNG ĐANG CHỜ ===");
                foreach (string customer in ticketQueue)
                {
                    Console.WriteLine($"- {customer}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hiện tại chưa có khách hàng nào lấy số thứ tự.");
                Console.ResetColor();
            }
        }
        public void HienThiSoLuongKhach(Queue<string> ticketQueue)
        {
            Console.WriteLine($"Hiện tại có {ticketQueue.Count} khách hàng đang chờ.");
        }

        public void HienThiKhachTiepTheo(Queue<string> ticketQueue)
        {
            if (ticketQueue.Count > 0)
            {
                Console.WriteLine($"Khách hàng tiếp theo là: {ticketQueue.Peek()}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hiện tại chưa có khách hàng nào lấy số thứ tự.");
                Console.ResetColor();
            }
        }

        public void DisplayTicketInfo(List<string> Rank, List<decimal> ticketPrices)
        {
            Dictionary<string, decimal> boardticketPrice = new Dictionary<string, decimal>();

            for (int i = 0; i < Rank.Count; i++)
            {
                boardticketPrice[Rank[i]] = ticketPrices[i];
            }

            Console.WriteLine("=== DANH SÁCH GIÁ VÉ THEO HẠNG ===");
            foreach (var kvp in boardticketPrice)
            {
                Console.WriteLine($"Hạng: {kvp.Key} - Giá vé: {kvp.Value:N0} VNĐ");
            }
        }

        public void HistoryActions(Stack<string> paymentHistory, string nameCustomerNext)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            paymentHistory.Push($"Khách hàng {nameCustomerNext} đã mua vé");
            Console.ResetColor();
        }

        public void HoanTien(Stack<string> paymentHistory)
        {
            if (paymentHistory.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Không có giao dịch nào để hoàn tiền.");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hoàn tiền thành công cho {paymentHistory.Pop()}.");
            Console.ResetColor();
        }

        public void SoatVe(HashSet<string> scannedTickets, string ticketCode)
        {
            if (scannedTickets.Contains(ticketCode))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vé {ticketCode} đã được quét trước đó. Không hợp lệ.");
                Console.ResetColor();
            }
            else
            {
                scannedTickets.Add(ticketCode);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Vé {ticketCode} hợp lệ. Chúc quý khách xem phim vui vẻ!");
                Console.ResetColor();
            }
        }

        public bool XemVeCoTonTai(List<string> codeTicket, string scanCode)
        {
            return codeTicket.Contains(scanCode);
        }
    }
}
