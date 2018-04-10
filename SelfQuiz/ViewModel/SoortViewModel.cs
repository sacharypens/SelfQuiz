using BeheerContacten.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SelfQuiz.Model;

namespace SelfQuiz.ViewModel
{
    class SoortViewModel : BaseViewModel
    {
        public SoortViewModel() {

        }

        private ObservableCollection<Soort> soorten;
        public ObservableCollection<Soort> Soorten
        {
            get
            {
                return soorten;
            }

            set
            {
                soorten = value;
                NotifyPropertyChanged();
            }
        }

        private Soort currentSoort;
        public Soort CurrentSoort
        {
            get
            {
                return currentSoort;
            }

            set
            {
                currentSoort = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            VerwijderenCommand = new BaseCommand(VerwijderenSoort);
            WijzigenCommand = new BaseCommand(WijzigSoort);
            ToevoegenCommand = new BaseCommand(ToevoegenSoort);
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }

        private void LeesSoorten()
        {
            SoortDataService soortDataService = new SoortDataService();

            Soorten = new ObservableCollection<Soort>(soortDataService.getSoorten());
        }

        public void WijzigSoort()
        {
            if(CurrentSoort != null)
            {
                SoortDataService soortDataService = new SoortDataService();
                soortDataService.Updatesoort(CurrentSoort);

                LeesSoorten();
            }
        }

        public void ToevoegenSoort()
        {
            SoortDataService soortDataService = new SoortDataService();
            soortDataService.InsertSoort(CurrentSoort);

            LeesSoorten();
        }

        public void VerwijderenSoort()
        {
            if(CurrentSoort != null)
            {
                SoortDataService soortDataService = new SoortDataService();
                soortDataService.DeleteSoort(CurrentSoort);

                LeesSoorten();
            }
        }
    }
}
