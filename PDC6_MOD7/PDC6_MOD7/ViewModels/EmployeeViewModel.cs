using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using PDC6_MOD7.Models;
using PDC6_MOD7.Services;
using MvvmHelpers;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PDC6_MOD7.ViewModels
{
    class EmployeeViewModel : BaseViewModel
    {
        public int studentid { get; set; }
        public string name { get; set; }
        public string course { get; set; }
        public int year { get; set; }
        public string section { get; set; }

        private DBFirebase services;
        public Command AddEmployeeCommand { get; }
        public ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }
        public EmployeeViewModel()
        {
            services = new DBFirebase();
            Employees = services.getEmployee();
            AddEmployeeCommand = new Command(async () => await addEmployeeAsync(studentid, name, course, year, section));

        }
        public async Task addEmployeeAsync(int studentid, string name, string course, int year, string section)
        {
            await services.AddEmployee(studentid, name, course, year, section);
        }

    }
}
