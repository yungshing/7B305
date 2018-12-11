using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 namespace Yungs.D305
{
    public class DamageValue : IDamage
    {
        public DamageStyle DamageStyle { get; set; }

        public int AttackDamage { get; set; }
        public int CriticalDamage { get; set; }
        public int AttachDamage { get; set; }
    }
}
