using log4net.Appender;

namespace LoggerUtility.LogUtility
{
    public class CustomAdoNetAppender : AdoNetAppender
    {
        protected override string ResolveConnectionString(out string connectionStringContext)
        {
            string result = base.ResolveConnectionString(out connectionStringContext);
            if (String.IsNullOrEmpty(result))
            {
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}
