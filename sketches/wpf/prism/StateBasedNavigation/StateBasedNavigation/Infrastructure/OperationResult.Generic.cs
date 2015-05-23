namespace StateBasedNavigation.Infrastructure
{
  public class OperationResult<T> : OperationResult, IOperationResult<T>
  {
      public T Result { get; protected internal set; }
  }
}