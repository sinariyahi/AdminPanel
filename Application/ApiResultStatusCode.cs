using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "mission accomplished")]
        Success = 0,

        [Display(Name = "An error has occurred on the server")]
        ServerError = 1,

        [Display(Name = "The parameters sent are not valid")]
        BadRequest = 2,

        [Display(Name = "not found")]
        NotFound = 3,

        [Display(Name = "The list is empty")]
        ListEmpty = 4,

        [Display(Name = "A processing error occurred")]
        LogicError = 5,

        [Display(Name = "Authentication error")]
        UnAuthorized = 6
    }
}
