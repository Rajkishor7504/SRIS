using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;

namespace SRIS.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
