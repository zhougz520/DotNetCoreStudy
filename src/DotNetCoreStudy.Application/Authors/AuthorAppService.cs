using DotNetCoreStudy.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Domain.Repositories;

namespace DotNetCoreStudy.Authors
{
    public class AuthorAppService : DotNetCoreStudyAppService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
        private readonly IDistributedCache<AuthorDto> _cache;
        private readonly IAbpDistributedLock _distributedLock;

        public AuthorAppService(
            IAuthorRepository authorRepository,
            AuthorManager authorManager,
            IDistributedCache<AuthorDto> cache,
            IAbpDistributedLock distributedLock)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
            _cache = cache;
            _distributedLock = distributedLock;
        }

        public async Task RedisDistributedLockTest()
        {
            // 定义一个List用来存放并发任务
            List<Task> tasks = new List<Task>();
            for (var i = 0; i < 20; i++)
            {
                // 将20个任务添加到List中等待并发执行
                tasks.Add(
                    Task.Run(async () =>
                    {
                        // 使用分布式锁_distributedLock.TryAcquireAsync来对金额进行增减操作
                        await using (
                        var handle = await _distributedLock.TryAcquireAsync(
                            "acc_000",
                            TimeSpan.FromSeconds(30)
                            )
                        )
                        {
                            if (handle != null)
                            {
                                int num = new Random().Next(1000);
                                Console.WriteLine($"-acc_{num}账户减少{num}元");
                                await Task.Delay(num);
                                Console.WriteLine($"+结算账户acc_001增加{num}元");
                            }
                        }
                    })
                    );
            }

            // 等待20个任务并发全部执行完毕
            await Task.WhenAll(tasks);

            Console.WriteLine("所有任务已执行完毕！！");
        }

        [Authorize(DotNetCoreStudyPermissions.Authors.Create)]
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            var author = await _authorManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.ShortBio
            );

            await _authorRepository.InsertAsync(author);

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        [Authorize(DotNetCoreStudyPermissions.Authors.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            return await _cache.GetOrAddAsync(
                    $"Author_{id}",
                    async () =>
                    {
                        Console.WriteLine("----------读取数据库----------");
                        var author = await _authorRepository.GetAsync(id);
                        return ObjectMapper.Map<Author, AuthorDto>(author);
                    }
                );
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Author.Name);
            }

            var authors = await _authorRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _authorRepository.CountAsync()
                : await _authorRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<AuthorDto>(
                totalCount,
                ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors)
            );
        }

        [Authorize(DotNetCoreStudyPermissions.Authors.Edit)]
        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            var author = await _authorRepository.GetAsync(id);

            if (author.Name != input.Name)
            {
                await _authorManager.ChangeNameAsync(author, input.Name);
            }

            author.BirthDate = input.BirthDate;
            author.ShortBio = input.ShortBio;

            await _authorRepository.UpdateAsync(author);
        }
    }
}
