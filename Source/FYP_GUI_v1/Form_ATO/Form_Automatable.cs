using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FYP_Common;

namespace FYP_GUI_v1
{
    interface Form_Automatable
    {
        void Show_withAutomationSettings(Model_Automator automationModel);
        void Form_UpdatePathSettings(string suffix);
        void Form_ConfirmSettings(object sender, System.EventArgs e);
        string Form_Validate(LogHelper logger);
        string Form_Execute(LogHelper logger, bool slient);
    }
}
