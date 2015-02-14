using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPSoft_SkedgeITModels;
using System.Data.Entity;

namespace PPSoft_SkedgeITViewModels
{
    class EmployeeViewModel : SkedgeITViewModelConfig
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
            firstName = Profile.firstName;
            lastName = Profile.lastName;
            accessLevel = Profile.access_level.ToString();
            SunStart = Convert.ToDateTime(Profile.sunStart);
            SunEnd   = Convert.ToDateTime(Profile.sunEnd);
            MonStart = Convert.ToDateTime(Profile.monStart);
            MonEnd   = Convert.ToDateTime(Profile.monEnd);
            TueStart = Convert.ToDateTime(Profile.tueStart);
            TueEnd   = Convert.ToDateTime(Profile.tueEnd);
            WedStart = Convert.ToDateTime(Profile.wedStart);
            WedEnd   = Convert.ToDateTime(Profile.wedEnd);
            ThuStart = Convert.ToDateTime(Profile.thuStart);
            ThuEnd   = Convert.ToDateTime(Profile.tueEnd);
            FriStart = Convert.ToDateTime(Profile.friStart);
            FriEnd   = Convert.ToDateTime(Profile.friEnd);
            SatStart = Convert.ToDateTime(Profile.satStart);
            SatEnd   = Convert.ToDateTime(Profile.satEnd);
            return retEmp;
        }

    }
}
