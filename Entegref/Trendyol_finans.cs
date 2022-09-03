using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entegref
{
    class Trendyol_finans
    {
        public class Content2
        {
            public string id { get; set; }
            public DateTime transactionDate { get; set; }
            public string transactionType { get; set; }
            public double debt { get; set; }
            public double credit { get; set; }
            public int? paymentOrderId { get; set; }
            public int sellerId { get; set; }
        }
        public class Content3
        {
            public string id { get; set; }
            public DateTime transactionDate { get; set; }
            public string barcode { get; set; }
            public string transactionType { get; set; }
            public string receiptId { get; set; }
            public string description { get; set; }
            public double debt { get; set; }
            public double credit { get; set; }
            public string paymentPeriod { get; set; }
            public string commissionRate { get; set; }
            public string commissionAmount { get; set; }
            public string sellerRevenue { get; set; }
            public string orderNumber { get; set; }
            public int? paymentOrderId { get; set; }
            public DateTime paymentDate { get; set; }
            public int sellerId { get; set; }
            public string storeId { get; set; }
            public string storeName { get; set; }
            public string storeAddress { get; set; }
        }
        public class Content
        {
            public string id { get; set; }
            public long transactionDate { get; set; }
            public string barcode { get; set; }
            public string transactionType { get; set; }
            public string receiptId { get; set; }
            public string description { get; set; }
            public double debt { get; set; }
            public double credit { get; set; }
            public string paymentPeriod { get; set; }
            public string commissionRate { get; set; }
            public string commissionAmount { get; set; }
            public string sellerRevenue { get; set; }
            public string orderNumber { get; set; }
            public int? paymentOrderId { get; set; }
            public long paymentDate { get; set; }
            public int sellerId { get; set; }
            public string storeId { get; set; }
            public string storeName { get; set; }
            public string storeAddress { get; set; }
        }

        public class Root
        {
            public int page { get; set; }
            public int size { get; set; }
            public int totalPages { get; set; }
            public int totalElements { get; set; }
            public List<Content> content { get; set; }
        }


    }
}
