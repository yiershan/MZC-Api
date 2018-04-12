using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MZC.Blog.Notes
{
    /// <summary>
    /// 创建的时候不需要太多信息，内容更新主要依靠update
    /// 在用户点击创建的时候数据库便创建数据，在用户编辑过程中自动更新保存数据。
    /// </summary>
    public class CreateNoteDto
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public long CreatorUserId { get; set; }
        /// <summary>
        /// 内容的数据类型 markdown内容，html内容，或者其他
        /// </summary>
        public int TextType { get; set; }

    }
    /// <summary>
    /// 自动更新所传的数据
    /// </summary>
    public class UpdateNoteDto : EntityDto<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
    /// <summary>
    /// 发布更新时所用
    /// </summary>
    public class PublicNoteDto : UpdateNoteDto, ICustomValidate
    {
        /// <summary>
        /// 简单描述，用于微信推送时的描述或者其他
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 封面图片，可用于微信推送时或者其他
        /// </summary>
        [Required]
        public string Img { get; set; }
        /// <summary>
        /// 关键字，可用于搜索，分类等
        /// </summary>
        public string Tags { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrEmpty(Des))
            {
                string error = "描述不能为空！";
                context.Results.Add(new ValidationResult(error));
            }
            if (Des.Length < 10)
            {
                string error = "描述不能少于10个字！";
                context.Results.Add(new ValidationResult(error));
            }
            if (Des.Length > 200)
            {
                string error = "描述不能大于200个字！";
                context.Results.Add(new ValidationResult(error));
            }
        }
    }
    /// <summary>
    /// 用于列表展示
    /// </summary>
    public class NoteDto : EntityDto<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreationTime { get; set; }
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
        /// 是否发布
        /// </summary>
        public bool IsPublic { get; set; }
    }

    public class GetNoteListDto: PagedResultRequestDto
    {
        /// <summary>
        /// 用于搜索的关键字
        /// </summary>
        public string key { get; set; }
    }

    #region 前台调用的
    /// <summary>
    /// 带有较短内容的dto
    /// </summary>
    public class NoteOfPreDto : NoteDto
    {
        /// <summary>
        /// 较短的内容，暂时取前5行，
        /// </summary>
        public string Content { get; set; }
    }
    /// <summary>
    /// 有详细内容的dto
    /// </summary>
    public class NoteAllDto: NoteDto
    {
        /// <summary>
        /// 全部内容
        /// </summary>
        public string Content { get; set; }
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
        /// 被哪些文集收集
        /// </summary>
        public List<string> NoteBookNames{ get; set; }
}
    #endregion

    #region 文集相关
    public class CreateNoteBookeDto: EntityDto<int>,IShouldNormalize
    {
        /// <summary>
        /// 专辑名称
        /// </summary>
        [Required]
        [MaxLength(12)]
        public string Name { get; set; }
        /// <summary>
        /// 专辑描述
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 专辑封面
        /// </summary>
        public string Img { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Des)) Des = "这个人太懒了，什么也没有写。";
        }
    }
    public class NoteBookDto : EntityDto<int>
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
    }
    public class NoteToNoteBookDto {
        /// <summary>
        /// 加入或者移除
        /// </summary>
        public bool IsAdd { get; set; }
        /// <summary>
        /// 文章的id
        /// </summary>
        public int NoteId { get; set; }
        /// <summary>
        /// 专辑id
        /// </summary>
        public int NoteBookId { get; set; }

    }

    #endregion
}
