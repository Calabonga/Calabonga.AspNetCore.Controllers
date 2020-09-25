using System.Collections.Generic;
using AutoMapper;
using Calabonga.AspNetCore.Controllers.Demo.Entities;
using Calabonga.AspNetCore.Controllers.Demo.ViewModels;
using Calabonga.UnitOfWork;

namespace Calabonga.AspNetCore.Controllers.Demo.Mappers
{
    public class PersonMapperConfiguration : Profile
    {
        public PersonMapperConfiguration()
        {
            CreateMap<Person, PersonUpdateViewModel>().ReverseMap();
            CreateMap<PersonCreateViewModel, Person>();
            CreateMap<Person, PersonViewModel>();
            CreateMap<Address, AddressViewModel>();

            CreateMap<IPagedList<Person>, IPagedList<PersonViewModel>>()
                .ConvertUsing<PagedListConverter<Person, PersonViewModel>>();
        }
    }

    /// <summary>
    /// Generic converter for IPagedList collections
    /// </summary>
    /// <typeparam name="TMapFrom"></typeparam>
    /// <typeparam name="TMapTo"></typeparam>
    public class PagedListConverter<TMapFrom, TMapTo> : ITypeConverter<IPagedList<TMapFrom>, IPagedList<TMapTo>>
    {

        /// <summary>Performs conversion from source to destination type</summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="context">Resolution context</param>
        /// <returns>Destination object</returns>
        public IPagedList<TMapTo> Convert(IPagedList<TMapFrom> source, IPagedList<TMapTo> destination, ResolutionContext context)
        {
            if (source == null) return null;
            var pagedList = PagedList.From(source, (con) => context.Mapper.Map<IEnumerable<TMapTo>>(con));
            return pagedList;
        }
    }
}
