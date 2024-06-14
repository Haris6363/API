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
using Swashbuckle.AspNetCore.Annotations;
using Assignment.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AlertsController : ControllerBase
    {

        private readonly ILogger<Alert_Model> _logger;
        private readonly ILiteDbAlertModelService _ModelService;
        

        public AlertsController(ILogger<Alert_Model> logger,ILiteDbAlertModelService alertModelDbService)
        {
            _logger = logger;
            _ModelService = alertModelDbService;
          
        }

       
        // GET: api/<AlertsController>
        [HttpGet]
        [SwaggerOperation(Summary ="Get All Alerts",Description ="Go for tryout and Execute",OperationId ="Get All Alerts Services")]
        [SwaggerResponse(StatusCodes.Status200OK,"Successfull",typeof(Alert_Model))]
        [SwaggerResponse(StatusCodes.Status404NotFound,"Not Found")]
        public ActionResult< IEnumerable<Alert_Model>> Get()
        {
            
            var result = _ModelService.FindAll();
            return Ok(result);
        

        }

        

        // GET api/<AlertsController>/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary ="Get an Alert", Description ="Input the id to get specific Alert",OperationId ="Get an alert")]
        [SwaggerResponse(StatusCodes.Status200OK,"Get Specific Alert",typeof (Alert_Model))]
        [SwaggerResponse(StatusCodes.Status404NotFound,"Alert is not Found")]
        public IActionResult Get(int id)
        {
            
                var result = _ModelService.GetOne(id);
            if (result != default)
                return Ok(result);
            else

                return NotFound();
          
            

        }


        // POST api/<AlertsController>
        [HttpPost]
        [SwaggerOperation(Summary = "Insert the new Alert", Description = "Input the values of id and Message to insert new Alert", OperationId = "Alert is added")]
        [SwaggerResponse(StatusCodes.Status200OK, "Alert is added", typeof(Alert_Model))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Alert is not added")]
        public IActionResult Post([FromBody] Alert_Model model)
        {
           var result= _ModelService.Insert(model);
            return Ok(result);
          
        }

        

        // PUT api/<AlertsController>/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update the existing Alert", Description = "To input the id and update the id and Message", OperationId = "Alert is Updated")]
        [SwaggerResponse(StatusCodes.Status200OK, "Alert is Updated", typeof(Alert_Model))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Alert is not Updated")]
        public IActionResult Put(int id, [FromBody]  Alert_Model model)
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


       

        // DELETE api/<AlertsController>/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete the Alert", Description = "To input the id and if id is found, the Alert will be deleted", OperationId = "Alert is Deleted")]
        [SwaggerResponse(StatusCodes.Status200OK, "Alert is Delted", typeof(Alert_Model))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Alert is not Deleted")]

        public IActionResult Delete(int id)
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
