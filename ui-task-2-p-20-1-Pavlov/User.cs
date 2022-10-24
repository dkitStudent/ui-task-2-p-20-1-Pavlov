using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ui_task_2_p_20_1_Pavlov
{
    public class User : INotifyPropertyChanged
    {
        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region Private fields
        private string _name;
        private string _email;
        private string _gitHub;
        #endregion
        #region Public Property
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string gitHub
        {
            get { return _gitHub; }
            set
            {
                _gitHub = value;
                OnPropertyChanged("GitHub");
            }
        }
        #endregion
        public User(string name, string email, string gitHub)
        {
            _name = name;
            _email = email;
            _gitHub = gitHub;
        }
        public override int GetHashCode()
        {
            return (_name + _email + _gitHub).GetHashCode();
        }
    }
}
