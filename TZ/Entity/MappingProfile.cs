using AutoMapper;
using System.Transactions;

namespace TZ.Entity
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Dadata.Model.Address, StandartData>();
		}
	}
}
