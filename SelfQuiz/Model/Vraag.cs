using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfQuiz.Model
{
    class Vraag : BaseModel
    {
        private int id;
        private string naam;
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

        public string Naam
        {
            get
            {
                return naam;
            }

            set
            {
                naam = value;
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
