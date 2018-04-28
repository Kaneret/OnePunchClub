using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public interface ISkill
    {
        string Name { get; }/// <summary>
        /// убрать из интерфейса послее тестов
        /// </summary>
        /// <param name="me"></param>
        void Setup(IFighter me);
        void Teardown(IFighter me);
    }
}
