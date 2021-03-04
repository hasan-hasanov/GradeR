using Core.Entities;
using DAL.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class StudentService
    {
        private readonly GetAllStudetsQuery getAllStudetsQuery;

        public StudentService(GetAllStudetsQuery getAllStudetsQuery)
        {
            this.getAllStudetsQuery = getAllStudetsQuery;
        }

        public async Task<IList<Student>> GetAllStudents()
        {
            return await this.getAllStudetsQuery.Execute();
        }
    }
}
