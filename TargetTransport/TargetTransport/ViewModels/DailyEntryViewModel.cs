using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Models;
using TargetTransport_Api.Models;

namespace TargetTransport.ViewModels
{
   public class DailyEntryViewModel
    {
        public ObservableCollection<DailyEntryRadio> GetRadioType()
        {
            var list = new ObservableCollection<DailyEntryRadio>
         {
               new DailyEntryRadio
               {
                  
                   Name="Yes"
               },
                new DailyEntryRadio
               {
                  
                   Name="No"
               }
          };
            return list;
        }

    }
}
