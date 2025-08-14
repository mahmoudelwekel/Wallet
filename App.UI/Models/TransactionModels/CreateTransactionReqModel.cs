using System;
using System.ComponentModel.DataAnnotations;

namespace App.UI.Models.ExampleModels
{
    public class CreateExampleReqModel
    {
        public long ExampleId { get; set; }


        [Display(Name = "Amount", Prompt = "Amount")]
        public decimal ExampleAmount { get; set; }
        public string ExampleFromUserId { get; set; }
        public string ExampleToUserId { get; set; }


        [Display(Name = "Phone Number", Prompt = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^(?:01[0-9]{9})$")]
        [Phone]
        public string ExampleToUserPhone { get; set; }




        public string ExampleCreateBy { get; set; }
        public DateTime ExampleCreateDate { get; set; }
        public string ExampleUpdateBy { get; set; }
        public DateTime? ExampleUpdateDate { get; set; }
    }
}
