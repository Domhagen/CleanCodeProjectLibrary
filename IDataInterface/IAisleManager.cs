using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IAisleManager
    {
        void AddAisle(int aisleNumber);
        Aisle GetAisleByAisleNumber(int aisleNumber);
        void RemoveAisle(int aisleID);
    }
}
