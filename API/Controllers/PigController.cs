using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Persistance.Interfaces;

namespace API.Controllers
{
    public class PigController : BaseController
    {
        private readonly IPigService _service;

        public PigController(IPigService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route(nameof(GetAllPigs))]
        public async Task<ActionResult> GetAllPigs()
        {
            var pigs = await _service.GetAllPigs();
            return Ok(pigs);
        }

        [HttpGet]
        [Route(nameof(GetPigById))]
        public async Task<ActionResult> GetPigById(int pigId)
        {
            var pig = await _service.GetPigById(pigId);
            return Ok(pig);
        }

        [HttpPost]
        [Route(nameof(AddPig))]
        public async Task<ActionResult> AddPig(int pigId, float fatLength)
        {
            await _service.AddPig(new Pig() { PigId = pigId, FatLength = fatLength });
            return Ok();
        }

        [HttpPut]
        [Route(nameof(UpdatePig))]
        public async Task<ActionResult> UpdatePig(int pigId, float fatLength)
        {
            await _service.UpdatePig(new Pig() { PigId = pigId, FatLength = fatLength });
            return Ok();
        }

        [HttpDelete]
        [Route(nameof(DeletePig))]
        public async Task<ActionResult> DeletePig(int pigId)
        {
            await _service.DeletePig(pigId);
            return Ok();
        }
    }
}