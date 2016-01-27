using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

using ValueConverters;

using ValueConverterSample.WPF.Model;

namespace ValueConverterSample.WPF.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private bool isEditing;
        private bool isEnabled;
        private DateTime changeDate;
        private EnumWrapper<RadioFrequency> radioFrequency;
        private PartyMode partyMode;
        private CultureInfo selectedLanguage;

        public MainViewModel()
        {
            this.selectedLanguage = Thread.CurrentThread.CurrentUICulture;
            this.RadioFrequencies = new EnumWrapperCollection<RadioFrequency>();
            this.radioFrequency = this.RadioFrequencies.FirstOrDefault();
            this.partyMode = PartyMode.Off;

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

            this.NextPartyModeCommand = new RelayCommand(
               () =>
                   {
                       // Cycle through PartyMode enum:
                       this.PartyMode = (PartyMode)((int)(this.PartyMode + 1) % Enum.GetValues(this.PartyMode.GetType()).Length);
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
                this.OnPropertyChanged(() => this.IsEditing);
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
                this.OnPropertyChanged(() => this.IsEnabled);
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
                this.OnPropertyChanged(() => this.ChangeDate);
            }
        }

        public EnumWrapperCollection<RadioFrequency> RadioFrequencies { get; private set; }

        public EnumWrapper<RadioFrequency> SelectedRadioFrequency
        {
            get
            {
                return this.radioFrequency;
            }
            set
            {
                this.radioFrequency = value;
                this.OnPropertyChanged(() => this.SelectedRadioFrequency);
            }
        }

        public PartyMode PartyMode
        {
            get
            {
                return this.partyMode;
            }
            set
            {
                this.partyMode = value;
                this.OnPropertyChanged(() => this.PartyMode);
            }
        }

        public ICommand EditCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public ICommand NextPartyModeCommand { get; private set; }

        public IEnumerable<CultureInfo> Languages
        {
            get
            {
                return new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de"),
                    new CultureInfo("sv")
                };
            }
        }

        public CultureInfo SelectedLanguage
        {
            get
            {
                return this.selectedLanguage;
            }
            set
            {
                this.selectedLanguage = value;
                this.OnPropertyChanged(() => this.SelectedLanguage);

                if (value != null)
                {
                    Thread.CurrentThread.CurrentUICulture = value;

                    this.OnPropertyChanged(() => this.RadioFrequencies);
                    this.OnPropertyChanged(() => this.SelectedRadioFrequency);
                    this.OnPropertyChanged(() => this.PartyMode);

                    // Here we trigger PropertyChanged events for all EnumWrapper.LocalizedValue properties
                    this.RadioFrequencies.Refresh();
                }
            }
        }
    }
}