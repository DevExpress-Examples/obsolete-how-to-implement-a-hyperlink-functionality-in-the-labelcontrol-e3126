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

namespace DXSample {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.linkLabelControl2 = new DXSample.LinkLabelControl();
            this.linkLabelControl1 = new DXSample.LinkLabelControl();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins";
            // 
            // linkLabelControl2
            // 
            this.linkLabelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.linkLabelControl2.Location = new System.Drawing.Point(207, 86);
            this.linkLabelControl2.Name = "linkLabelControl2";
            this.linkLabelControl2.Size = new System.Drawing.Size(123, 19);
            this.linkLabelControl2.TabIndex = 1;
            this.linkLabelControl2.Text = "linkLabelControl2";
            // 
            // linkLabelControl1
            // 
            this.linkLabelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.linkLabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.linkLabelControl1.Location = new System.Drawing.Point(35, 37);
            this.linkLabelControl1.Name = "linkLabelControl1";
            this.linkLabelControl1.Size = new System.Drawing.Size(129, 117);
            this.linkLabelControl1.TabIndex = 0;
            this.linkLabelControl1.Text = "linkLabelControl1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 219);
            this.Controls.Add(this.linkLabelControl2);
            this.Controls.Add(this.linkLabelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "LinkLabelControl";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private LinkLabelControl linkLabelControl1;
        private LinkLabelControl linkLabelControl2;
    }
}

