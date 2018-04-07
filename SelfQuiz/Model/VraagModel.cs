using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfQuiz.Model
{
    class VraagModel : BaseModel
    {
        private int id;
        private string vraag;
        private string antwoord;
        private int soortId;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public string Vraag
        {
            get
            {
                return vraag;
            }

            set
            {
                vraag = value;
                NotifyPropertyChanged();
            }
        }

        public string Antwoord
        {
            get
            {
                return antwoord;
            }

            set
            {
                antwoord = value;
                NotifyPropertyChanged();
            }
        }

        public int SoortId
        {
            get
            {
                return soortId;
            }

            set
            {
                soortId = value;
                NotifyPropertyChanged();
            }
        }
    }
}
