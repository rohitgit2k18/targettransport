using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Models;

namespace TargetTransport.ViewModels
{
   public  class ShiftDataViewModel
    {
        public ObservableCollection<ShiftDataModel> GetShiftType()
        {
            var list = new ObservableCollection<ShiftDataModel>
         {
               new ShiftDataModel
               {
                   ShiftId=0,
                   ShiftName="Day"
               },
                new ShiftDataModel
               {

                   ShiftId=1,
                   ShiftName="Night"
               }
          };
            return list;
        }
    }
}
