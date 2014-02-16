﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    /// <summary>
    /// This view model will be inherited in all models (DTOs)
    /// </summary>
    [DataContract()]
    public class CommonModel
    {
        public CommonModel()
        {
            ModelMessage = new List<ModelMessage>();
            IsValid = true;
        }

        [DataMember(EmitDefaultValue = false)]
        public List<ModelMessage> ModelMessage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsValid { get; set; }
    }

    public class ModelMessage
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
        public MessageType Type { get; set; }
    }

    public enum MessageType
    {
        Error,
        Success
    }

}
