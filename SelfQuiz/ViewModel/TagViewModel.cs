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
    class TagViewModel : BaseViewModel
    {
        public TagViewModel()
        {
            LeesTags();
            KoppelenCommands();
        }

        private ObservableCollection<Tag> tags;
        public ObservableCollection<Tag> Tags
        {
            get
            {
                return tags;
            }

            set
            {
                tags = value;
                NotifyPropertyChanged();
            }
        }

        private Tag currentTag;
        public Tag CurrentTag
        {
            get
            {
                return currentTag;
            }

            set
            {
                currentTag = value;
                NotifyPropertyChanged();
            }
        }

        private void KoppelenCommands()
        {
            VerwijderenCommand = new BaseCommand(VerwijderenTag);
            WijzigenCommand = new BaseCommand(WijzigTag);
            ToevoegenCommand = new BaseCommand(ToevoegenTag);
        }

        public ICommand VerwijderenCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }

        private void LeesTags()
        {
            TagDataService tagDataService = new TagDataService();

            Tags = new ObservableCollection<Tag>(tagDataService.getTags());
        }

        public void WijzigTag()
        {
            if(CurrentTag != null)
            {
                TagDataService tagDataService = new TagDataService();
                tagDataService.Updatetag(CurrentTag);

                LeesTags();
            }
        }

        public void ToevoegenTag()
        {
            TagDataService tagDataService = new TagDataService();
            tagDataService.InsertTag(CurrentTag);

            LeesTags();
        }

        public void VerwijderenTag()
        {
            if(CurrentTag != null)
            {
                TagDataService tagDataService = new TagDataService();
                tagDataService.DeleteTag(CurrentTag);

                LeesTags();
            }
        }
    }
}
