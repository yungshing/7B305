using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yungs.D305
{
    public interface ISkill
    {
        /// <summary>
        /// 技能释放
        /// </summary>
        void Play();
        /// <summary>
        /// 技能结束
        /// </summary>
        void End();
        /// <summary>
        /// 技能中止
        /// </summary>
        void Stop();
    }
}
