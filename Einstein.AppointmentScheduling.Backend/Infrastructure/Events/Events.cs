using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Events
{
    public class Events
    {
        #region System 0 to 100
        public static readonly Event SYSTEM_ERROR_NOT_HANDLED = new Event(0, nameof(SYSTEM_ERROR_NOT_HANDLED), "Não foi possível processar a requisição.");
        public static readonly Event SYSTEM_INVALID_DATA = new Event(1, nameof(SYSTEM_INVALID_DATA), "Dados inválidos");
        #endregion
    }

    public struct Event
    {
        public int Code { get; }
        public string Name { get; }
        public string Message { get; }

        public Event(int errorCode, string name, string Message)
        {
            this.Code = errorCode;
            this.Name = name;
            this.Message = Message;
        }
    }
}
