using System.Web.Mvc;

namespace Mailbox.Helpers{
    public static class SectionHelper{
        public static MvcHtmlString ValidationSection(this string errorMessage) {
            string formattedErrorMessage = string.Empty;
            if(errorMessage != null && errorMessage != string.Empty){
                formattedErrorMessage = string.Format(
                    "<span class=\"ValidationError\">{0}</span>",
                    errorMessage
                );
            }
            return MvcHtmlString.Create(formattedErrorMessage);
        }
    }
}