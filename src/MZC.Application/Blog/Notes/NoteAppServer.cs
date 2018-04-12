using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MZC.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZC.Blog.Notes
{
    [AbpAuthorize(PermissionNames.Pages_Blogs_Notes)]
    public class NoteAppServer : AsyncCrudAppService<Note, NoteDto, int, GetNoteListDto, CreateNoteDto, UpdateNoteDto>, INoteAppServer
    {
        private IRepository<NoteBook> BookRepository;
        private IRepository<NoteToNoteBook> NoteToBookRepository;

        public NoteAppServer(IRepository<Note> repository,
            IRepository<NoteToNoteBook> noteToBookRepository,
            IRepository<NoteBook> bookRepository
            )
            : base(repository)
        {
            this.BookRepository = bookRepository;
            this.NoteToBookRepository = noteToBookRepository;
        }

        public override async Task<NoteDto> Create(CreateNoteDto input)
        {
            var note = ObjectMapper.Map<Note>(input);
            var id = await Repository.InsertAndGetIdAsync(note);
            var result = Repository.Get(id);
            return ObjectMapper.Map<NoteDto>(result);
        }

        public async Task PublicNote(PublicNoteDto input)
        {
            var note = Repository.Get(input.Id);
            ObjectMapper.Map(input,note);
            var result = await Repository.UpdateAsync(note);
        }

        public override async Task<NoteDto> Update(UpdateNoteDto input)
        {
            var note = Repository.Get(input.Id);
            ObjectMapper.Map(input,note);
            var result = await Repository.UpdateAsync(note);
            return ObjectMapper.Map<NoteDto>(result);
        }
        public override async Task<PagedResultDto<NoteDto>> GetAll(GetNoteListDto input)
        {
            var data = Repository.GetAll().Where(m => !m.IsDeleted);
            data = data.WhereIf(!string.IsNullOrEmpty(input.key), m => m.Title.Contains(input.key) || m.Tags.Contains(input.key));
            int count = await data.CountAsync();
            var notes = await data.OrderByDescending(q => q.CreationTime)
                            .PageBy(input)
                            .ToListAsync();
            return new PagedResultDto<NoteDto>()
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<NoteDto>>(notes)
            };
        }

        public async Task<PublicNoteDto> GetNote(EntityDto<int> input)
        {
            var note = await Repository.GetAsync(input.Id);
            return ObjectMapper.Map<PublicNoteDto>(note);
        }

        public async Task<List<NoteBookDto>> GetNoteBookeList()
        {
            var data =await BookRepository.GetAll().Where(m => !m.IsDeleted).ToListAsync();
            return ObjectMapper.Map<List<NoteBookDto>>(data);

        }

        public async Task CreateOrUpdateNoteBook(CreateNoteBookeDto input)
        {
            var book = ObjectMapper.Map<NoteBook>(input);
            book.CreatorUserId = 0;
            book.CreationTime = DateTime.Now;
            await BookRepository.InsertOrUpdateAsync(book);
        }

        public async Task DeleteNoteBook(EntityDto<int> input)
        {
            //bool hasNote = await NoteToBookRepository.GetAll().Where(m => m.NoteBookId == input.Id).AnyAsync();
            //if (hasNote) throw new Exception("专辑内容不为空，不能删除");
            var book = await BookRepository.GetAsync(input.Id);
            book.IsDeleted = true;
            book.DeletionTime = DateTime.Now;
            await BookRepository.UpdateAsync(book);
        }

        public void AddToBook(NoteToNoteBookDto input)
        {
            if (input.IsAdd)
            {
                NoteToNoteBook data = new NoteToNoteBook
                {
                    CreatorUserId = this.AbpSession.UserId,
                    CreationTime = DateTime.Now,
                    NoteId = input.NoteId,
                    NoteBookId = input.NoteBookId
                };
                NoteToBookRepository.Insert(data);
            }
            else
            {
                NoteToBookRepository.Delete(m=>m.NoteId == input.NoteId&&m.NoteBookId==input.NoteBookId);
            }
        }
    }
}
