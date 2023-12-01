using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceAlertLibrary.DataAnalyzer
{
    public interface IEmailer
    {
        void SendEmail(string email, string message);
    }

}