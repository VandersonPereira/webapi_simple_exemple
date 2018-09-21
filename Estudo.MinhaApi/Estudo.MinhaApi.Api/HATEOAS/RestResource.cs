using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estudo.MinhaApi.Api.HATEOAS
{
    public abstract class RestResource
    {
        public List<RestLink> Links { get; set; } = new List<RestLink>();
    }
}