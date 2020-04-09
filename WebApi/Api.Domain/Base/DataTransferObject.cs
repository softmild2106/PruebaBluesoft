using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Base
{
    public class DataTransferObject<T>
    {
        public DataTransferObject()
        {
            Header = new HttpHeader();
            Header.Code = HttpCodes.Ok;
        }

        public DataTransferObject(T data, HttpCodes httpCode = HttpCodes.Ok, string msg = "")
        {
            Data = data;
            Header.Code = httpCode;
            Header.Message = msg;
        }

        public T Data { get; set; }
        public HttpHeader Header { get; set; } = new HttpHeader();
    }

    public class HttpHeader
    {
        public HttpCodes Code { get; set; }
        public string Message { get; set; }
    }

    public enum HttpCodes
    {
        Ok = 200,
        OkExist = 201,
        BadRequest = 400,
        UnAuthorized = 401,
        NotFound = 404,
        ValidationError = 421,
        InternalServerError = 500
    }
}
