namespace HotelManagment.Core.Entities;

public abstract class ResultBase
{
  public List<string> Errors { get; } = null!;
  public bool IsSucceeded { get; } = true;
  
  internal ResultBase(IEnumerable<string> errors)
  {
    IsSucceeded = false;
    Errors = errors.ToList();
  }
  
  internal ResultBase() { }
}
public class Result : ResultBase
{
  private static readonly Result SucceededTemplate;
  
  static Result()
  {
    SucceededTemplate = new Result();
  }

  internal Result(IEnumerable<string> errors) : base(errors) { }
  internal Result() { }

  public static Result Succeeded()
  {
    return SucceededTemplate;
  }

  public static Result Failure(IEnumerable<string> errors)
  {
    return new Result(errors);
  }

  public static Result Failure(params string[] errors)
  {
    return new Result(errors);
  }
}

public class Result<T> : ResultBase
{
  public T Data { get; } = default!;
  
  internal Result(IEnumerable<string> errors) : base(errors) { }

  internal Result(T data)
  {
    Data = data;
  }

  public static Result<T> Succeeded(T data)
  {
    return new Result<T>(data);
  }
  
  public static Result<T> Failure(IEnumerable<string> errors)
  {
    return new Result<T>(errors);
  }

  public static Result<T> Failure(params string[] errors)
  {
    return new Result<T>(errors);
  }
}