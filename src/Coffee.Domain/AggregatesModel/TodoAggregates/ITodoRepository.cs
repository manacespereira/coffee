namespace Coffee.Domain.AggregatesModel.TodoAggregates;

public interface ITodoRepository : IRepository<Todo>
{
    Task AddAsync(Todo todo);
    Task<Todo> GetByTitleAsync(string title);
    Task<IEnumerable<Todo>> GetAsync();
}