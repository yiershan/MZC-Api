using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.Application.Services;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MZC.Blog.Notes
{
    public class NoteServer : ApplicationService, INoteServer
    {
        private IRepository<Note> Repository;
        public NoteServer(IRepository<Note> repository)
        {
            this.Repository = repository;
        }
        public async Task<NoteAllDto> GetNote(EntityDto<int> input)
        {
            var note = await Repository.GetAsync(input.Id);
            note.Scan++;
            Repository.UpdateAsync(note);
            return ObjectMapper.Map<NoteAllDto>(note);
        }

        public async Task<PagedResultDto<NoteDto>> GetNoteList(GetNoteListDto input)
        {
            var data = GetAll();
            data = data.WhereIf(!string.IsNullOrEmpty(input.key), m => m.Title.Contains(input.key) || m.Tags.Contains(input.key));
            int count = await data.CountAsync();
            var notes = await data.OrderByDescending(q => q.Scan)
                            .PageBy(input)
                            .ToListAsync();
            return new PagedResultDto<NoteDto>()
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<NoteDto>>(notes)
            };
        }

        public async Task<PagedResultDto<NoteOfPreDto>> GetPreNoteList(GetNoteListDto input)
        {
            var data = GetAll();
            data = data.WhereIf(!string.IsNullOrEmpty(input.key), m => m.Title.Contains(input.key) || m.Tags.Contains(input.key));
            int count = await data.CountAsync();
            var notes = await data.OrderByDescending(q => q.CreationTime)
                            .PageBy(input)
                            .ToListAsync();
            return new PagedResultDto<NoteOfPreDto>()
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<NoteOfPreDto>>(notes)
            };
        }

        public void Like(EntityDto<int> input)
        {
            var note = Repository.Get(input.Id);
            note.Like += 1;
            Repository.Update(note);
        }
        public void UnLike(EntityDto<int> input)
        {
            var note = Repository.Get(input.Id);
            note.Like --;
            Repository.Update(note);
        }

        /// <summary>
        /// 要过滤掉删除和未发布的
        /// </summary>
        /// <returns></returns>
        protected IQueryable<Note> GetAll()
        {
            return Repository.GetAll().Where(m => m.IsPublic &&! m.IsDeleted);
        }
    }
}
