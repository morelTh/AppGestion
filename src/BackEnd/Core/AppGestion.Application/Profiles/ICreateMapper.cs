﻿using AutoMapper;

namespace AppGestion.Application.Profiles;

public interface ICreateMapper<TSource>
{
    void Map(Profile profile)
    {
        profile.CreateMap(typeof(TSource), GetType()).ReverseMap();
    }
}