using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxaWeb.Domain.Entities
{
   public class WebSite
    {
        public virtual int Id
        { get; set; }

        public virtual string Name
        { get; set; }

        public virtual int Type  //1-шаблонный  2-индивидуальный 3-Эксклюзивный
        { get; set; }

        public virtual int Price
        { get; set; }

        public virtual DateTime DateCreate
        { get; set; }

        public virtual DateTime? DateEnding
        { get; set; }

        public virtual string TZ
        { get; set; }

        public virtual bool TZ_true_false
        { get; set; }

        public virtual string Dogovor
        { get; set; }



    }
}
