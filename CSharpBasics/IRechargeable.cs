using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    // Bất kỳ class nào gắn Interface này BẮT BUỘC phải có hàm Charge()
    public interface IRechargeable
    {
        void Charge();
    }
}
