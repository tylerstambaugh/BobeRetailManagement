using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {

            string rateText = ConfigurationManager.AppSettings["TaxRate"];

            bool isValidRate = Decimal.TryParse(rateText, out decimal output);

            if (!isValidRate)
            {
                throw new ConfigurationErrorsException("The tax rate is not correct in app.config");
            }

            return output;
        }
    }
}
