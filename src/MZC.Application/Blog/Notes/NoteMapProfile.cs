using AutoMapper;
using AutoMapper.XpressionMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MZC.Blog.Notes
{
    public class NoteMapProfile : Profile
    {
        public NoteMapProfile()
        {
            CreateMap<CreateNoteDto, Note>().AfterMap((s,d,c)=> {
                d.CreationTime = DateTime.Now;
                d.Title = "文章无标题";
                d.Content = "还没有写文章内容呢";
            });
            CreateMap<UpdateNoteDto, Note>();
            CreateMap<PublicNoteDto, Note>().AfterMap((s, d, c) => {
                d.IsPublic = true;
                d.LastModificationTime = DateTime.Now;
            }); 
            //使用自定义解析
            CreateMap<Note, NoteDto>().ForMember(x=>x.CreationTime,opt=> {
                opt.ResolveUsing<NoteToNoteDtoResolver>();
            });
            CreateMap<Note, PublicNoteDto>();
            CreateMap<Note, NoteAllDto>().AfterMap((s, d, c) => {
                d.CreationTime = string.Format("{0:D}", s.CreationTime);
            });
            CreateMap<Note, NoteOfPreDto>().AfterMap((s, d, c) => {
                d.Content =s.Content.Length>200? s.Content.Substring(0, 200):s.Content;
                d.CreationTime = string.Format("{0:D}", s.CreationTime);
            });
            CreateMap<CreateNoteBookeDto, NoteBook>();
            CreateMap<NoteBook, NoteBookDto>();
        }
    }
    /// <summary>
    /// 自定义解析
    /// </summary>
    public class NoteToNoteDtoResolver : IValueResolver<Note, NoteDto, string>
    {
        public string Resolve(Note source, NoteDto destination, string destMember, ResolutionContext context)
        {
            return  string.Format("{0:D}", source.CreationTime);
        }
    }
}
