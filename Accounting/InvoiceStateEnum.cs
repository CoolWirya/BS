using System;


namespace Accounting
{
    public enum InvoiceStateEnum : byte
    {
        NoAction=0,
        Varified=1,
        NotVarified=2,
        InProgress=3,
        Done=4
    }
}