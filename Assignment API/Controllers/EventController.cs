using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using System.Collections.ObjectModel;
using log4net.Repository.Hierarchy;
using Swashbuckle.AspNetCore.Annotations;
using Assignment.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EventController : ControllerBase
    {
        public ILiteEventModelService _ModelService;
        private readonly ILogger _logger;
        public EventController(ILiteEventModelService ModelService, ILogger<Event_Model> logger) 
        { 
            _ModelService = ModelService;
            _logger= logger;    

        }   
        
        

        // GET: api/<EventController>
        [HttpGet]
        [SwaggerOperation(Summary = "Get All Events", Description = "Execute the Endpoint", OperationId = "Get All Events Services")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfull", typeof(Event_Model))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found")]
        public ActionResult <IEnumerable<IActionResult>> Get()
        {
            var Result=_ModelService.FindAll();
             return Ok(Result);
            
           
        }

        
        // GET api/<EventController>/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get an Event", Description = "Input the id to get specific Event", OperationId = "Get an Event")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Specific Event", typeof(Event_Model))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Event is not Found")]
        public IActionResult Get(int id)
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


       

        // POST api/<EventController>
        [HttpPost]
        [SwaggerOperation(Summary = "Insert the new Event", Description = "Input the values of id and Message to insert new Event", OperationId = "Event is added")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event is added", typeof(Event_Model))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Event is not added")]
        public IActionResult Post([FromBody] Event_Model model)
        {
           var result= _ModelService.insert(model);
            return Ok(result);
          
        }


       
        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update the existing Event", Description = "To input the id and update the id and Message", OperationId = "Event is Updated")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event is Updated", typeof(Event_Model))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Event is not Updated")]
        public IActionResult Put(int id, [FromBody] Event_Model model)
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

       


        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete the Event", Description = "To input the id and if id is found, the Event will be deleted", OperationId = "Event is Deleted")]
        [SwaggerResponse(StatusCodes.Status200OK, "Event is Deleted", typeof(Event_Model))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Event  is not Deleted")]
        public IActionResult Delete(int id)
        {
           var result= _ModelService.delete(id ); 
            return Ok();
           
        }
    }
}
