using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Common
{
    public static class Constants
    {
        #region "Logger Strings"
        public static readonly string LOG_ERROR_WITH_REQUEST_DATA = "Request: {0} " + Environment.NewLine + "Error: {1}";
        public static readonly string LOG_ERROR = "Error: {1}";
        #endregion
    }
}
