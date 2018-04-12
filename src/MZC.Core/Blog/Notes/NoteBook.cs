using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;

namespace MZC.Blog.Notes
{
    /// <summary>
    /// 文章专辑
    /// </summary>
    public class NoteBook : Entity, IHasCreationTime, IHasDeletionTime, IHasModificationTime, ICreationAudited
    {
        /// <summary>
        /// 专辑名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 专辑描述
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 专辑封面
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 专辑创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 专辑删除时间
        /// </summary>
        public DateTime? DeletionTime { get; set; }
        /// <summary>
        /// 专辑是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 专辑最后修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 专辑创建人
        /// </summary>
        public long? CreatorUserId { get; set; }
    }
}
