using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fragrance_Data.Dto
{
    public class FragranceCreateDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
