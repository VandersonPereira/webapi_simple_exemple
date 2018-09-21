using Estudo.MinhaApi.Api.HATEOAS.ResourceBuilders.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;

namespace Estudo.MinhaApi.Api.HATEOAS.Helpers
{
    public class RestResourceBuilder
    {
        public static void BuildResource (object resource, HttpRequestMessage request)
        {
            IEnumerable enumerable = resource as IEnumerable;
            Type dtoType;

            if (enumerable == null)
                dtoType = resource.GetType();
            else
                dtoType = resource.GetType().GetGenericArguments()[0];

            // Verifica se a herança está correta
            if (dtoType.BaseType != typeof(RestResource))
                throw new ArgumentException($"Era esperado um RestResource, porém, foi enviado um {resource.GetType().FullName}");

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            IResourceBuilder resourceBuilder = (IResourceBuilder)Activator.CreateInstance(currentAssembly.GetType($"Estudo.MinhaApi.Api.HATEOAS.ResourceBuilders.Impl.{dtoType.Name}ResourceBuilder"));

            if (enumerable == null)
                resourceBuilder.BuildResource(resource, request);
            else
            {
                foreach (var item in enumerable)
                    resourceBuilder.BuildResource(item, request);
            }
        }
    }
}