using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PDC6_MOD7.ViewModels;
using PDC6_MOD7.Models;

namespace PDC6_MOD7.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeView : ContentPage
    {
        public EmployeeView()
        {
            InitializeComponent();
            BindingContext = new EmployeeViewModel();
        }

        public async void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var employee = args.Item as Employee;
            if (employee == null) return;

            await Navigation.PushAsync(new EmployeeDetailPage(employee));
            lstEmployee.SelectedItem = null;
        }
    }
}