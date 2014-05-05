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
            this.RawItems = new ObservableCollection<RawItemViewModel>();
            this.ToastItems = new ObservableCollection<ToastItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<RawItemViewModel> RawItems { get; private set; }
        public ObservableCollection<ToastItemViewModel> ToastItems { get; private set; }

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
            this.RawItems.Add(new RawItemViewModel() { Message = "raw one" });
            this.RawItems.Add(new RawItemViewModel() { Message = "raw two" });
            this.RawItems.Add(new RawItemViewModel() { Message = "raw three" });
            this.RawItems.Add(new RawItemViewModel() { Message = "raw four" });
            this.RawItems.Add(new RawItemViewModel() { Message = "raw five" });
            this.RawItems.Add(new RawItemViewModel() { Message = "raw six" });
            this.RawItems.Add(new RawItemViewModel() { Message = "raw seven" });

            this.ToastItems.Add(new ToastItemViewModel() { Text1 = "toast one" });
            this.ToastItems.Add(new ToastItemViewModel() { Text1 = "toast two" });
            this.ToastItems.Add(new ToastItemViewModel() { Text1 = "toast three" });
            this.ToastItems.Add(new ToastItemViewModel() { Text1 = "toast four" });
            this.ToastItems.Add(new ToastItemViewModel() { Text1 = "toast five" });
            this.ToastItems.Add(new ToastItemViewModel() { Text1 = "toast six" });
            this.ToastItems.Add(new ToastItemViewModel() { Text1 = "toast seven" });

            this.IsDataLoaded = true;
        }

        public void AddToastItem(string text1, string text2, string param = null)
        {
            var itemViewModel = new ToastItemViewModel();
            itemViewModel.Text1 = text1;
            itemViewModel.Text2 = text2;
            itemViewModel.Param = param;
            this.ToastItems.Add(itemViewModel);
        }

        public void AddRawItem(string text)
        {
            var itemViewModel = new RawItemViewModel();
            itemViewModel.Message = text;
            this.RawItems.Add(itemViewModel);
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