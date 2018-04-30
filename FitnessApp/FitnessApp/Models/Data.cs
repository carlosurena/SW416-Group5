using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace FitnessApp
{
    public class Data
    {
        public Data()
        {
            
        }

        #region ExerciseList
        public static ObservableCollection<Exercise> ExerciseList = new ObservableCollection<Exercise>
        {
            new Exercise { ItemID = 1, name = "Bench Press", primaryBodyPart = "Chest", secondaryBodyPart ="Tricep" },
            new Exercise { ItemID = 2, name = "Pull-Up", primaryBodyPart = "Back", secondaryBodyPart ="Shoulders" },
            new Exercise { ItemID = 3, name = "Ab Crunches", primaryBodyPart = "Abs", secondaryBodyPart ="" },
            new Exercise { ItemID = 4, name = "Incline Bench Press", primaryBodyPart = "Chest", secondaryBodyPart ="Shoulders" }

        };
        #endregion 
    }

}
