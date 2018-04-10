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
    class VraagViewModel : BaseViewModel
    {
        public VraagViewModel()
        {
            LeesVragen();
            KoppelenCommands();
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
            get
            {
                return currentVraag;
            }

            set
            {
                currentVraag = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            VerwijderenCommand = new BaseCommand(VerwijderenVraag);
            WijzigenCommand = new BaseCommand(WijzigVraag);
            ToevoegenCommand = new BaseCommand(ToevoegenVraag);
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }

        private void LeesVragen()
        {
            // Instantiëren dataservice
            VraagDataService vraagDataService = new VraagDataService();

            Vragen = new ObservableCollection<Vraag>(vraagDataService.getVragen());
        }

        public void WijzigVraag()
        {
            if(CurrentVraag != null)
            {
                VraagDataService vraagDataService = new VraagDataService();
                vraagDataService.UpdateVraag(CurrentVraag);

                LeesVragen();
            }            
        }

        public void ToevoegenVraag()
        {
            VraagDataService vraagDataService = new VraagDataService();
            vraagDataService.InsertVraag(CurrentVraag);

            LeesVragen();
        }

        public void VerwijderenVraag()
        {
            if(CurrentVraag != null)
            {
                VraagDataService vraagDataService = new VraagDataService();
                vraagDataService.DeleteVraag(CurrentVraag);

                LeesVragen();
            }
        }
    }
}
