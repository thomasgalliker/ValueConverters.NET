using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ValueConverters;
using ValueConvertersSample.Contracts.Model;

namespace MauiSampleApp.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private bool isEditing;
        private bool isEnabled;
        private DateTime changeDate;
        private EnumWrapper<RadioFrequency>? radioFrequency;
        private PartyMode selectedPartyMode;
        private CultureInfo selectedLanguage;
        private string? userName;
        private double rangeValue;
        private string thicknessText = "16,8";
        private object? optionalValue;
        private int selectedCount;
        private double selectedRatio;
        private string booleanText = "ready";
        private string caseText = "value converters for maui";
        private string decimalText = "123.45";
        private double calculationValue;
        private string approvalState = "approved";
        private string statusKey = "SuccessStatusColor";
        private string keyboardText = string.Empty;

        public MainViewModel()
        {
            this.selectedLanguage = Thread.CurrentThread.CurrentUICulture;
            this.ChangeDate = DateTime.Now;
            this.rangeValue = 42;
            this.userName = string.Empty;
            this.selectedCount = 3;
            this.selectedRatio = 0.75;
            this.calculationValue = 24;

            // Initialize RadioFrequency enums using EnumWrapper explicitly
            this.RadioFrequencies = new EnumWrapperCollection<RadioFrequency>();
            this.radioFrequency = this.RadioFrequencies.FirstOrDefault();

            // Initialize PartyMode enum without EnumWrapper
            var partyModes = Enum.GetValues<PartyMode>();
            this.PartyModesArray = partyModes;

            this.PartyModes = new ObservableCollection<PartyMode>(partyModes);
            this.selectedPartyMode = this.PartyModes.FirstOrDefault();

            this.EditCommand = new RelayCommand(
                () =>
                {
                    this.IsEditing = true;
                });

            this.CancelCommand = new RelayCommand(
                () =>
                {
                    this.IsEditing = false;
                });

            this.NextPartyModeCommand = new RelayCommand(
               () =>
               {
                   // Cycle through PartyMode enum:
                   this.SelectedPartyMode = (PartyMode)((int)(this.SelectedPartyMode + 1) % Enum.GetValues(this.SelectedPartyMode.GetType()).Length);
               });

            this.ClearPartyModesCommand = new RelayCommand(
                () =>
                {
                    this.PartyModes.Clear();
                    this.RaisePropertyChanged(nameof(this.PartyModes));
                });

            this.FillPartyModesCommand = new RelayCommand(
                () =>
                {
                    this.PartyModes = new ObservableCollection<PartyMode>(Enum.GetValues(typeof(PartyMode)).OfType<PartyMode>());
                    this.RaisePropertyChanged(nameof(this.PartyModes));
                });

            this.ToggleOptionalValueCommand = new RelayCommand(
                () =>
                {
                    this.OptionalValue = this.OptionalValue == null ? "Sample value" : null;
                });

            this.CycleSelectedCountCommand = new RelayCommand(
                () =>
                {
                    this.SelectedCount = this.SelectedCount == 3 ? 5 : 3;
                });

            this.ToggleSelectedRatioCommand = new RelayCommand(
                () =>
                {
                    this.SelectedRatio = Math.Abs(this.SelectedRatio - 0.75) < 0.001 ? 0.5 : 0.75;
                });

            this.ToggleBooleanTextCommand = new RelayCommand(
                () =>
                {
                    this.BooleanText = this.BooleanText == "ready" ? "waiting" : "ready";
                });

            this.ToggleApprovalStateCommand = new RelayCommand(
                () =>
                {
                    this.ApprovalState = this.ApprovalState == "approved" ? "draft" : "approved";
                });

            this.ToggleStatusKeyCommand = new RelayCommand(
                () =>
                {
                    this.StatusKey = this.StatusKey == "SuccessStatusColor" ? "DangerStatusColor" : "SuccessStatusColor";
                });
        }

        public string? UserName
        {
            get => this.userName;
            set => this.SetProperty(ref this.userName, value);
        }

        public double RangeValue
        {
            get => this.rangeValue;
            set => this.SetProperty(ref this.rangeValue, value);
        }

        public string ThicknessText
        {
            get => this.thicknessText;
            set => this.SetProperty(ref this.thicknessText, value);
        }

        public object? OptionalValue
        {
            get => this.optionalValue;
            set => this.SetProperty(ref this.optionalValue, value);
        }

        public int SelectedCount
        {
            get => this.selectedCount;
            set => this.SetProperty(ref this.selectedCount, value);
        }

        public double SelectedRatio
        {
            get => this.selectedRatio;
            set => this.SetProperty(ref this.selectedRatio, value);
        }

        public string BooleanText
        {
            get => this.booleanText;
            set => this.SetProperty(ref this.booleanText, value);
        }

        public string CaseText
        {
            get => this.caseText;
            set => this.SetProperty(ref this.caseText, value);
        }

        public string DecimalText
        {
            get => this.decimalText;
            set => this.SetProperty(ref this.decimalText, value);
        }

        public double CalculationValue
        {
            get => this.calculationValue;
            set => this.SetProperty(ref this.calculationValue, value);
        }

        public string ApprovalState
        {
            get => this.approvalState;
            set => this.SetProperty(ref this.approvalState, value);
        }

        public string StatusKey
        {
            get => this.statusKey;
            set => this.SetProperty(ref this.statusKey, value);
        }

        public string KeyboardText
        {
            get => this.keyboardText;
            set => this.SetProperty(ref this.keyboardText, value);
        }

        public DateTimeOffset SampleDateTimeOffset { get; } = new DateTimeOffset(2026, 5, 25, 14, 30, 0, TimeSpan.FromHours(2));

        public TimeSpan SampleDuration { get; } = new TimeSpan(1, 2, 30, 0);

        public Guid SampleGuid { get; } = new Guid("7b52f40d-8f5d-45c3-a124-93d31c3b2d23");

        public Version SampleVersion { get; } = new Version(2, 4, 1, 17);

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

        public EnumWrapper<RadioFrequency>? SelectedRadioFrequency
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

        public ICommand ToggleOptionalValueCommand { get; private set; }

        public ICommand CycleSelectedCountCommand { get; private set; }

        public ICommand ToggleSelectedRatioCommand { get; private set; }

        public ICommand ToggleBooleanTextCommand { get; private set; }

        public ICommand ToggleApprovalStateCommand { get; private set; }

        public ICommand ToggleStatusKeyCommand { get; private set; }

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
