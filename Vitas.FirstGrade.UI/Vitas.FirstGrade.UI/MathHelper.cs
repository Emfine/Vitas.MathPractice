using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitas.FirstGrade.UI
{
    internal class MathHelper
    {
        private readonly Random rad;
        private readonly List<string> operList;

        internal MathHelper()
        {
            rad = new Random();
            operList = new List<string>() { "+", "-" };
        }

        internal int CalcByDataTable(string expression)
        {
            object result = new DataTable().Compute(expression, "");
            return Convert.ToInt32(result);
        }

        internal StringBuilder TwoDigitMix(int num)
        {
            int minusMax = 100;
            var operQueue = new List<string>();
            var expression = new StringBuilder();
            expression.Append(rad.Next(10, minusMax));

            for (int idx = 0; idx < num - 1; idx++)
            {
                var oList = operList.Where(x => !operQueue.Contains(x)).ToList();
                int opIdx = rad.Next(0, oList.Count);
                operQueue.Add(oList[opIdx]);

                minusMax = 99;
                //如果是减法需要保证减数小于被减数
                if (operQueue[idx] == "-")
                {
                    //计算出减数最大值，如果超出99则最大值按99
                    int max = CalcByDataTable(expression.ToString());
                    if (max < 100) minusMax = max;
                }
                expression.Append($"{operQueue[idx]}{rad.Next(10, minusMax)}");
            }

            expression.Append("=");

            return expression;
        }
    }
}