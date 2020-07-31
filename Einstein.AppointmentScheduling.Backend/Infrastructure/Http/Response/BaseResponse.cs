using FluentValidation.Results;
using Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Infrastructure.Http.Response
{
    public class PaginatedBaseResponse<T> : BaseResponse<IEnumerable<T>>
    {
        public int Limit { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(TotalCount / (double)Limit);
            }
        }

        public int CurrentPage { get; set; }
    }

    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Errors = new List<Error>();
        }

        public BaseResponse(T data)
        {
            Data = data;
            Errors = new List<Error>();
        }

        public BaseResponse(T data, HttpStatusCode status)
        {
            Data = data;
            StatusCode = status;
            Errors = new List<Error>();
        }

        #region Members
        private HttpStatusCode? StatusCode { get; set; }
        public bool Success => !Errors.Any();
        public T Data { get; set; }
        public List<Error> Errors { get; set; }
        #endregion

        #region Public Methods
        public void AddErrors(IEnumerable<ValidationFailure> errors)
        {
            foreach (var error in errors)
                AddError(new Error { Code = int.Parse(error.ErrorCode), Message = error.ErrorMessage });
        }

        public void AddErrorss(IEnumerable<ValidationFailure> errors)
        {
            foreach (var error in errors)
                AddError(new Error { Message = error.ErrorMessage });
        }

        public BaseResponse<T> AddErrorsAndReturn(IEnumerable<ValidationFailure> errors)
        {
            foreach (var error in errors)
                AddError(new Error { Code = int.Parse(error.ErrorCode), Message = error.ErrorMessage });
            return this;
        }


        public HttpStatusCode GetStatusCode()
        {
            if (Errors.Any())
                return StatusCode ?? HttpStatusCode.UnprocessableEntity;

            return StatusCode ?? HttpStatusCode.OK;
        }

        public void SetStatusCode(HttpStatusCode status)
        {
            StatusCode = status;
        }

        public void AddError(Event @event, params string[] messageValues)
        {
            AddError(new Error
            {
                Code = @event.Code,
                Message = string.Format(@event.Message, messageValues)
            });
        }

        public void AddError(Event @event)
        {
            AddError(new Error
            {
                Code = @event.Code,
                Message = @event.Message
            });
        }

        public BaseResponse<T> AddErrorAndReturn(Event @event)
        {
            AddError(new Error
            {
                Code = @event.Code,
                Message = @event.Message
            });

            return this;
        }

        public void AddError(string errorMessage)
        {
            AddError(new Error
            {
                Message = errorMessage
            });
        }

        public void AddError(int errorCode, string message)
        {
            AddError(new Error
            {
                Code = errorCode,
                Message = message
            });
        }

        public void AddError(string errorMessage, Event errorEvent)
        {
            AddError(new Error
            {
                Code = errorEvent.Code,
                Message = errorMessage
            });
        }

        public void AddError(Event errorEvent, params object[] errorParameters)
        {
            AddError(new Error
            {
                Code = errorEvent.Code,
                Message = string.Format(errorEvent.Message, errorParameters)
            });
        }
        #endregion

        #region Private Methods
        private void AddError(Error errorResponse, HttpStatusCode status = HttpStatusCode.UnprocessableEntity)
        {
            if (StatusCode == null)
                StatusCode = status;

            if (typeof(T) == typeof(bool))
                Data = default(T);

            Errors.Add(errorResponse);
        }
        #endregion
    }
}
