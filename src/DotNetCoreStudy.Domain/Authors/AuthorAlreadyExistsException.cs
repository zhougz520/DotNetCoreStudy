using Volo.Abp;

namespace DotNetCoreStudy.Authors
{
    public class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
        : base(DotNetCoreStudyDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
