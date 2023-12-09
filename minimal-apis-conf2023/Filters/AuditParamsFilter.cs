namespace minimal_apis_conf2023.Filters
{
    public static class AuditParamsFilter
    {
        public static EndpointFilterDelegate RequestParamsAudit(EndpointFilterFactoryContext handlerContext, EndpointFilterDelegate filterDelegate)
        {
            var loggerFactory = handlerContext.ApplicationServices.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("RequestAuditor");
            return (invocationContext) =>
            {
                var paramsToCheck = invocationContext.Arguments;
                logger.LogInformation($"This is a filter that logs the params for insert a new Pokemon:" +
                    $"{System.Text.Json.JsonSerializer.Serialize(paramsToCheck.FirstOrDefault())}");
                return filterDelegate(invocationContext);
            };
        }
    }
}
