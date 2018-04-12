using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class MockExercises : IDataStore<Item>
    {
        List<Item> exercises;

        public MockExercises()
        {
            
            var mockExercises = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Bench Press", BodyPart="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Back Squat", BodyPart="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Dumbbell Lunges", BodyPart="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Lateral Raises", BodyPart="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Military Press", BodyPart="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Pull-up", BodyPart="This is an item description." },
            };

            foreach (var item in mockExercises)
            {
                exercises.Add(item);
            }
            //foreach (var exercise in mockExercises)
            //{
            //    exercises.Add(exercise);
            //}
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            exercises.Add(item);

            return await Task.FromResult(true);
        }



        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = exercises.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            exercises.Remove(_item);
            exercises.Add(item);

            return await Task.FromResult(true);
        }



        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = exercises.Where((Item arg) => arg.Id == id).FirstOrDefault();
            exercises.Remove(_item);

            return await Task.FromResult(true);
        }


        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(exercises.FirstOrDefault(s => s.Id == id));
        }


        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(exercises);
        }

    }
}
