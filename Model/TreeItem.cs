using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TreeItem
    {
         public string Id{get;set;}

         public string FullName{get;set;}

         public string NavigateUrl{get;set;}

         public string ParentId{get;set;}
         
        public bool Open{get;set;}

    }
}
