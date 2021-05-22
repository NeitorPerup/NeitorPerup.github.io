using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Aspnetcore_api.Models
{
    public class AnimalDTO
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UrlPath { get; set; } // путь до изображения
    }
}
