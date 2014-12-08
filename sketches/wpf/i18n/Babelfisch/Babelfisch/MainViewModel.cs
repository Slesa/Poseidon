using System;
using Babelfisch.MvvmUtils;

namespace Babelfisch
{
    public class MainViewModel : ViewModelBase
    {
        public ActionCommand InfosAnzeigenCommand { get; set; }

        private DateTime _aktuellesDatum;
        public DateTime AktuellesDatum
        {
            get { return _aktuellesDatum; }
            set
            {
                _aktuellesDatum = value; 
                OnPropertyChanged();
            }
        }

        private string _datumAlsText;
        public string DatumAlsText
        {
            get { return _datumAlsText; }
            set
            {
                _datumAlsText = value; 
                OnPropertyChanged();
            }
        }

        private string _begrüßungAusVm;
        public string BegrüßungAusVM
        {
            get { return _begrüßungAusVm; }
            set
            {
                _begrüßungAusVm = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            InfosAnzeigenCommand = new ActionCommand(InfosAnzeigen);
        }

        private void InfosAnzeigen()
        {
            AktuellesDatum = DateTime.Now;
            EigenschaftenAktualisieren();
        }

        protected override void OnCurrentCultureChanged()
        {
            EigenschaftenAktualisieren();
        }

        private void EigenschaftenAktualisieren()
        {
            DatumAlsText = _aktuellesDatum.ToString("G");
            BegrüßungAusVM = CurrentCulture["BegrüßungAusVM"];
        }
    }
}