using Hackathon.Domain.Enums;
using System.Collections.Generic;

namespace Hackathon.Domain.Services
{
    public class ResponseService
    {
        public ResponseTypeEnum Type { get; set; }
        public string Message { get; set; }
        public List<string> FieldsInvalids { get; set; }

        public ResponseService()
        {
            Type = ResponseTypeEnum.None;
            Message = string.Empty;
            FieldsInvalids = new List<string>();
        }

        public ResponseService(ResponseTypeEnum type)
        {
            Type = type;
            FieldsInvalids = new List<string>();
        }

        public ResponseService(ResponseTypeEnum type, string message)
        {
            Type = type;
            Message = message;
            FieldsInvalids = new List<string>();
        }

        public ResponseService(ResponseTypeEnum type, string message, List<string> fieldsInvalids)
        {
            Type = type;
            Message = message;
            FieldsInvalids = fieldsInvalids;
        }
    }
}
