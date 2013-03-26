using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public class DisplayLetter : INotifyPropertyChanged
    {
        private bool _Active;

        public string Name { get; set; }
        public bool Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
                if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Active"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
