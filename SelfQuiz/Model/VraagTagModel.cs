using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfQuiz.Model
{
    class VraagTagModel : BaseModel
    {
        private int id;
        private int tagId;
        private int vraagId;

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

        public int TagId
        {
            get
            {
                return tagId;
            }

            set
            {
                tagId = value;
                NotifyPropertyChanged();
            }
        }

        public int VraagId
        {
            get
            {
                return vraagId;
            }

            set
            {
                vraagId = value;
                NotifyPropertyChanged();
            }
        }
    }
}
