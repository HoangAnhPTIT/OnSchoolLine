using System.Collections.Generic;

namespace OnSchoolLine.Models
{
    public class BaseResponse
    {
        private List<string> _message = new List<string>();
        public bool Success { get; set; }

        public List<string> Messages => _message;

        public virtual void AddError(string error)
        {
            _message.Add(error);
        }
    }
}
