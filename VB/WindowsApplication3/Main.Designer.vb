Imports Microsoft.VisualBasic
Imports System
Namespace DXSample
	Partial Public Class Main
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.linkLabelControl2 = New DXSample.LinkLabelControl()
			Me.linkLabelControl1 = New DXSample.LinkLabelControl()
			Me.SuspendLayout()
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
			' 
			' linkLabelControl2
			' 
			Me.linkLabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12F)
			Me.linkLabelControl2.Location = New System.Drawing.Point(207, 86)
			Me.linkLabelControl2.Name = "linkLabelControl2"
			Me.linkLabelControl2.Size = New System.Drawing.Size(123, 19)
			Me.linkLabelControl2.TabIndex = 1
			Me.linkLabelControl2.Text = "linkLabelControl2"
			' 
			' linkLabelControl1
			' 
			Me.linkLabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12F)
			Me.linkLabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
			Me.linkLabelControl1.Location = New System.Drawing.Point(35, 37)
			Me.linkLabelControl1.Name = "linkLabelControl1"
			Me.linkLabelControl1.Size = New System.Drawing.Size(129, 117)
			Me.linkLabelControl1.TabIndex = 0
			Me.linkLabelControl1.Text = "linkLabelControl1"
			' 
			' Main
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(592, 219)
			Me.Controls.Add(Me.linkLabelControl2)
			Me.Controls.Add(Me.linkLabelControl1)
			Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
			Me.Name = "Main"
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			Me.Text = "LinkLabelControl"
'			Me.Load += New System.EventHandler(Me.OnFormLoad);
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
		Private linkLabelControl1 As LinkLabelControl
		Private linkLabelControl2 As LinkLabelControl
	End Class
End Namespace

