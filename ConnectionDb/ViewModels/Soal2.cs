using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb.ViewModels;
public class Soal2
{

    public string Department { get; set; }
    public int TotalEmployees { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public double AverageSalary { get; set; }


    public override string ToString()
    {
        return $"{Department} - {TotalEmployees} - {MinSalary} - {MaxSalary} - {AverageSalary}";
    }
}
