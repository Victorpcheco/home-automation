namespace HomeAutomation.Domain.Interfaces
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<IReadOnlyList<T>> ListarTodosAsync();
        Task<T> ObterPorIdAsync(int id);
        Task<T> AdicionarAsync(T entity);
        Task AtualizarAsync(T entity);
        Task RemoverAsync(T entity);
    }
}
