namespace Notes.Domain
{
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
