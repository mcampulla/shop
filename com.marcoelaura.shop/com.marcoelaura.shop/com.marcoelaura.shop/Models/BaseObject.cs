using com.marcoelaura.shop.Helpers;
using System;

namespace com.marcoelaura.shop.Models
{
    public class BaseObject : ObservableObject
    {
        public BaseObject()
        {
            //Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Id for item
        /// </summary>
        public string Id { get; set; }

        ///// <summary>
        ///// Azure created at time stamp
        ///// </summary>
        //public DateTimeOffset CreatedAt { get; set; }

        ///// <summary>
        ///// Azure UpdateAt timestamp for online/offline sync
        ///// </summary>
        //public DateTimeOffset UpdatedAt { get; set; }

        ///// <summary>
        ///// Azure version for online/offline sync
        ///// </summary>
        //public string AzureVersion { get; set; }        
    }
}
