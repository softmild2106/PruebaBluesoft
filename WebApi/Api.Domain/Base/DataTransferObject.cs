using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Api.Domain.Base
{
    public class DataTransferObject<T>
    {
        public DataTransferObject()
        {
            Header = new HttpHeader();
            Header.Code = HttpStatusCode.OK;
        }

        public DataTransferObject(T data, HttpStatusCode httpCode = HttpStatusCode.OK, string msg = "")
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
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
    }
}
