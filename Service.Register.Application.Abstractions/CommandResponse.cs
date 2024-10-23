using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Register.Application.Abstractions
{
    public class CommandResponse
    {
        public CommandResponse(string message, IReadOnlyCollection<Notification>? notifications = null)
        {
            Message = message;
            Notifications = notifications ?? [];
            IsValid = Notifications.Count == 0;
        }

        public CommandResponse(bool isValid, string message, IReadOnlyCollection<Notification>? notifications = null)
        {
            IsValid = isValid;
            Message = message;
            Notifications = notifications ?? [];
        }

        public string Message { get; private set; }
        public IReadOnlyCollection<Notification> Notifications { get; private set; }
        public bool IsValid { get; private set; }
    }

    public class CommandResponse<T> : CommandResponse
    {

        public CommandResponse(string message, IReadOnlyCollection<Notification>? notifications = null)
            : base(message, notifications)
        {
        }

        public CommandResponse(T data, string message, IReadOnlyCollection<Notification>? notifications = null)
            : base(message, notifications)
        {
            Data = data;
        }

        public CommandResponse(T data, bool isValid, string message, IReadOnlyCollection<Notification>? notifications = null)
            : base(isValid, message, notifications)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }

    public static class CommandResponseFactory
    {
        public static CommandResponse<T> Success<T>(T data, string message = "Operation succeeded")
        {
            return new CommandResponse<T>(data, message);
        }

        public static CommandResponse<T> Failure<T>(IReadOnlyCollection<Notification> notifications, string message = "Operation failed")
        {
            return new CommandResponse<T>(default, false, message, notifications);
        }

        public static CommandResponse<T> Failure<T>(string message)
        {
            return new CommandResponse<T>(default, false, message);
        }

        public static CommandResponse Failure(IReadOnlyCollection<Notification> notifications, string message = "Operation failed")
        {
            return new CommandResponse(false, message, notifications);
        }

        public static CommandResponse Failure(string message)
        {
            return new CommandResponse(false, message);
        }
    }


}
