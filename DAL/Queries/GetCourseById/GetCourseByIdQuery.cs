using Core.Entities;
using Core.Queries;

namespace DAL.Queries.GetCourseById
{
    public class GetCourseByIdQuery : IQuery<Course>
    {
        public GetCourseByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
