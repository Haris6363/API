using AspNetCore.Identity.LiteDB.Data;
using Assignment.Models;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using Assignment.Middleware;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AlertsController : ControllerBase
    {

        private readonly ILogger<Alert_Model> _logger;
        private readonly ILiteDbAlertModelService _ModelService;
        

        public AlertsController(ILogger<Alert_Model> logger,ILiteDbAlertModelService alertModelDbService)
        {
            _logger = logger;
            _ModelService = alertModelDbService;
          
        }

        /// <summary>
        /// Get all Alerts Services
        /// </summary>
        /// <returns></returns>
        ///<response code="200">Get all Alerts Services</response>
        ///<response code="404"> Alerts Services Not Found</response>

        // GET: api/<AlertsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult< IEnumerable<Alert_Model>> Get()
        {
            
            var result = _ModelService.FindAll();
            return Ok(result);
          if(_ModelService.FindAll() == null)
            {
                return NotFound();
               
            }
        

        }

        /// <summary>
        /// Returns the Specific Alert
        /// </summary>
        /// <param name="id">Input the id to get Specific Alert</param>
        /// <returns> Get Specific Alert</returns>
        /// <remarks>
        /// Sample Request
        /// 
        /// id:1
        /// </remarks>
        ///<response code="200">Specific Alert is found</response>
        ///<response code="404">Specific Alert is not found</response>

        // GET api/<AlertsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Alert_Model> Get(int id)
        {
            
                var result = _ModelService.GetOne(id);
            if (result != default)
                return Ok(_ModelService.GetOne(id));
            else

                return NotFound();
          
            

        }

        /// <summary>
        /// Add another Alert 
        /// </summary>
        /// <param name="model">Enter the alert values and the Alert is added</param>
        /// <returns>A newly created Alert</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        /// {
        /// 
        /// "id":2,
        /// 
        /// "Message": Development,
        /// 
        /// "createdAt": 10/06/2024
        /// 
        /// }
        /// </remarks>
        ///<response code="200">Alert Created</response>
        ///
        ///<response code="404">Not Found</response>

        // POST api/<AlertsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Alert_Model> Post([FromBody] Alert_Model model)
        {
            _logger.LogWarning("The details of Alerts does not input by the user");
           var result= _ModelService.Insert(model);
            return Ok(result);
           
          if(result.Equals(null))
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Update the Existing Alert
        /// </summary>
        /// <param name="id">Input the id which you want to update</param>
        /// <param name="model">Enter the id to update specific Alert</param>
        /// <remarks>
        /// Sample Request:
        /// 
        /// {
        /// 
        /// "id": 2
        /// 
        /// }
        /// </remarks>
        /// <response code="200"> Given id object is not found</response>
        /// <response code="404"> Given id object is not found</response>
        /// <returns>Update the existing Alert</returns>

        // PUT api/<AlertsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Alert_Model> Put(int id, [FromBody]  Alert_Model model)
        {
          var result= _ModelService.Update(model);
            if (result)
            {
                return Ok(result);
            }
           else
            {
                return NotFound();    
            }

        }


        /// <summary>
        /// Delete the specific Alert
        /// </summary>
        /// <param name="id">Input the id to delete specific Alert</param>
        /// <remarks>
        /// Sample Request:
        /// 
        /// {
        /// 
        /// "id": 2
        /// 
        /// }
        /// </remarks>
        /// <response code="200">Alert Deleted</response>
        /// <response code="404">Alert Not Found</response>
        /// <returns>Alert id Deleted</returns>

        // DELETE api/<AlertsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Alert_Model> Delete(int id)
        {
           
          var result= _ModelService.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
             
            

        }
    }
}
