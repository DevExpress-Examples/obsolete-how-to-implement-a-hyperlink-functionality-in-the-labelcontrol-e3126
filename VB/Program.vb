' Developer Express Code Central Example:
' How to implement a hyperlink functionality in the LabelControl
' 
' This example illustrates how to create a custom LabelControl so that it can
' display hyperlinks. For this, enable the LabelControl.AllowHtmlString property
' (ms-help://DevExpress.NETv10.2/DevExpress.WindowsForms/DevExpressXtraEditorsLabelControl_AllowHtmlStringtopic.htm)
' and use the <link></link> tags to add a hyperlink to a text.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3126


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins

Namespace DXSample
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			SkinManager.EnableFormSkins()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Main())
		End Sub
	End Class
End Namespace