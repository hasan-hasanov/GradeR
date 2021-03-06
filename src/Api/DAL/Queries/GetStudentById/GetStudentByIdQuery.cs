using Core.Entities;
using Core.Queries;

namespace DAL.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IQuery<Student>
    {
        public GetStudentByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
