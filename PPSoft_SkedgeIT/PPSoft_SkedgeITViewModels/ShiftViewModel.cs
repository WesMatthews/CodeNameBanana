using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPSoft_SkedgeITModels;

namespace PPSoft_SkedgeITViewModels
{
    public class ShiftViewModel : SkedgeITViewModelConfig
    {
        public int shiftID { get; set; }
        public int employeeID { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string Department { get; set; }

        public List<ShiftViewModel> getShifts(DateTime date)
        {

            List<ShiftViewModel> retShifts = new List<ShiftViewModel>();
            try
            {
                ShiftModel shifts = new ShiftModel();
                List<ShiftModel> shiftData = shifts.getShifts(date);
                foreach (ShiftModel s in shiftData)
                {
                    ShiftViewModel svm = new ShiftViewModel();
                    svm.shiftID = s.shiftID;
                    svm.employeeID = s.employeeID;
                    svm.start = s.startTime;
                    svm.end = s.endTime;
                    svm.Department = s.department.ToString();
                    retShifts.Add(svm);
                }
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "ShiftViewModel", "getShifts");
            }
            return retShifts;
        }

        public List<ShiftViewModel> getShifts(int empID)
        {

            List<ShiftViewModel> retShifts = new List<ShiftViewModel>();
            try
            {
                ShiftModel shifts = new ShiftModel();
                List<ShiftModel> shiftData = shifts.getShifts(empID);
                foreach (ShiftModel s in shiftData)
                {
                    ShiftViewModel svm = new ShiftViewModel();
                    svm.shiftID = s.shiftID;
                    svm.employeeID = s.employeeID;
                    svm.start = s.startTime;
                    svm.end = s.endTime;
                    svm.Department = s.department.ToString();
                    retShifts.Add(svm);
                }
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "ShiftViewModel", "getShifts");
            }
            return retShifts;
        }

        public int Delete(int id)
        {
            int rowsDeleted = -1;

            try
            {
                ppsoftEntities dbContext = new ppsoftEntities();
                shift cEntity = dbContext.shifts.FirstOrDefault(shift => shift.employeeID == id);
                int rowsBeforeDeleted = dbContext.shifts.Count();
                dbContext.shifts.Remove(cEntity);
                dbContext.SaveChanges();
                int rowsAfterDeleted = dbContext.shifts.Count();
                rowsDeleted = rowsBeforeDeleted - rowsAfterDeleted;
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ShiftViewModel", "Delete");
            }
            return rowsDeleted;
        }
        public void AddShift()
        {
            Dictionary<string, Object> dictionaryShift;
            {
                dictionaryShift = new Dictionary<string, Object>();
                ShiftModel sftModel = new ShiftModel();
                dictionaryShift["start"] = start;
                dictionaryShift["end"] = end;
                dictionaryShift["empID"] = employeeID;
                sftModel.addShift(Serializer(dictionaryShift));
            }
        }

        public override string ToString()
        {
            string retString = "";
            retString += "ID: " + shiftID + " Start Time: " + start + " End Time: " + end + " Dept: " + Department;
            return retString;
        }
    }

}
