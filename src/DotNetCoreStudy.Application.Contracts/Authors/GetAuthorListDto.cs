using Volo.Abp.Application.Dtos;

namespace DotNetCoreStudy.Authors
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
