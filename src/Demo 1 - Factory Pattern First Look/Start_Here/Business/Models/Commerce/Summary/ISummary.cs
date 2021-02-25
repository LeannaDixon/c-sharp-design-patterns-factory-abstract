using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Pattern_First_Look.Business.Models.Commerce.Summary
{
    public interface ISummary
    {
        string CreateOrderSummary(Order order);
        void Send();
    }

    public class EmailSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return $"Email summary {order.LineItems}";
        }

        public void Send()
        {
        }
    }

    public class CVSSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "CVS, Summary";
        }

        public void Send()
        {
        }
    }
}
