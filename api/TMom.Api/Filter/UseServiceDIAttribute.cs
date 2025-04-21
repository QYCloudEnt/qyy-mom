using Microsoft.AspNetCore.Mvc.Filters;

namespace TMom.Filter
{
    public class UseServiceDIAttribute : ActionFilterAttribute
    {
        protected readonly ILogger<UseServiceDIAttribute> _logger;
        private readonly string _name;

        public UseServiceDIAttribute(ILogger<UseServiceDIAttribute> logger, string Name = "")
        {
            _logger = logger;
            _name = Name;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            DeleteSubscriptionFiles();
        }

        private void DeleteSubscriptionFiles()
        {
        }
    }
}