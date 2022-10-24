using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ui_task_2_p_20_1_Pavlov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _hashCode;
        private bool _cancelChanges;
        public MainWindow()
        {
            InitializeComponent();
            _cancelChanges = false;
            var user = new User("Pavel", "dkitneeds@gmail.com", "dkitStudent");
            _hashCode = user.GetHashCode();
            DataContext = user;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DataContext.GetHashCode() != _hashCode && !_cancelChanges)
            {
                MDSSnackbarUnsavedChanges.IsActive = true;
                e.Cancel = true;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext.GetHashCode() != _hashCode && !_cancelChanges)
            {
                MDSSnackbarUnsavedChanges.IsActive = true;
                MDSSnackbarMessage.Content = "Data updated!";
                MDSSnackbarMessage.ActionContent = "OK!";
            }
        }

        private void MDSSnackbarMessage_ActionClick(object sender, RoutedEventArgs e)
        {
            MDSSnackbarUnsavedChanges.IsActive = false;
            _cancelChanges = true;
            Close();
        }
    }
}
