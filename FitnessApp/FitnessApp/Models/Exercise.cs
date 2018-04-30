using System;
using SQLite;

namespace FitnessApp
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int eID { get; set; }
        public int ItemID { get; set; }
        public string name { get; set; }
        public string primaryBodyPart { get; set; }
        public string secondaryBodyPart { get; set; }

    }
}
