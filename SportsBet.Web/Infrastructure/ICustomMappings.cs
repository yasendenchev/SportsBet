﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsBet.Infrastructure
{
    public interface ICustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}