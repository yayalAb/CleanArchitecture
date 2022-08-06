using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Deriver.Queries.GetDrivers;
public class DriverDto: IMapFrom<Driver>
{
    public int Id { get; set; }
    public String Name { get; set; } = String.Empty;
    public String Email { get; set; } = String.Empty;
    public String Phone { get; set; } = String.Empty;
    public int Age { get; set; }
}
