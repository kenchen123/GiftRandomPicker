using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using SQLite;

namespace GiftRandomPicker.Models
{
    public class EasterSteps
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Step1 { get; set; }
        public string Step2 { get; set; }
        public string Step3 { get; set; }
        public string Step4 { get; set; }
        public string Step5 { get; set; }
        public string Step6 { get; set; }
        public string Step7 { get; set; }
        public string Step8 { get; set; }
        public string Step9 { get; set; }
        public string Step10 { get; set; }

    }
}
