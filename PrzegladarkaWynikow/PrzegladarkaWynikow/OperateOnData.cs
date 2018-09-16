using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace PrzegladarkaWynikow
{
    class OperateOnData
    {
        Form2 form2 = new Form2();
        public void DrawGraph(string[] dataSplitted, int counter)
        {
            if (counter % 5 == 0)
            {
                form2.dataGraph.Titles["Title"].Text = dataSplitted[0];
            }
            else
            {
                for (int i = 0; i < dataSplitted.Length - 1; i++)
                {
                    float dataToDrawFloat = float.Parse(dataSplitted[i].Replace(".", ","));
                    form2.dataGraph.Series["angle"].Points.Add(dataToDrawFloat);
                    Debug.WriteLine(dataToDrawFloat);

                }
            }
        }
    }
}
