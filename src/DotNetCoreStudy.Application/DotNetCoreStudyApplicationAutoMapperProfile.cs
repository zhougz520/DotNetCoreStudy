using AutoMapper;
using DotNetCoreStudy.Authors;
using DotNetCoreStudy.Books;

namespace DotNetCoreStudy;

public class DotNetCoreStudyApplicationAutoMapperProfile : Profile
{
    public DotNetCoreStudyApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();
    }
}
