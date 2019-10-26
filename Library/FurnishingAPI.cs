using System;
using System.Collections.Generic;
using System.Text;
using IDataInterface;
using DataAccess;

namespace Library
{
    public class FurnishingAPI
    {
        private IAisleManager aisleManager;
        private IShelfManager shelfManager;

        public FurnishingAPI(IAisleManager aisleManager, IShelfManager shelfManager)
        {
            this.aisleManager = aisleManager;
            this.shelfManager = shelfManager;
        }
        public bool AddAisle(int aisleNumber)
        {
            var avaibleAisle = aisleManager.GetAisleByAisleNumber(aisleNumber);
            if (avaibleAisle != null)
                return false;
            aisleManager.AddAisle(aisleNumber);
                return true;
        }

        public RemoveAisleErrorCodes RemoveAisle(int aisleNumber)
        {
            var newAisle = aisleManager.GetAisleByAisleNumber(aisleNumber);
            if (newAisle == null)
                return RemoveAisleErrorCodes.NoSuchAisle;

            if (newAisle.Shelf.Count > 0)
                return RemoveAisleErrorCodes.AisleHasShelves;

            aisleManager.RemoveAisle(newAisle.AisleID);

            return RemoveAisleErrorCodes.Ok;
        }

        public bool AddShelf(int shelfNumber)
        {
            var avaibleShelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (avaibleShelf != null)
                return false;
            shelfManager.AddShelf(shelfNumber);
            return true;
        }

        public MoveShelfErrorCodes MoveShelf(int shelfNumber, int aisleNumber)
        {
            var newAisle = aisleManager.GetAisleByAisleNumber(aisleNumber);
            if (newAisle == null)
                return MoveShelfErrorCodes.NoSuchAisle;
            
            var shelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (shelf == null)
                return MoveShelfErrorCodes.NoSuchShelf;

            if (shelf.Aisle.AisleNumber == aisleNumber)
                return MoveShelfErrorCodes.ShelfAlreadyInThatAisle;

            shelfManager.MoveShelf(shelf.ShelfID, newAisle.AisleID);
            
            return MoveShelfErrorCodes.Ok;
        }
    }
}
