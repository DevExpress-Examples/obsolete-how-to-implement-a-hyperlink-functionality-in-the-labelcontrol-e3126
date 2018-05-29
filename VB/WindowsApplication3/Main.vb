Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Text
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.Utils.Text.Internal
Imports System.Reflection


Namespace DXSample
	Partial Public Class Main
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			linkLabelControl1.AllowHtmlString = True
			linkLabelControl2.AllowHtmlString = True
			linkLabelControl1.Text = "<i><b><color=5,150,123>Information </color></b></i>" & "<link=www.google.com>Google</link> <i><size=14>Information </size></i>" & "<size=16><link=www.devexpress.com>DevExpress</link></size>"
			linkLabelControl2.Text = "<size=16><link=c:\>Local Disk (C:)</link></size>Your text here<size=16><link=d:\>Local Disk (D:)</link></size>"
		End Sub
	End Class
End Namespace
