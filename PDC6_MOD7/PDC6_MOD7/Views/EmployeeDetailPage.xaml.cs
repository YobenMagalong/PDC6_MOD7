using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PDC6_MOD7.Models;
using PDC6_MOD7.Services;

namespace PDC6_MOD7.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeDetailPage : ContentPage
    {
        DBFirebase services;
        public EmployeeDetailPage(Employee employee)
        {
            InitializeComponent();
            BindingContext = employee;
            services = new DBFirebase();


        }
        public async void  BtnDelete(object sender, EventArgs e)
        {
            await services.DeleteEmployee(int.Parse(StudentId.Text), Name.Text, Course.Text, int.Parse(Year.Text), Section.Text);
            await Navigation.PushAsync(new EmployeeView());
        }

        public async void BtnUpdate(object sender, EventArgs e)
        {
            await services.UpdateEmployee(
                int.Parse(StudentId.Text), Name.Text, Course.Text, int.Parse(Year.Text), Section.Text);
            await Navigation.PushAsync(new EmployeeView());
        }
    }
}