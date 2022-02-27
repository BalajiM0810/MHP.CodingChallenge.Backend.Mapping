using AutoMapper;
using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using MHP.CodingChallenge.Backend.Mapping.Data.DB.Blocks;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHP.CodingChallenge.Backend.Mapping.Data
{
    public class ArticleAutoMapper : Profile
    {
        public ArticleAutoMapper()
        {
            CreateMap<ArticleBlock, ArticleBlockDto>().IncludeAllDerived().ReverseMap();
            CreateMap<GalleryBlock, GalleryBlockDto>().ReverseMap();
            CreateMap<ImageBlock, ImageBlockDto>().ReverseMap();
            CreateMap<TextBlock, TextBlockDto>().ReverseMap();
            CreateMap<VideoBlock, VideoBlockDto>().ReverseMap();
            CreateMap<ImageSize, ImageSizeDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Article, ArticleDto>().
                ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id)).
                ForMember(dst => dst.Blocks, opt => opt.MapFrom(src => src.Blocks.OrderBy(p => p.SortIndex))).
              // ForMember(dst => dst.Blocks, opt => opt.UseDestinationValue()).ReverseMap();
              IncludeAllDerived().ReverseMap();
        }
    }
}
