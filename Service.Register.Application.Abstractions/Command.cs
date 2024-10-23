using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Register.Application.Abstractions
{
    public abstract class Command : Notifiable<Notification>
    {
        public abstract void Validate();
    }
}
