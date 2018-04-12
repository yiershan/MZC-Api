using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;

namespace MZC.Blog.Notes
{
    /// <summary>
    /// 文章信息
    /// </summary>
    public class Note : Entity, IHasCreationTime, IHasDeletionTime, IHasModificationTime, ICreationAudited
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeletionTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 上次修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreatorUserId { get; set; }
        /// <summary>
        /// 点赞次数
        /// </summary>
        public long Like { get; set; }
        /// <summary>
        /// 收藏次数
        /// </summary>
        public long Collect { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public long Scan { get; set; }
        /// <summary>
        /// 内容的数据类型 markdown内容，html内容，或者其他
        /// </summary>
        public int TextType { get; set; }
        /// <summary>
        /// 简单描述，用于微信推送时的描述或者其他
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 封面图片，可用于微信推送时或者其他
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 关键字，可用于搜索，分类等
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublic { get; set; }
    }
}
