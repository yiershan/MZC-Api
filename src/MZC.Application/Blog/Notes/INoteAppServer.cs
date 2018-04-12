using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MZC.Blog.Notes
{
    public interface INoteAppServer: IAsyncCrudAppService<NoteDto,int, GetNoteListDto, CreateNoteDto,UpdateNoteDto>
    {
        Task PublicNote(PublicNoteDto input);

        Task<PublicNoteDto> GetNote(EntityDto<int> input);

        /// <summary>
        /// 专辑列表，数据量少就不分页了
        /// </summary>
        /// <returns></returns>
        Task<List<NoteBookDto>> GetNoteBookeList();
        /// <summary>
        /// 创建或者更新专辑
        /// </summary>
        /// <returns></returns>
        Task CreateOrUpdateNoteBook(CreateNoteBookeDto input);
        /// <summary>
        /// 删除专辑
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteNoteBook(EntityDto<int> input);
        /// <summary>
        /// 加入专辑
        /// </summary>
        /// <returns></returns>
        void AddToBook(NoteToNoteBookDto input);

    }
}
