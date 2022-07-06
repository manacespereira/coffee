using Coffee.Domain.AggregatesModel.TodoAggregates;
using Coffee.Domain.Core;

namespace Coffee.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public TodoRepository(TodoContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Todo todo)
    {
        await _context.Todos.AddAsync(todo);
    }

    public async Task<Todo> GetByTitleAsync(string title)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Title == title);

        if (todo == null)
        {
            todo = _context
                .Todos
                .Local
                .FirstOrDefault(t => t.Title == title);
        }

        return todo;
    }

    public async Task<IEnumerable<Todo>> GetAsync() => await _context.Todos.ToListAsync();
}