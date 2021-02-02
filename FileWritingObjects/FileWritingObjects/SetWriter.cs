using System;
using System.IO;

namespace FileWritingObjects
{
    class SetWriter : IDisposable
    {
        private bool DisposedValue = false;
        private StreamWriter? Writer;

        public SetWriter(string filePath)
        {
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath), "The filepath is null");
            }

            this.Writer = new StreamWriter(filePath);
        }

        public void FileWriteSet(NumSet set)
        {
            if (Writer is null)
                throw new ArgumentNullException(nameof(Writer), "Writer in FileWriteSet is null");
            if (set is null)
                throw new ArgumentNullException(nameof(set), "Set in FileWriteSet is null");

            this.Writer.WriteLine(set.ToString());
        }

        protected void Dispose(bool disposing)
        {
            if (Writer == null)
                throw new ArgumentNullException(nameof(Writer), "Writer is null in Dispose");

            if(!DisposedValue)
            {
                if(disposing)
                    Writer.Dispose();

                DisposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
