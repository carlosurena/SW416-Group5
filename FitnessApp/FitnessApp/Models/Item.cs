using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;

namespace FitnessApp
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Day { get; set; }
        //public ObservableCollection<Exercise> exerciseList { get; set; }
    }
}
