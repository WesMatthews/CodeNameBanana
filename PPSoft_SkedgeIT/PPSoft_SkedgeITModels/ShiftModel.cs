using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPSoft_SkedgeITModels
{
    public class ShiftModel : SkedgeITModelConfig
    {
        public int shiftID { get; set; }
        public int employeeID { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string department { get; set; }

        public List<ShiftModel> getShifts(DateTime date)
        {
            ppsoftEntities dbContext = new ppsoftEntities();
            List<ShiftModel> retShifts = new List<ShiftModel>();
            try
            {
                 
                // var SelectedShifts = dbContext.shifts.Where(s=>s.date == date); // need to update the DBmodel
                DateTime searchDate = date.Date;
                var Shifts = from s in dbContext.shifts
                             join d in dbContext.departments on s.departmentID equals d.departmentID
                           //  where ((s.date.Day == searchDate.Day) && (s.date.Month == searchDate.Month) && (s.date.Year == searchDate.Year))
                             where ((s.startTime.Year == searchDate.Year) &&
                                    (s.startTime.Month == searchDate.Month) &&
                                    (s.startTime.Day == searchDate.Day))
                             select new ShiftModel
                             {
                                 shiftID = s.shiftID,
                                 employeeID = s.employeeID,
                                 startTime = s.startTime,
                                 endTime = s.endTime,
                                 department = d.department1

                             };
                retShifts = Shifts.ToList<ShiftModel>();                    
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "ShiftModel", "getShifts");
            }
            return retShifts;
        }

        public List<ShiftModel> getShifts(int empID)
        {

            List<ShiftModel> retShifts = new List<ShiftModel>();
            try
            {
                ppsoftEntities dbContext = new ppsoftEntities();
                // retShifts = dbContext.shifts.Where(s => s.employeeID == empID).ToList();
                var Shifts = from s in dbContext.shifts
                             join d in dbContext.departments on s.departmentID equals d.departmentID
                             where (s.employeeID == empID)
                             select new ShiftModel
                             {
                                 shiftID = s.shiftID,
                                 employeeID = s.employeeID,
                                 startTime = s.startTime,
                                 endTime = s.endTime,
                                 department = d.department1

                             };


                retShifts = Shifts.ToList<ShiftModel>();

            }
            catch (Exception e)
            {
                ErrorRoutine(e, "ShiftModel", "getShifts");
            }
            return retShifts;
        }
        public int addShift(byte[] bytShift)
        {
            int shiftID = -1;
            shift sft = new shift();
            ppsoftEntities dbContext = new ppsoftEntities();
            try
            {
                Dictionary<string, Object> dictionaryShift = (Dictionary<string, Object>)Deserializer(bytShift);
                sft.startTime = Convert.ToDateTime(dictionaryShift["start"]);
                sft.endTime = Convert.ToDateTime(dictionaryShift["end"]);
                sft.employeeID = Convert.ToInt32(dictionaryShift["empID"]);
                sft.departmentID = 1;
                dbContext.shifts.Add(sft);
                dbContext.SaveChanges();
                shiftID = sft.shiftID;
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ShiftModel", "AddShift");
            }
            return shiftID;
        }
    }

}
