using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPSoft_SkedgeITModels;
using System.Data.Entity;

namespace PPSoft_SkedgeITViewModels
{
    public class EmployeeViewModel : SkedgeITViewModelConfig
    {
        public int EmployeeID { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string accessLevel { get; set; }
        public DateTime SunStart { get; set; }
        public DateTime SunEnd   { get; set; }
        public DateTime MonStart { get; set; }
        public DateTime MonEnd   { get; set; }
        public DateTime TueStart { get; set; }
        public DateTime TueEnd   { get; set; }
        public DateTime WedStart { get; set; }
        public DateTime WedEnd   { get; set; }
        public DateTime ThuStart { get; set; }
        public DateTime ThuEnd   { get; set; }
        public DateTime FriStart { get; set; }
        public DateTime FriEnd   { get; set; }
        public DateTime SatStart { get; set; }
        public DateTime SatEnd   { get; set; }
        public string Message { get; set; }
        ///<summary>
        ///This Method called to Register a new Employee to the Database
        ///</summary>

        public void Register()
        {
            Dictionary<string, Object> dictionaryEmployee = new Dictionary<string,Object>();
            try
            {
                EmployeeModel myData = new EmployeeModel();
                dictionaryEmployee["password"] = password;
                dictionaryEmployee["firstName"] = firstName;
                dictionaryEmployee["lastName"] = lastName;
                dictionaryEmployee["access_levelID"] = accessLevel;
                dictionaryEmployee["sunStart"] = SunStart;
                dictionaryEmployee["sunEnd"] = SunEnd;
                dictionaryEmployee["monStart"] = MonStart;
                dictionaryEmployee["monEnd"] = MonEnd;
                dictionaryEmployee["tueStart"] = TueStart;
                dictionaryEmployee["tueEnd"] = TueEnd;
                dictionaryEmployee["wedStart"] = WedStart;
                dictionaryEmployee["wedEnd"] = WedEnd;
                dictionaryEmployee["thuStart"] = ThuStart;
                dictionaryEmployee["thuEnd"] = ThuEnd;
                dictionaryEmployee["friStart"] = FriStart;
                dictionaryEmployee["friEnd"] = FriEnd;
                dictionaryEmployee["satStart"] = SatStart;
                dictionaryEmployee["satEnd"] = SatEnd;
                EmployeeID = myData.Register(Serializer(dictionaryEmployee));
                Message = "Employee Sucessfully Registered";
            }
            catch (Exception ex)
            {
                Message = "Employee not registered, problem was " + ex.Message;
                ErrorRoutine(ex, "EmployeeViewModel", "Register");
            }
        }

        /// <summary>
        /// This will select an Employee Profile based upon provided 
        /// employee ID
        /// <accepts>int employeeID</accepts>
        /// <returns>EmployeeViewModel </returns>
        /// </summary>
        public EmployeeViewModel getEmployeeProfile(int id)
        {
            EmployeeViewModel retEmp = new EmployeeViewModel();
            ppsoftEntities dbContext = new ppsoftEntities();
            //employee Profile = dbContext.employees.FirstOrDefault(e => e.employeeID == id);
            var Profile = from e in dbContext.employees
                               join a in dbContext.access_level on e.access_levelID equals a.access_levelID
                               where (e.employeeID == id)
                               select new EmployeeViewModel
                               {
                                   EmployeeID = e.employeeID,
                                   firstName = e.firstName,
                                   lastName = e.lastName,
                                   accessLevel = a.access,
                                   password = e.password,
                                   SunStart = (DateTime)e.sunStart,
                                   SunEnd = (DateTime)e.sunEnd,
                                   MonStart = (DateTime)e.monStart,
                                   MonEnd = (DateTime)e.monEnd,
                                   TueStart = (DateTime)e.tueStart,
                                   TueEnd = (DateTime)e.tueEnd,
                                   WedStart = (DateTime)e.wedStart,
                                   WedEnd = (DateTime)e.wedEnd,
                                   ThuStart = (DateTime)e.thuStart,
                                   ThuEnd = (DateTime)e.thuEnd,
                                   FriStart = (DateTime)e.friStart,
                                   FriEnd = (DateTime)e.friEnd,
                                   SatStart = (DateTime)e.satStart,
                                   SatEnd = (DateTime)e.satEnd
                               };
            if (Profile.Count() != 1)
                return null;
            retEmp = Profile.ToList<EmployeeViewModel>()[0];
            return retEmp;
        }

        public void UpdateEmployee(int empId)
        {
            Dictionary<string, Object> dictionaryEmployee;
            try
            {
                dictionaryEmployee = new Dictionary<string, Object>();
                EmployeeModel empModel = new EmployeeModel();
                dictionaryEmployee["password"] = password;
                dictionaryEmployee["firstName"] = firstName;
                dictionaryEmployee["lastName"] = lastName;
                dictionaryEmployee["access_levelID"] = accessLevel;
                dictionaryEmployee["sunStart"] = SunStart;
                dictionaryEmployee["sunEnd"] = SunEnd;
                dictionaryEmployee["monStart"] = MonStart;
                dictionaryEmployee["monEnd"] = MonEnd;
                dictionaryEmployee["tueStart"] = TueStart;
                dictionaryEmployee["tueEnd"] = TueEnd;
                dictionaryEmployee["wedStart"] = WedStart;
                dictionaryEmployee["wedEnd"] = WedEnd;
                dictionaryEmployee["thuStart"] = ThuStart;
                dictionaryEmployee["thuEnd"] = ThuEnd;
                dictionaryEmployee["friStart"] = FriStart;
                dictionaryEmployee["friEnd"] = FriEnd;
                dictionaryEmployee["satStart"] = SatStart;
                dictionaryEmployee["satEnd"] = SatEnd;
                empModel.UpdateEmployee(Serializer(dictionaryEmployee),empId);
                Message = "Employee " + empId + " Updated Successfully";
            }
            catch (Exception ex)
            {
                Message = "Employee not updated, problem was " + ex.Message;
                ErrorRoutine(ex, "EmployeeViewModel", "UpdateEmployee");
            }
        }

    }
}
