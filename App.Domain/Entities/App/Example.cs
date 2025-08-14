using System;

#nullable disable

namespace App.Domain.Entities.App
{
    public partial class Example
    {
        public long ExampleId { get; set; }
        public decimal ExampleAmount { get; set; }
        public string ExampleFromUserId { get; set; }
        public string ExampleToUserId { get; set; }
        public string ExampleCreateBy { get; set; }
        public DateTime ExampleCreateDate { get; set; }
        public string ExampleUpdateBy { get; set; }
        public DateTime? ExampleUpdateDate { get; set; }

    }
}
