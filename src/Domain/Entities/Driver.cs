using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class Driver
{
    public int Id { get; set; }
    public String Name { get; set; } = String.Empty;
    public String Email { get; set; } = String.Empty;
    public String Phone { get; set; } = String.Empty;
    public int Age { get; set; }
}
