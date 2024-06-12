using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using System.Collections.ObjectModel;
using log4net.Repository.Hierarchy;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventController : ControllerBase
    {
        public ILiteEventModelService _ModelService;
        private readonly ILogger _logger;
        public EventController(ILiteEventModelService ModelService, ILogger<Event_Model> logger) 
        { 
            _ModelService = ModelService;
            _logger= logger;    

        }   
        
        /// <summary>
        /// Get All the Events 
        /// </summary>
        /// <response code="200"> Get all the Events</response>
        /// <response code="404">Events Not Found</response>
        /// <returns></returns>

        // GET: api/<EventController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult <IEnumerable<Event_Model>> Get()
        {
            var Result=_ModelService.FindAll();
             return Ok(Result);
            if (Result != _ModelService.FindAll())
            {
                return NotFound();
            }
           
        }

        /// <summary>
        /// Get Specific Events
        /// </summary>
        /// <param name="id">input the id and get the specific Event</param>
        /// <remarks>
        /// Request Model:
        /// 
        /// {
        /// 
        /// "id":4
        /// 
        /// }
        /// </remarks>
        /// <response code="404">Event is not found</response>
        /// <response code="200">Get Specific Event</response>
        /// <returns></returns>
        // GET api/<EventController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Event_Model> Get(int id)
        {
            var result= _ModelService.GetOne(id);
            if (result != default)
            {
                return Ok(_ModelService.GetOne(id));
            }
            else
            {
                return NotFound();
                
            }
           
        }


        /// <summary>
        /// Add an Event 
        /// </summary>
        /// <param name="model">Input the Event values and the Event has been added</param>
        /// <remarks>
        /// Request Model:
        /// 
        /// {
        /// 
        /// "id": 6,
        /// 
        /// "Message": "API",
        /// 
        /// "createdAt": "2024-06-10T12:02:46.251Z"
        /// 
        /// }
        /// </remarks>
        /// <returns> Event is added</returns>

        // POST api/<EventController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Event_Model> Post([FromBody] Event_Model model)
        {
           var result= _ModelService.insert(model);
            return Ok(result);
            if (result != _ModelService.insert(model))
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// To Update the Existing Event
        /// </summary>
        /// <param name="id">Input the id which you want to update</param>
        /// <param name="model">Update the values of Existing event</param>
        /// <remarks>
        /// Request Model:
        /// 
        /// {
        /// 
        /// "id":8
        /// 
        /// }
        /// </remarks>
        /// <returns> Event is Updated</returns>
        ///<response code= "200">Specific Event is Updated</response>
        ///<response code= "404">Specific Event is not Updated</response>
        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Event_Model> Put(int id, [FromBody] Event_Model model)
        {
          var result=_ModelService.update(model);
            if (result)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();  
            }

        }

        /// <summary>
        /// To Delete the specific Event
        /// </summary>
        /// <param name="id">Input the Event id which you want to delete</param>
        /// <remarks>
        /// Request Model
        /// {
        /// 
        /// "id"=4
        /// 
        ///  }
        /// </remarks>
        /// <returns>Specific Event is deleted</returns>
        /// <response code="200">Event Deleted</response>
        /// <response code="404">Event Deleted</response>


        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Event_Model> Delete(int id)
        {
           var result= _ModelService.delete(id ); 
            return Ok();
            if(result!= _ModelService.delete(id))
            {
                return NotFound();
            }
        }
    }
}
