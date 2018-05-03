using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FitnessApp
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Exercise> exerciseList { get; set; }
    }
}
