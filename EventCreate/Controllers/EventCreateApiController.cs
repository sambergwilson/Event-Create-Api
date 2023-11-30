using EventCreate.ViewModels;
using EventCreateDataAccess.Models;
using EventCreateDataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventCreate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCreateApiController : ControllerBase
    {
        private readonly EventCreateRepository _repo;

        public EventCreateApiController()
        {
            _repo = new EventCreateRepository();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody]CreateEventViewModel model)
        {   
            var created = new EventCreateModel
            {
                EventName = model.EventName, 
                EventDescription = model.EventDescription
            };

            var result = await _repo.CreateAsync(created);

            var viewModel = new CreateEventViewModel
            {
                EventName = result.EventName,
                EventDescription = result.EventDescription
            };

            return Ok(viewModel);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEventAsync(int Id)
        {
            await _repo.DeleteAsync(Id);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var result = await _repo.GetAllAsync();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEventById(UpdateEventViewModel model)
        {
            var events = new EventCreateModel
            {
                Id = model.Id,
                EventName = model.EventName, 
                EventDescription = model.EventDescription
            };

            var result = await _repo.UpdateAsync(events);

            var response = new UpdateEventViewModel
            {
                Id = result.Id,
                EventName = result.EventName,
                EventDescription = result.EventDescription
            };

            return Ok(response);
        }
    }
}
