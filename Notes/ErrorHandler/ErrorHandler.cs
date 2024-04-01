using Notes.Domain;

namespace Presentation.ErrorHandler
{
    public class ErrorHandler
    {
        public static string GetResultStatus(Status status, string objName)
        {
            return $"{GetResultStatus(status)} : {objName}";
        }
        public static string GetResultStatus(Status status)
        {
            if (status == Status.NullValue)
            {
                return "Null-значение";
            }
            else if (status == Status.NotFound)
            {
                return "Данный объект не найден";
            }
            else if (status == Status.NotValid)
            {
                return "Не валидное значение";
            }
            else if (status == Status.ExistingValue)
            {
                return "Данный объект существует";
            }
            else if (status == Status.Undefined)
            {
                return "Неопределенная ошибка";
            }
            else if (status == Status.Ok)
            {
                return "ОК";
            }
            else
            {
                return "Данный тип ошибки не обработан в ErrorHandler";
            }
        }
    }
}
