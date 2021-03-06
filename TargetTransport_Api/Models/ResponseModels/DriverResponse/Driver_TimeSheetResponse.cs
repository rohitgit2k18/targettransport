﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport_Api.Models.ResponseModels.DriverResponse
{
   public class Driver_TimeSheetResponse
    {
        public TimeingResponse Response { get; set; }
    }
    public class WorkTimeList
    {
        public int Id { get; set; }
        public DateTime? WorkDate { get; set; }
        public DateTime? ProgramStartTime { get; set; }
        public DateTime? ApprovedStartTime { get; set; }
        public DateTime? ActualStartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? StartTime { get; set; }
        public string BreakTime { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comments { get; set; }
        public string WorkHours { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int EmployeeId { get; set; }
        public string WorksheetNumber { get; set; }
        public int WorksheetId { get; set; }
        public int TotalHrs { get; set; }
        public string totalHrs { get; set; }

        // public int Id { get; set; }
        // public DateTime WorkDate { get; set; }
        public string WorkDateBinding { get; set; }
     //   public DateTime ProgramStartTime { get; set; }
        public string ProgramStartTimeBinding { get; set; }
      //  public DateTime ApprovedStartTime { get; set; }
        public string ApprovedStartTimeBinding { get; set; }
      //  public string ActualStartTime { get; set; }
       // public DateTime EndTime { get; set; }
        public string EndTimeBinding { get; set; }
       // public DateTime StartTime { get; set; }
        public string StartTimeBinding { get; set; }
      //  public string BreakTime { get; set; }
       // public DateTime EndDate { get; set; }
        public string EndDateBinding { get; set; }
       // public string Comments { get; set; }
       // public string WorkHours { get; set; }
       // public int CreatedBy { get; set; }
       // public DateTime CreatedOn { get; set; }
       // public bool IsActive { get; set; }
       // public bool IsDeleted { get; set; }
       // public int EmployeeId { get; set; }
       // public object WorksheetNumber { get; set; }
       // public int TotalHrs { get; set; }

        
    }

public class TimeingResponse
{
   
public int StatusCode { get; set; }
public List<WorkTimeList> WorkTimeList { get; set; }
public string TotalHrs { get; set; }
  public string Message { get; set; }
  public string Description { get; set; }
}


}
