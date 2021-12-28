using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICBrowser.Common;
using ICBrowser.Business;

namespace ICBrowser.Web
{
    public partial class FaqQuestion : BasePage
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnQueSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnQueSave_Click(object sender, EventArgs e)
        {
            Common.FAQ faq = new Common.FAQ();
            AdminStaticData asd = new AdminStaticData();

            faq.QuestionEng = Server.HtmlEncode(queEng.Content);
            faq.QuestionCny = Server.HtmlEncode(queCny.Content);

            faq.AnswerEng = Server.HtmlEncode(ansEng.Content);
            faq.AnswerCny = Server.HtmlEncode(ansCny.Content);

            asd.AddNewFaq(faq);
            lblSucess.Visible = true;

            ClearControls();

            

        }

        /// <summary>
        /// Handles the Click event of the btnQueClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnQueClear_Click(object sender, EventArgs e)
        {
            lblSucess.Visible = false;
            lblError.Visible = false;
            ClearControls();
        }

        /// <summary>
        /// Clears the controls.
        /// </summary>
        public void ClearControls()
        {
            queCny.Content = string.Empty;
            queEng.Content = string.Empty;
            ansEng.Content = string.Empty;
            ansCny.Content = string.Empty;
        }
    }
}