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
    class VraagTagViewModel : BaseViewModel
    {
        public VraagTagViewModel()
        {
            LeesVraagTags();
            KoppelenCommands();
        }

        private ObservableCollection<VraagTag> vraagTags;
        public ObservableCollection<VraagTag> VraagTags
        {
            get
            {
                return vraagTags;
            }

            set
            {
                vraagTags = value;
                NotifyPropertyChanged();
            }
        }

        private VraagTag currentVraagTag;
        public VraagTag CurrentVraagTag
        {
            get
            {
                return currentVraagTag;
            }

            set
            {
                currentVraagTag = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            VerwijderenCommand = new BaseCommand(VerwijderenVraagTag);
            WijzigenCommand = new BaseCommand(WijzigVraagTag);
            ToevoegenCommand = new BaseCommand(ToevoegenVraagTag);
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }

        private void LeesVraagTags()
        {
            VraagTagDataService vraagTagDataService = new VraagTagDataService();

            VraagTags = new ObservableCollection<VraagTag>(vraagTagDataService.getVraagTags());
        }

        public void WijzigVraagTag()
        {
            if(CurrentVraagTag != null)
            {
                VraagTagDataService vraagTagDataService = new VraagTagDataService();
                vraagTagDataService.UpdatevraagTag(CurrentVraagTag);

                LeesVraagTags();
            }
        }

        public void ToevoegenVraagTag()
        {
            VraagTagDataService vraagTagDataService = new VraagTagDataService();
            vraagTagDataService.InsertVraagTag(CurrentVraagTag);

            LeesVraagTags();
        }

        public void VerwijderenVraagTag()
        {
            if(CurrentVraagTag != null)
            {
                VraagTagDataService vraagTagDataService = new VraagTagDataService();
                vraagTagDataService.DeleteVraagTag(CurrentVraagTag);

                LeesVraagTags();
            }
        }
    }
}
