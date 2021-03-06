using Core.Entities;
using Core.Queries;

namespace DAL.Queries.GetTeacherById
{
    public class GetTeacherByIdQuery : IQuery<Teacher>
    {
        public GetTeacherByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
