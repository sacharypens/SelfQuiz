using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfQuiz.Model
{
    class SoortModel : BaseModel
    {
        private int id;
        private string soort;

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

        public string Soort
        {
            get
            {
                return soort;
            }

            set
            {
                soort = value;
                NotifyPropertyChanged();
            }
        }
    }
}
