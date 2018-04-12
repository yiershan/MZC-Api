using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MZC.Blog.Notes
{
    /// <summary>
    /// 专辑和文章对应关系
    /// </summary>
    public class NoteToNoteBook : Entity, IHasCreationTime, ICreationAudited
    {
        /// <summary>
        /// 文章的id
        /// </summary>
        public int NoteId { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        [ForeignKey("NoteId")]
        public Note Note { get; set; }
        /// <summary>
        /// 专辑id
        /// </summary>
        public int NoteBookId { get; set; }
        /// <summary>
        /// 专辑内容
        /// </summary>
        [ForeignKey("NoteBookId")]
        public NoteBook NoteBook { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreatorUserId { get; set; }
    }
}
