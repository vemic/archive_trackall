using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Vemic.Trackall.Domain.Core.Idm
{
    public static class Entry
    {
        public static IActionResult Run(
            object parameter,
            ILogger log)
        {
            log.LogInformation(typeof(Entry).GetType().Name);
            return new OkObjectResult("stub ok." + parameter);
        }
    }
}
