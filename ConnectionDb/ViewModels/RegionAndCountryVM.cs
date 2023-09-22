using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDb.ViewModels;
public class RegionAndCountryVM
{
    public int EmployeeId { get; set; }
    public string CountryName { get; set; }
    public string RegionName { get; set; }
    public string Department { get; set; }
    public string StreetAdres { get; set; }
    public int Salary { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Fullname { get; set; }


    public override string ToString()
    {
        return $" {EmployeeId} - {Fullname} - {Email} - {Phone} - {Salary} - {Department}- {StreetAdres} - {CountryName} - {RegionName}";
    }
}
