using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class Driver_EditLoadResponse : BaseResponseModel
    {
        public Driver_EditLoadResponse()
        {
            Response = new EditLoadResponse();
        }
       // public EditLoadResponse Response { get; set; }
        //  public EditUser Response { get; set; }
        #region Properties
        private EditLoadResponse LoadObject;
        /// <summary>
        /// Gets or sets the employee object.
        /// </summary>
        /// <value>The employee object.</value>
        public EditLoadResponse Response
        {
            get
            {
                return LoadObject;
            }
            set
            {
                LoadObject = value; OnPropertyChanged();
            }
        }
        #endregion
    }
    public class LoadDetails : BaseResponseModel
    {
        public LoadDetails()
        {
          TollIds = new List<long>();
    }
        public int LoadId { get; set; }
    public int WorkSheetId { get; set; }
    public DateTime? LoadingDate { get; set; }
    public string LoadFrom { get; set; }
    public string DeliverTo { get; set; }
    public string BridgeDocket { get; set; }
    public double? NetWeight { get; set; }
    public double? KiloMeters { get; set; }
    public bool LoadStatus { get; set; }
    public string StartDeport { get; set; }
    public string DepartDeport { get; set; }
    public double? WaitTimePerMinute { get; set; }
    public string ArriveJob { get; set; }
    public string DepartJob { get; set; }
    public double? WaitTimePerMinuteJob { get; set; }
    public string Comments { get; set; }
        public List<long> TollIds { get; set; }
        public int? TollId { get; set; }
    public int? JobType { get; set; }
    public string Start { get; set; }
    public string Finish { get; set; }
    public double? Total { get; set; }
    public string CustomerSign { get; set; }   
    public object Tolls { get; set; }
    public double TotalTollAmount { get; set; }
    public int? CompanyId { get; set; }
    public int? TotalTolls { get; set; }
    public string EmployeeId { get; set; }
        public string TollName { get; set; }
        public string JobTypeName { get; set; }
    }

public class EditLoadResponse  : BaseResponseModel
    {
        public EditLoadResponse()
        {
            LoadDetails = new LoadDetails();
        }
public int StatusCode { get; set; }
public string Message { get; set; }
public string Description { get; set; }
public LoadDetails LoadDetails { get; set; }
}


}
