using CodeFitness.BL.Controller;
using System.Collections.Generic;

namespace CodeFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataSave manager = new SerializeDataSave();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}