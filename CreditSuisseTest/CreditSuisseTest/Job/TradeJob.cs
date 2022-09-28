using CreditSuisseTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseTest.Job
{
    internal class TradeJob
    {
        private readonly TradeService _tradeService;
        DateTime _date;
        int _number;
        List<string> _contets = new List<string>();
        public TradeJob(TradeService tradeService, DateTime referenceDate, int businessNumber, List<string> contents )
        {
            _tradeService = tradeService;
            _date = referenceDate;
            _number = businessNumber;
            _contets = contents;
        }
        public List<string> TraderProcess()
        {
            try
            {
                return _tradeService.GetCategory(_date, _number, _contets);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error. {ex.Message}");
            }
        }
    }
}
