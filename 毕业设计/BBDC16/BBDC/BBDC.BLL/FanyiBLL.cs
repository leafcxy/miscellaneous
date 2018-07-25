using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBDC.BLL
{
    public class FanyiBLL
    {
        private readonly BBDC.DAL.FanyiDAL fy = new DAL.FanyiDAL();

        public string GetWord(string word, int type)
        {
            if (type == 1)
            { return fy.GetWord(word); }
            return fy.GetChinese(word);
        }


    }
}
