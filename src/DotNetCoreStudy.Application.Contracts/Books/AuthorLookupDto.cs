using System;
using Volo.Abp.Application.Dtos;

namespace DotNetCoreStudy.Books
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
