using System;
using System.Runtime.Serialization;

namespace ITMCServiceCenter.Web.Domain
{
    /// <summary>
    /// This Service Returns the object of this class
    /// </summary>
    [DataContract]
    public class ServiceResult
    {
        [DataMember]
        public bool Success { get; set; }

        private int _resultCode;
        [DataMember]
        public int ResultCode
        {
            get { return _resultCode; }
            set { _resultCode = value; }
        }

        [DataMember]
        public string ResultMessage { get; set; }

        [DataMember]
        public ExceptionInfo ExceptionInfo { get; set; }
    }


    /// <summary>
    /// Generic information class 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult() { }
        [DataMember]
        public T Value { get; set; }
    }


    [DataContract]
    public class ExceptionInfo
    {
        public ExceptionInfo()
        { }

        public ExceptionInfo(Exception ex)
        {
            Message = ex.Message;
            Source = ex.Source;
            StackTrace = ex.StackTrace;
            FullString = ex.ToString();
        }

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public string StackTrace { get; set; }
        [DataMember]
        public string FullString { get; set; }

        public override string ToString()
        {
            return FullString;
        }
    }

}