﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicMarket.API.DTOs
{
    public class MusicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ArtistDTO Artist { get; set; }
    }
}
