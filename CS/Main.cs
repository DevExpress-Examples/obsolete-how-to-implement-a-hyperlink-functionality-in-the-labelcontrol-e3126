// Developer Express Code Central Example:
// How to implement a hyperlink functionality in the LabelControl
// 
// This example illustrates how to create a custom LabelControl so that it can
// display hyperlinks. For this, enable the LabelControl.AllowHtmlString property
// (ms-help://DevExpress.NETv10.2/DevExpress.WindowsForms/DevExpressXtraEditorsLabelControl_AllowHtmlStringtopic.htm)
// and use the <link></link> tags to add a hyperlink to a text.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3126

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Text;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Text.Internal;
using System.Reflection;


namespace DXSample {
    public partial class Main: XtraForm {
        public Main() {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e) {
            linkLabelControl1.AllowHtmlString = true;
            linkLabelControl2.AllowHtmlString = true;
            linkLabelControl1.Text = "<i><b><color=5,150,123>Information </color></b></i>" +
                "<link=www.google.com>Google</link> <i><size=14>Information </size></i>"+
                "<size=16><link=www.devexpress.com>DevExpress</link></size>";
            linkLabelControl2.Text = "<size=16><link=c:\\>Local Disk (C:)</link></size>Your text here<size=16><link=d:\\>Local Disk (D:)</link></size>";
        }
    }
}
