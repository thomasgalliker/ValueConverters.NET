using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using ValueConverters;
using ValueConvertersSample.Forms.Model;
using ObservableObject = ValueConverters.ObservableObject;

namespace ValueConvertersSample.Forms.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private bool isEditing;
        private bool isEnabled;
        private DateTime changeDate;
        private EnumWrapper<RadioFrequency> radioFrequency;
        private PartyMode selectedPartyMode;
        private CultureInfo selectedLanguage;

        public MainViewModel()
        {
            this.selectedLanguage = CultureInfo.CurrentUICulture;

            // Initialize RadioFrequency enums using EnumWrapper explicitly
            this.RadioFrequencies = new EnumWrapperCollection<RadioFrequency>();
            this.radioFrequency = this.RadioFrequencies.FirstOrDefault();

            // Initialize PartyMode enum without EnumWrapper
            this.PartyModes = Enum.GetValues(typeof(PartyMode)).OfType<PartyMode>();
            this.selectedPartyMode = this.PartyModes.FirstOrDefault();

            this.EditCommand = new DelegateCommand(
                () =>
                    {
                        this.ChangeDate = DateTime.Now;
                        this.IsEditing = true;
                    });

            this.CancelCommand = new DelegateCommand(
                () =>
                {
                    this.IsEditing = false;
                });

            this.NextPartyModeCommand = new DelegateCommand(
               () =>
                   {
                       // Cycle through PartyMode enum:
                       this.SelectedPartyMode = (PartyMode)((int)(this.SelectedPartyMode + 1) % Enum.GetValues(this.SelectedPartyMode.GetType()).Length);
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

        // RadioFrequencies and SelectedRadioFrequency are wrapped into EnumWrapper objects.
        // Therefore, the view does not have to intercept the binding with the EnumWrapperConverter.
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

        // PartyModes and SelectedPartyMode are exposed as normal enum types.
        // The view needs to use the EnumWrapperConverter to convert these enums
        // on-the-fly to EnumWrapper<PartyMode> objects.
        public IEnumerable<PartyMode> PartyModes { get; private set; }

        public PartyMode SelectedPartyMode
        {
            get
            {
                return this.selectedPartyMode;
            }
            set
            {
                this.selectedPartyMode = value;
                this.OnPropertyChanged(() => this.SelectedPartyMode);
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
                    System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = value;

                    this.OnPropertyChanged(() => this.RadioFrequencies);
                    this.OnPropertyChanged(() => this.SelectedRadioFrequency);

                    this.OnPropertyChanged(() => this.PartyModes);
                    this.OnPropertyChanged(() => this.SelectedPartyMode);

                    // Refresh method triggers PropertyChanged events for all EnumWrapper.LocalizedValue properties
                    // We can only do this for RadioFrequencies since this is a List<EnumWrapper<RadioRequency>>
                    this.RadioFrequencies.Refresh();
                }
            }
        }
    }
}