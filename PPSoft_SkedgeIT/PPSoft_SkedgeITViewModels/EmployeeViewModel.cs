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
            employee Profile = dbContext.employees.FirstOrDefault(e => e.employeeID == id);
            if (Profile == null)
                return null;
            retEmp.firstName = Profile.firstName;
            retEmp.lastName = Profile.lastName;
            retEmp.accessLevel = Profile.access_level.ToString();
            retEmp.password = Profile.password.ToString();
            retEmp.SunStart = Convert.ToDateTime(Profile.sunStart);
            retEmp.SunEnd = Convert.ToDateTime(Profile.sunEnd);
            retEmp.MonStart = Convert.ToDateTime(Profile.monStart);
            retEmp.MonEnd = Convert.ToDateTime(Profile.monEnd);
            retEmp.TueStart = Convert.ToDateTime(Profile.tueStart);
            retEmp.TueEnd = Convert.ToDateTime(Profile.tueEnd);
            retEmp.WedStart = Convert.ToDateTime(Profile.wedStart);
            retEmp.WedEnd = Convert.ToDateTime(Profile.wedEnd);
            retEmp.ThuStart = Convert.ToDateTime(Profile.thuStart);
            retEmp.ThuEnd = Convert.ToDateTime(Profile.tueEnd);
            retEmp.FriStart = Convert.ToDateTime(Profile.friStart);
            retEmp.FriEnd = Convert.ToDateTime(Profile.friEnd);
            retEmp.SatStart = Convert.ToDateTime(Profile.satStart);
            retEmp.SatEnd = Convert.ToDateTime(Profile.satEnd);
            return retEmp;
        }

    }
}
