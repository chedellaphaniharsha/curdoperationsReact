using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curdoperationsReact.Models
{
    public class Response
    {
        public string message { get; set; }
        public int result { get; set; }
    }
    public enum Status
    {
        SuccessfullyRegistered = 1,
        ExceptionOccurred = 2
    }

}
