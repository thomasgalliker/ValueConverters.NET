using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

using ValueConverters;
using ValueConvertersSample.Contracts.Model;

namespace MauiSampleApp.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private bool isEditing;
        private bool isEnabled;
        private DateTime changeDate;
        private EnumWrapper<RadioFrequency> radioFrequency;
        private PartyMode selectedPartyMode;
        private CultureInfo selectedLanguage;
        private string userName;

        public MainViewModel()
        {
            this.selectedLanguage = Thread.CurrentThread.CurrentUICulture;
            this.ChangeDate = DateTime.Now;

            // Initialize RadioFrequency enums using EnumWrapper explicitly
            this.RadioFrequencies = new EnumWrapperCollection<RadioFrequency>();
            this.radioFrequency = this.RadioFrequencies.FirstOrDefault();

            // Initialize PartyMode enum without EnumWrapper
            var partyModes = Enum.GetValues<PartyMode>();
            this.PartyModesArray = partyModes;

            this.PartyModes = new ObservableCollection<PartyMode>(partyModes);
            this.selectedPartyMode = this.PartyModes.FirstOrDefault();

            this.EditCommand = new DelegateCommand(
                () =>
                {
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

            this.ClearPartyModesCommand = new DelegateCommand(
                () =>
                {
                    this.PartyModes.Clear();
                    this.RaisePropertyChanged(nameof(this.PartyModes));
                });

            this.FillPartyModesCommand = new DelegateCommand(
                () =>
                {
                    this.PartyModes = new ObservableCollection<PartyMode>(Enum.GetValues(typeof(PartyMode)).OfType<PartyMode>());
                    this.RaisePropertyChanged(nameof(this.PartyModes));
                });
        }

        public string UserName
        {
            get => this.userName;
            set => this.SetProperty(ref this.userName, value);
        }

        public bool IsEditing
        {
            get => this.isEditing;
            set
            {
                this.isEditing = value;
                this.RaisePropertyChanged(nameof(this.IsEditing));
            }
        }

        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetProperty(ref this.isEnabled, value);
        }

        public DateTime ChangeDate
        {
            get => this.changeDate;
            set => this.SetProperty(ref this.changeDate, value);
        }

        // RadioFrequencies and SelectedRadioFrequency are wrapped into EnumWrapper objects.
        // Therefore, the view does not have to intercept the binding with the EnumWrapperConverter.
        public EnumWrapperCollection<RadioFrequency> RadioFrequencies { get; private set; }

        public EnumWrapper<RadioFrequency> SelectedRadioFrequency
        {
            get => this.radioFrequency;
            set => this.SetProperty(ref this.radioFrequency, value);
        }

        // PartyModes and SelectedPartyMode are exposed as normal enum types.
        // The view needs to use the EnumWrapperConverter to convert these enums
        // on-the-fly to EnumWrapper<PartyMode> objects.
        public ObservableCollection<PartyMode> PartyModes { get; private set; }

        public PartyMode[] PartyModesArray { get; private set; }

        public PartyMode SelectedPartyMode
        {
            get => this.selectedPartyMode;
            set => this.SetProperty(ref this.selectedPartyMode, value);
        }

        public ICommand EditCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public ICommand NextPartyModeCommand { get; private set; }

        public ICommand ClearPartyModesCommand { get; private set; }

        public ICommand FillPartyModesCommand { get; private set; }

        public IEnumerable<CultureInfo> Languages => new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("de"),
            new CultureInfo("sv")
        };

        public CultureInfo SelectedLanguage
        {
            get => this.selectedLanguage;
            set
            {
                if (this.SetProperty(ref this.selectedLanguage, value))
                {
                    if (value != null)
                    {
                        Thread.CurrentThread.CurrentCulture = value;
                        Thread.CurrentThread.CurrentUICulture = value;

                        this.RaisePropertyChanged();
                        //this.RaisePropertyChanged(nameof(this.RadioFrequencies));
                        //this.RaisePropertyChanged(nameof(this.SelectedRadioFrequency));
                        //this.RaisePropertyChanged(nameof(this.PartyModes));
                        //this.RaisePropertyChanged(nameof(this.SelectedPartyMode));

                        // Refresh method triggers PropertyChanged events for all EnumWrapper.LocalizedValue properties
                        // We can only do this for RadioFrequencies since this is a List<EnumWrapper<RadioRequency>>
                        this.RadioFrequencies.Refresh();
                    }
                }
            }
        }
    }
}
