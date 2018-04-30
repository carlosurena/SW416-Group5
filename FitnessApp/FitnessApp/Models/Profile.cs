using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FitnessApp
{
    public class Profile
    {
        public Profile()
        {
            
        }

        public static ObservableCollection<ProfileInfo> Profiles = new ObservableCollection<ProfileInfo>
        {
            new ProfileInfo {id = "1", name = "Sarah Kurtz", age = 21}
        };
    }
}

