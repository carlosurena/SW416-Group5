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
            new Exercise { id = "1", name = "Bench Press", primaryBodyPart = "Chest", secondaryBodyPart ="Tricep" },
            new Exercise { id = "2", name = "Pull-Up", primaryBodyPart = "Back", secondaryBodyPart ="Shoulders" },
            new Exercise { id = "3", name = "Ab Crunches", primaryBodyPart = "Abs", secondaryBodyPart ="" },
            new Exercise { id = "4", name = "Incline Bench Press", primaryBodyPart = "Chest", secondaryBodyPart ="Shoulders" }

        };
        #endregion 
    }

}
