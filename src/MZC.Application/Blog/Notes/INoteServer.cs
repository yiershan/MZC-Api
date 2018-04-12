using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MZC.Blog.Notes
{
    /// <summary>
    /// 前台展示所用
    /// </summary>
    public interface INoteServer : IApplicationService
    {
        /// <summary>
        /// 喜欢+1
        /// </summary>
        /// <returns></returns>
        void Like(EntityDto<int> input);
        /// <summary>
        /// 获取文章详细信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<NoteAllDto> GetNote(EntityDto<int> input);
        /// <summary>
        /// 文章列表不含内容
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<NoteDto>> GetNoteList(GetNoteListDto input);
        /// <summary>
        /// 文章列表含有预览内容
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<NoteOfPreDto>> GetPreNoteList(GetNoteListDto input);
        
    }
}
