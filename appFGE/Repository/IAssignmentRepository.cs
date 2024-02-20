using appFGE.Models;

namespace appFGE.Repository
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAllAssignments();
        Task CreateAssignment(Assignment assignment);
        Task UpdateAssignment(Assignment assignment, int asg_id);
        Task DeleteAssignment(int asg_id);
    }
}