using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Push
{
    public class BaseItemViewModel : INotifyPropertyChanged
    {
        public BaseItemViewModel()
        {
            SentAt = DateTime.Now.ToString("MMM dd, yyyy HH:mm:ss");
            _id = Guid.NewGuid().ToString();
        }

        private string _id;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Id
        {
            get
            {
                return _id;
            }
        }

        private string _sentAt;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string SentAt
        {
            get
            {
                return _sentAt;
            }
            set
            {
                if (value != _sentAt)
                {
                    _sentAt = value;
                    NotifyPropertyChanged("SentAt");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}