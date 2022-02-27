using System;
using System.Collections.Generic;
using AutoMapper;
using MHP.CodingChallenge.Backend.Mapping.Data.DB;
using MHP.CodingChallenge.Backend.Mapping.Data.DTO;

namespace MHP.CodingChallenge.Backend.Mapping.Data
{
    public class ArticleService
    {
        private ArticleRepository _articleRepository;
        private IMapper _articleMapper;

        public ArticleService(ArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _articleMapper = mapper;
        }

        public List<ArticleDto> GetAll()
        {
            List<Article> articles = _articleRepository.GetAll();
            List<ArticleDto> result = _articleMapper.Map<List<ArticleDto>>(articles);
            return result;
        }

        public object GetById(long id)
        {
            Article article = _articleRepository.FindById(id);
            if (article != null)
            {
                return _articleMapper.Map<ArticleDto>(article);
            }
            return article;
        }

        public object Create(ArticleDto articleDto)
        {
            Article create = _articleMapper.Map<Article>(articleDto);
            _articleRepository.Create(create);
            return _articleMapper.Map<ArticleDto>(create);
        }
    }
}
