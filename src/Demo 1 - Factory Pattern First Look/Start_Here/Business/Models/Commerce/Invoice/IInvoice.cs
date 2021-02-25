using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Pattern_First_Look.Business.Models.Commerce.Invoice
{
    public interface IInvoice
    {
        public Byte[] GenerateInterface();
    }

    public class GTSInvoice : IInvoice
    {
        public byte[] GenerateInterface()
        {
            return Encoding
                .Default
                .GetBytes("GTS Invoice");
        }
    }

    public class VATInvoice : IInvoice
    {
        public byte[] GenerateInterface()
        {
            return Encoding
            .Default
            .GetBytes("VATInvoice");
        }
    }

    public class NoInvoice : IInvoice
    {
        public byte[] GenerateInterface()
        {
            return Encoding
                .Default
                .GetBytes("No Invocie needed");
        }
    }
}
