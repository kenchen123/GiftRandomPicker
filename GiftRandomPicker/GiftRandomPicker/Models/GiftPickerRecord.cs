using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GiftRandomPicker.Models
{
    public class RecordTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Record { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class Record
    {
        public string CurrentName { get; set; }
        public string CurrentGiftNumber { get; set; }
        public List<string> Employees { get; set; }
        public List<int> Gifts { get; set; }
    }
}
