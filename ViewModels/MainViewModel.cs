using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace Push
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.RawItems = new ObservableCollection<ItemViewModel>();
            this.ToastItems = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> RawItems { get; private set; }
        public ObservableCollection<ItemViewModel> ToastItems { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.RawItems.Add(new ItemViewModel() { Message = "raw one" });
            this.RawItems.Add(new ItemViewModel() { Message = "raw two" });
            this.RawItems.Add(new ItemViewModel() { Message = "raw three" });
            this.RawItems.Add(new ItemViewModel() { Message = "raw four" });
            this.RawItems.Add(new ItemViewModel() { Message = "raw five" });
            this.RawItems.Add(new ItemViewModel() { Message = "raw six" });
            this.RawItems.Add(new ItemViewModel() { Message = "raw seven" });

            this.ToastItems.Add(new ItemViewModel() { Message = "toast one" });
            this.ToastItems.Add(new ItemViewModel() { Message = "toast two" });
            this.ToastItems.Add(new ItemViewModel() { Message = "toast three" });
            this.ToastItems.Add(new ItemViewModel() { Message = "toast four" });
            this.ToastItems.Add(new ItemViewModel() { Message = "toast five" });
            this.ToastItems.Add(new ItemViewModel() { Message = "toast six" });
            this.ToastItems.Add(new ItemViewModel() { Message = "toast seven" });

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}