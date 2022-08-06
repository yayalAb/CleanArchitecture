using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Deriver.Queries.GetDrivers;
public class DriverVm
{
    public IList<DriverDto> Lists { get; set; } = new List<DriverDto>();
}
