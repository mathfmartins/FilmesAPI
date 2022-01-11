using AutoMapper;
using FilmesAPI.Dto;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
