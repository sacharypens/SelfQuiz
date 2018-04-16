using BeheerContacten.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfQuiz.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private int selectedIndex;
        public int SelectedIdex
        {
            get { return selectedIndex; }
            set
            {
                if(selectedIndex == value) {
                    return;
                }
                selectedIndex = value;
                NotifyPropertyChanged();
                
            }
        }

        private string frameSource;
        public string FrameSource
        {
            get { return frameSource; }
            set { frameSource = value; NotifyPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            FrameSource = "VragenViewer.xaml";
            selectedIndex = 0;
        }

        public void ChangePagina(int pagina)
        {
            switch(pagina)
            {
                case 0:
                    FrameSource = "VragenViewer.xaml";
                    break;
                case 1:
                    FrameSource = "SoortViewer.xaml";
                    break;
            }
        }
    }
}
