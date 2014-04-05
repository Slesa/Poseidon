namespace StateBasedNavigation.Infrastructure
{
  public interface IOperationResult<T> : IOperationResult
  {
      T Result { get; }
  }
}