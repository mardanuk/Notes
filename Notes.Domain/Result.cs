namespace Notes.Domain
{
    /// <summary>
    /// Результат работы, по умолчанию Value=null, Status=Status.Ok
    /// </summary>
    /// <typeparam name="T">Тип результируещего объекта</typeparam>
    public class Result<T>
    {
        public T? Value { get; set; }
        public Status Status { get; set; }

        public Result()
        {
            Status = Status.Ok;
        }

    }
}
