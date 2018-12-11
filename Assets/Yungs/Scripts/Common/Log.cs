using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yungs.D305
{
    public class YungsResult
    {
        public YungsResult() { }
        public YungsResult(int code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }
        public int Code
        {
            get;protected set;
        }
        public string Msg
        {
            get;protected set;
        }
    }
}