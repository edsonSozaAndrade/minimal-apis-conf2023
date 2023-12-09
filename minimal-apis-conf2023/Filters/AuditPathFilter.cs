namespace minimal_apis_conf2023.Filters
{
    public static class AuditPathFilter
    {
        public static EndpointFilterDelegate RequestAudit(EndpointFilterFactoryContext handlerContext, EndpointFilterDelegate filterDelegate)
        { 
            var loggerFactory = handlerContext.ApplicationServices.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("RequestAuditor");
            return (invocationContext) =>
            {
                logger.LogInformation($"This is a filter that logs path info : {invocationContext.HttpContext.Request.Path}");
                return filterDelegate(invocationContext);
            };
        }
    }
}
