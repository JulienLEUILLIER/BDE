using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public interface IVisitor
    {
        void visitTransaction(Transaction transaction);
    }
}
