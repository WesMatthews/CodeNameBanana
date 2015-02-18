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
    }

}
