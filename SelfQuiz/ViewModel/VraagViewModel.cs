using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SelfQuiz.Model;

namespace SelfQuiz.ViewModel
{
    class VraagViewModel : BaseViewModel
    {
        public VraagViewModel()
        {

        }

        private ObservableCollection<Vraag> vragen;
        public ObservableCollection<Vraag> Vragen
        {
            get
            {
                return vragen;
            }

            set
            {
                vragen = value;
                NotifyPropertyChanged();
            }
        }

        private Vraag currentVraag;
        public Vraag CurrentVraag
        {
            get { return currentVraag; }
            set
            {
                currentVraag = value;
                NotifyPropertyChanged();
            }
        }

        public void KoppelenCommands()
        {
            
            WijzigCommand = new BaseCommand(WijzigenVragen);
            VerwijderCommand = new BaseCommand(VerwijderVraag);
            ToevoegCommand = new BaseCommand(ToevoegenVraag);
        }

        
        public ICommand WijzigCommand { get; set; }
        public ICommand VerwijderCommand { get; set; }
        public ICommand ToevoegCommand { get; set; }
        private void LeesVragen()
        {
            // Instantiëren dataservice
            VraagDataService vraagDataService = new VraagDataService();

            Vragen = new ObservableCollection<Vraag>(vraagDataService.getVragen());
        }

        public void WijzigenVragen()
        {
            if(CurrentVraag != null)
            {
                VraagDataService vraagDataService = new VraagDataService();
                vraagDataService.UpdateVraag(CurrentVraag);

                // refresh
                LeesVragen();
            }
        }

        public void VerwijderVraag()
        {
            if(CurrentVraag != null)
            {
                VraagDataService vraagDataService = new VraagDataService();
                vraagDataService.DeleteVraag(CurrentVraag);

                // refresh
                LeesVragen();
            }
        }

        public void ToevoegenVraag()
        {
            if(CurrentVraag != null)
            {
                VraagDataService vraagDataService = new VraagDataService();
                vraagDataService.InsertVraag(CurrentVraag);

                LeesVragen();
            }
        }
    }
}
