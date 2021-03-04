using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Queries
{
    public class GetAllStudetsQuery
    {
        private readonly GradeRContext _context;

        public GetAllStudetsQuery(GradeRContext context)
        {
            _context = context;
        }

        public async Task<IList<Student>> Execute()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }
    }
}
