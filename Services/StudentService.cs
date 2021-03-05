using Core.Entities;
using Core.Queries;
using DAL.Queries.GetAllStudents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class StudentService
    {
        private readonly IQueryHandler<GetAllStudentsQuery, IList<Student>> _getAllStudetsQueryHandler;

        public StudentService(IQueryHandler<GetAllStudentsQuery, IList<Student>> getAllStudetsQueryHandler)
        {
            this._getAllStudetsQueryHandler = getAllStudetsQueryHandler;
        }

        public async Task<IList<Student>> GetAllStudents()
        {
            return await this._getAllStudetsQueryHandler.HandleAsync(new GetAllStudentsQuery());
        }
    }
}
