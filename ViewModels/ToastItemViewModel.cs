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
    public class ToastItemViewModel : BaseItemViewModel
    {
        public ToastItemViewModel()
            : base()
        {
        }

        private string _text1;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Text1
        {
            get
            {
                return _text1;
            }
            set
            {
                if (value != _text1)
                {
                    _text1 = value;
                    NotifyPropertyChanged("Text1");
                }
            }
        }

        private string _text2;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Text2
        {
            get
            {
                return _text2;
            }
            set
            {
                if (value != _text2)
                {
                    _text1 = value;
                    NotifyPropertyChanged("Text2");
                }
            }
        }

        private string _param;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Param
        {
            get
            {
                return _param;
            }
            set
            {
                if (value != _param)
                {
                    _param = value;
                    NotifyPropertyChanged("Param");
                }
            }
        }
    }
}