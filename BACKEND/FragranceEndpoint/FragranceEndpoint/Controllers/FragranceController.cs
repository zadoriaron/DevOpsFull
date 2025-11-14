using Fragrance_Data.Dto;
using Fragrance_Data.Models;
using Fragrance_Data;
using Microsoft.AspNetCore.Mvc;
namespace DevOpsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FragranceController : ControllerBase
    {
        FragranceRepository repo;

        public FragranceController(FragranceRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost("AddFragfrance")]
        public void AddFragrance([FromBody] FragranceCreateDto dto)
        {
            FragranceModel model = new FragranceModel()
            {
                Name = dto.Name,
                Brand = dto.Brand,
                Price = dto.Price,
                PictureUrl = dto.PictureUrl
            };

            repo.Create(model);
        }

        [HttpGet("GetFragrances")]
        public IEnumerable<FragranceModel> GetFragrances()
        {
            return repo.GetAll().ToList();
        }

        [HttpDelete]
        public void DeleteFragrance([FromBody] string id)
        {
            repo.Delete(id);
        }
    }
}
