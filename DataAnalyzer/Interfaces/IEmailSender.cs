using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(string email, string message);
    }
}
