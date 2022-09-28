using CreditSuisseTest.Enum;
using EnumsNET;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CreditSuisseTest.Services
{
    internal class TradeService : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }

        public List<string> GetCategory(DateTime referenceDate, int businessNumber, List<string> content)
        {
            try
            {
                List<string> categories = new List<string>();
                if (content != null || content.Count > 0)
                {
                    foreach (var item in content)
                    {
                        FillObject(item);
                        if (DateTime.Now > this.NextPaymentDate.AddDays(30))
                            categories.Add(((Category)Category.EXPIRED).AsString(EnumFormat.Description));
                        else if (this.Value > 1000000 && this.ClientSector.Equals("Private"))
                            categories.Add(((Category)Category.HIGHRISK).AsString(EnumFormat.Description));
                        else if (this.Value > 1000000 && this.ClientSector.Equals("Public"))
                            categories.Add(((Category)Category.MEDIUMRISK).AsString(EnumFormat.Description));
                    }
                }

                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error. {ex.Message}");
            }
        }

        private void FillObject(string content)
        {
            try
            {
                string[] formats = { "mm/dd/yyyy" };
                string[] arrContent = content.Split(" ");
                this.Value = Convert.ToDouble(arrContent[0]);
                this.ClientSector = arrContent[1];
                this.NextPaymentDate = DateTime.ParseExact(arrContent[2], formats, new CultureInfo("en-US"), DateTimeStyles.None);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
