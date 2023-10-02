using Classes.Interfaces;
using System.Collections.Generic;


namespace Classes
{
    public abstract class Generator : IGenerator
    {
        protected IEnumerable<Data> data;
        protected Data currentProcessedData { get; set; }

        public Generator(IEnumerable<Data> data)
        {
            this.data = data;
        }
        
        public void GenerateFiles()
        {
            HookStart();

            foreach(Data data in this.data)
            {
                currentProcessedData = data;
                DoInitFile();
                DoAddData();
                DoSaveFile();
            }

            HookEnd();
        }

        protected virtual void HookStart() 
        {

        }

        protected abstract void DoInitFile();

        protected abstract void DoAddData();

        protected abstract void DoSaveFile();

        protected virtual void HookEnd()
        {

        }
    }
}
