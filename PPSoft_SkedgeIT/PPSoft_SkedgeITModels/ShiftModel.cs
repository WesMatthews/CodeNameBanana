using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPSoft_SkedgeITModels
{
    public class ShiftModel : SkedgeITModelConfig
    {

        public List<ShiftModel> getShifts(DateTime date)
        {
            ppsoftEntities dbContext = new ppsoftEntities();
            List<ShiftModel> retShifts = new List<ShiftModel>();
            try
            {
               // var SelectedShifts = dbContext.shifts.Where(s=>s.date == date); // need to update the DBmodel
                
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "ShiftModel", "getShifts");
            }
            return retShifts;
        }

        public List<shift> getShifts(int empID)
        {
            ppsoftEntities dbContext = new ppsoftEntities();
            List<shift> retShifts = new List<shift>();
            try
            {
                retShifts = dbContext.shifts.Where(s => s.employeeID == empID).ToList();
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "ShiftModel", "getShifts");
            }
            return retShifts;
        }
    }
}
