using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; }

        public DateTime Finish { get; }

        public Activity Activity { get; }

        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException(nameof(activity));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
