using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Filtr
{
    public class DisableBasicAuthorization:Attribute, IFilterMetadata
    {

    }
}
