using Umbraco.Core.Logging;
using System;
using System.Web.Mvc;

namespace Kickoff.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class HandleBlockErrorAttribute : HandleErrorAttribute
    {
        protected readonly ILogger _logger;

        public HandleBlockErrorAttribute()
        {
            _logger = DependencyResolver.Current.GetService<ILogger>();
        }

        public override void OnException(ExceptionContext filterContext)
        {
            _logger.Warn<HandleBlockErrorAttribute>("Error occured while creating block -> {0}", filterContext.Exception);

            filterContext.ExceptionHandled = true;

            filterContext.Result = new EmptyResult();
        }
    }
}