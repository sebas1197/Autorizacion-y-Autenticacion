using appFGE.Connections;
using appFGE.Repository;
using appFGE.Models;
using Microsoft.EntityFrameworkCore;

namespace appFGE.Services
{
    public class AssignmentService : IAssignmentRepository
    {
        private readonly ApplicationDbContext _context;
        //private readonly IMapper mapper;
        public AssignmentService(ApplicationDbContext context)
        {
            _context = context;
            //mapper = _mapper;
        }

        public async Task<List<Assignment>> GetAllAssignments()
        {
            try
            {
                return await _context.tb_fge_assignment.ToListAsync();
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
            
        }

        public async Task CreateAssignment(Assignment assignment)
        {
            try
            {
                _context.tb_fge_assignment.Add(assignment);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task UpdateAssignment(Assignment assignment, int asg_id)
        {
            try
            {
                if (_context.tb_fge_assignment.Find(asg_id) != null)
                {
                    _context.tb_fge_assignment.Update(assignment);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task DeleteAssignment(int asg_id)
        {
            try
            {
                var assignmentFound = _context.tb_fge_assignment.Find(asg_id);
                if (assignmentFound != null)
                {
                    assignmentFound.asg_status = false;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
