
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using datingapp.API.Data;
using datingapp.API.Dtos;
using datingapp.API.Helpers;
using datingapp.API.Models;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;

namespace datingapp.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/user/{userId}/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
         public TasksController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
         
        [HttpGet("{id}", Name = "GetTask")]
        public async Task<IActionResult> GetTask(int id)
        {
            
            var taskFromRepo = await _repo.GetTask(id);

            if(taskFromRepo == null)
                    return NotFound();

            return Ok(taskFromRepo);                
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _repo.GetTasks();

            return Ok(tasks);   
        }  
       
         [HttpPost]
        public async Task<IActionResult> CreateTask(int userId,TaskToCreate taskToCreate)
        {
            var sender = await _repo.GetUser(userId);

            if(sender.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    return Unauthorized();

            taskToCreate.UserWhoCreate = userId;  
 

            var task = _mapper.Map<Tasks>(taskToCreate);   

            _repo.Add(task);

            if (await _repo.SaveALL()){
                return Ok();
            }

             throw new System.Exception("Creating the task failed on save");            
        }
        //UPDATE
         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskToUpdate taskToUpdate){
             
            
            var taskFromRepo = await _repo.GetTask(id);

            _mapper.Map(taskToUpdate, taskFromRepo);

            if(await _repo.SaveALL())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save" );    
        }

          // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskDetail(int id, int userId)
        {
             if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();  

             var taskDetail = await _repo.GetTask(id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            _repo.Delete(taskDetail);
                if (await _repo.SaveALL())
                return NoContent();

            throw new Exception("Error deleting the message");
 
        }

         [HttpPost(Name = nameof(CreateComment))]
        public async Task<IActionResult> CreateComment(int userId,Comments commToCreate)
        {
            var sender = await _repo.GetUser(userId);

            if(sender.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    return Unauthorized();

            commToCreate.UserId = userId;  
 

            var comm = _mapper.Map<Comments>(commToCreate);   

            _repo.Add(comm);

            if (await _repo.SaveALL()){
                return Ok();
            }

             throw new System.Exception("Creating the comment failed on save");            
        }
    }
}