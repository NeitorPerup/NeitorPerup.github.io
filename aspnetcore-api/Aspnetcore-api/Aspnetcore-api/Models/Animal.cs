using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Aspnetcore_api.Models
{
    public class Animal
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UrlPath { get; set; } // путь до изображения

        public string Secret { get; set; }
    }
}
