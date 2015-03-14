using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PPSoft_SkedgeITModels
{
    public class EmployeeModel : SkedgeITModelConfig
    {
         //method name: Register
        //accepts: byte array of Employee information
        //returns: integer value of the Employee id
        //adds the Employee row to the database
        public int Register(byte[] bytEmployee)
        {
            int empId = -1; //needs to be completed;
            employee emp = new employee();
            ppsoftEntities dbContext = new ppsoftEntities();
            try
            {
                Dictionary<string, Object> dictionaryEmployee = (Dictionary<string, Object>)Deserializer(bytEmployee);
                dbContext = new ppsoftEntities();
                emp.password = Convert.ToString(dictionaryEmployee["password"]);
                emp.firstName = Convert.ToString(dictionaryEmployee["firstName"]);
                emp.lastName = Convert.ToString(dictionaryEmployee["lastName"]);
                emp.access_levelID = Convert.ToInt32(dictionaryEmployee["access_levelID"]);
                emp.sunStart = Convert.ToDateTime(dictionaryEmployee["sunStart"]);
                emp.sunEnd = Convert.ToDateTime(dictionaryEmployee["sunEnd"]);
                emp.sunStart = Convert.ToDateTime(dictionaryEmployee["monStart"]);
                emp.monEnd = Convert.ToDateTime(dictionaryEmployee["monEnd"]);
                emp.monStart = Convert.ToDateTime(dictionaryEmployee["tueStart"]);
                emp.tueEnd = Convert.ToDateTime(dictionaryEmployee["tueEnd"]);
                emp.tueStart = Convert.ToDateTime(dictionaryEmployee["wedStart"]);
                emp.wedEnd = Convert.ToDateTime(dictionaryEmployee["wedEnd"]);
                emp.thuStart = Convert.ToDateTime(dictionaryEmployee["thuStart"]);
                emp.thuEnd = Convert.ToDateTime(dictionaryEmployee["thuEnd"]);
                emp.friStart = Convert.ToDateTime(dictionaryEmployee["friStart"]);
                emp.friEnd = Convert.ToDateTime(dictionaryEmployee["friEnd"]);
                emp.satStart = Convert.ToDateTime(dictionaryEmployee["satStart"]);
                emp.satEnd = Convert.ToDateTime(dictionaryEmployee["satEnd"]);
                dbContext.employees.Add(emp);
                dbContext.SaveChanges();
                empId = emp.employeeID;
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "EmployeeModel", "Register");
            }

            return empId;  
        }


        //method name: UpdateEmployee
        //accepts: byte array of Employee information
        //returns: nothing
        //updates employee info in the database
        public void UpdateEmployee(byte[] bytEmployee, int empId)
        {
            employee emp;
            ppsoftEntities dbContext;

            try
            {
                Dictionary<string, Object> dictionaryEmployee = (Dictionary<string, Object>)Deserializer(bytEmployee);
                dbContext = new ppsoftEntities();
                emp = dbContext.employees.Where(e => e.employeeID == empId).FirstOrDefault();

                emp.password = Convert.ToString(dictionaryEmployee["password"]);
                emp.firstName = Convert.ToString(dictionaryEmployee["firstName"]);
                emp.lastName = Convert.ToString(dictionaryEmployee["lastName"]);
                emp.access_levelID = Convert.ToInt32(dictionaryEmployee["access_levelID"]);
                emp.sunStart = Convert.ToDateTime(dictionaryEmployee["sunStart"]);
                emp.sunEnd = Convert.ToDateTime(dictionaryEmployee["sunEnd"]);
                emp.monStart = Convert.ToDateTime(dictionaryEmployee["monStart"]);
                emp.monEnd = Convert.ToDateTime(dictionaryEmployee["monEnd"]);
                emp.tueStart = Convert.ToDateTime(dictionaryEmployee["tueStart"]);
                emp.tueEnd = Convert.ToDateTime(dictionaryEmployee["tueEnd"]);
                emp.wedStart = Convert.ToDateTime(dictionaryEmployee["wedStart"]);
                emp.wedEnd = Convert.ToDateTime(dictionaryEmployee["wedEnd"]);
                emp.thuStart = Convert.ToDateTime(dictionaryEmployee["thuStart"]);
                emp.thuEnd = Convert.ToDateTime(dictionaryEmployee["thuEnd"]);
                emp.friStart = Convert.ToDateTime(dictionaryEmployee["friStart"]);
                emp.friEnd = Convert.ToDateTime(dictionaryEmployee["friEnd"]);
                emp.satStart = Convert.ToDateTime(dictionaryEmployee["satStart"]);
                emp.satEnd = Convert.ToDateTime(dictionaryEmployee["satEnd"]);

                dbContext.SaveChanges();
                
                

            }
            catch (Exception ex)
            {

            }
        }

    }
}
