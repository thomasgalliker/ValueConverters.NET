using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

namespace ValueConverterSample.UWP.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool isEditing;
        private bool isEnabled;
        private DateTime changeDate;

        public MainViewModel()
        {
            this.EditCommand = new RelayCommand(
                () =>
                    {
                        this.IsEditing = true;
                        this.ChangeDate = DateTime.Now;
                    });

            this.CancelCommand = new RelayCommand(
                () =>
                {
                    this.IsEditing = false;
                    this.ChangeDate = DateTime.Now;
                });
        }

        public bool IsEditing
        {
            get
            {
                return this.isEditing;
            }
            set
            {
                this.isEditing = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                this.isEnabled = value;
                this.OnPropertyChanged();
            }
        }

        public DateTime ChangeDate
        {
            get
            {
                return this.changeDate;
            }
            set
            {
                this.changeDate = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand EditCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
