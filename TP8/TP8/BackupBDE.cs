using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class BackupBDE
    {
        private IMemento _memento;

        public IMemento Memento
        {
            get { return _memento; }
            set { _memento = value; }
        }
    }
}
