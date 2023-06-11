using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Models;
using NewsApi.Services;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {


        IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementsController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }



        /// <summary>
        ///     The get function for getting announcements
        /// </summary>
        /// <returns> The list of announcements </returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var announcements = await _announcementCollectionService.GetAll();
            if (announcements == null)
            {
                return NotFound();
            }
            return Ok(announcements);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetAnnouncementById(Guid id)
        {
            var announcement = await _announcementCollectionService.Get(id);

            if (announcement == null)
            {
                return NotFound();
            }

            return Ok(announcement);
        }
     /// <summary>
     /// 
     /// </summary>
     /// <param name="categoryId"></param>
     /// <returns></returns>
        [HttpGet("getByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetAnnouncementsByCategoryId(string categoryId)
        {
            var announcements = await _announcementCollectionService.GetAnnouncementsByCategoryId(categoryId);

            return Ok(announcements);
        }

        /// <summary>
        ///     Add a new Announcement
        /// </summary>
        /// <param name="announcement"> The announcement to add </param>
        /// <returns> The success of the addition </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Announcement announcement)
        {
            var result = await _announcementCollectionService.Create(announcement);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        /// <summary>
        ///     The put function for updating the announcement by its id
        /// </summary>
        /// <param name="announcement"> The information that you want to provide. The id should be the id of the announcement you want to reference </param>
        /// <returns> The updated announcement </returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Announcement announcement)
        {
            var result = await _announcementCollectionService.Update(announcement.Id, announcement);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(Guid id)
        {
            var isDeleted = await _announcementCollectionService.Delete(id);
            if (!isDeleted)
            {
                return NotFound("Announcement was not found");
            }
            return Ok();
        }
    }
}
