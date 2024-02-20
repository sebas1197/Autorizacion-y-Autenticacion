using appFGE.Models;
using appFGE.Repository;
using Microsoft.AspNetCore.Mvc;

namespace appFGE.Controllers
{
    [ApiController]
    [Route("api/assignments/")]
    public class AssignmentController : ControllerBase
    {

        public readonly IAssignmentRepository _assignmentRepository;

        public AssignmentController(IAssignmentRepository assignmentRepository)
        {
            this._assignmentRepository = assignmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Assignment>>> GetAllAssignments()
        {
            try
            {
                return await _assignmentRepository.GetAllAssignments();
            }
            catch (Exception e) { 
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> CreateAssignment([FromBody] Assignment assignment)
        {
            try
            {
                await _assignmentRepository.CreateAssignment(assignment);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAssignment([FromBody] Assignment assignment, int id)
        {
            try
            {
                await _assignmentRepository.UpdateAssignment(assignment, id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPut("delete/{id}")]
        public async Task<ActionResult> DeleteAssignment(int id)
        {
            try
            {
                await _assignmentRepository.DeleteAssignment(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}
