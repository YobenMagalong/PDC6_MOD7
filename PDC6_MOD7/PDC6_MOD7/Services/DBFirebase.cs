using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using PDC6_MOD7.Models;
using System.Collections.ObjectModel;

namespace PDC6_MOD7.Services
{

    public class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://pdc6mod9-default-rtdb.firebaseio.com/");
        }
        public ObservableCollection<Employee> getEmployee()
        {
            var employeeData = client
                .Child("Employee")
                .AsObservable<Employee>()
                .AsObservableCollection();

            return employeeData;
        }
        public async Task AddEmployee(int StudentId, string Name, string Course, int Year, string Section)
        {
            Employee em = new Employee() { studentid = StudentId, name = Name, course = Course, year = Year, section = Section };
            await client
                .Child("Employee")
                .PostAsync(em);
        }
    }
}
