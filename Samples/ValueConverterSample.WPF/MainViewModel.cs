using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

using ValueConverterSample.WPF.Annotations;

namespace ValueConverterSample.WPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool isEditing;
        private bool isEnabled;

        private DateTime changeDate;

        public MainViewModel()
        {
            this.ToggleIsEditingCommand = new RelayCommand(
                () =>
                    {
                        this.IsEditing = !this.IsEditing;
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

        public ICommand ToggleIsEditingCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
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
