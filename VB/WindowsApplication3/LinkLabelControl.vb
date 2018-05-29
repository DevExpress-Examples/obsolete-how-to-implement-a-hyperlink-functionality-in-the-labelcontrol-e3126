Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports System.Drawing
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Text
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.Utils.Text.Internal
Imports System.Reflection
Imports System.Diagnostics
Imports DevExpress.Utils

Namespace DXSample
	Public Class LinkLabelControl
		Inherits LabelControl
		Friend Const StartLinkTag As String = "<link=", EndLinkTag As String = "</link>"
		Private links_Renamed As List(Of LinkBlock)
		Private pressedLink_Renamed As LinkBlock

		Public Sub New()
			MyBase.New()
			links_Renamed = New List(Of LinkBlock)()
		End Sub

		Friend ReadOnly Property Links() As List(Of LinkBlock)
			Get
				Return links_Renamed
			End Get
		End Property

		Friend Property PressedLink() As LinkBlock
			Get
				Return pressedLink_Renamed
			End Get
			Set(ByVal value As LinkBlock)
				If pressedLink_Renamed IsNot value Then
					pressedLink_Renamed = value
					Refresh()
				End If
			End Set
		End Property

		Public Overrides Property Text() As String
			Get
				Return MyBase.Text
			End Get
			Set(ByVal value As String)
				If AllowHtmlString Then
					UpdateLinks(value)
				End If
				MyBase.Text = value
			End Set
		End Property

		Private Sub UpdateLinks(ByVal text As String)
			links_Renamed.Clear()
			ParseText(text)
		End Sub

		Private Sub ParseText(ByVal text As String)
			Dim startLinkTagIndex As Integer = text.IndexOf(StartLinkTag)
			If startLinkTagIndex = -1 Then
				Return
			End If
			Dim endLinkTagIndex As Integer = text.IndexOf(EndLinkTag)
			If endLinkTagIndex = -1 Then
				Return
			End If
			Dim index As Integer = startLinkTagIndex + StartLinkTag.Length
			Dim startBracketIndex As Integer = text.IndexOf("<", index)
			Dim endBracketIndex As Integer = text.IndexOf(">", index)
			If startBracketIndex < endBracketIndex Then
				Return
			End If
			Dim link As String = text.Substring(index, endBracketIndex - index)
			Dim linkText As String = text.Substring(endBracketIndex + 1, endLinkTagIndex - endBracketIndex - 1)
			CreateNewLink(link, linkText, False)
			ParseText(text.Substring(endLinkTagIndex + EndLinkTag.Length))
		End Sub

		Private Sub CreateNewLink(ByVal link As String, ByVal linkText As String, ByVal isVisitedLink As Boolean)
			Dim bl As New LinkBlock(linkText, link, isVisitedLink)
			links_Renamed.Add(bl)
		End Sub

		Protected Overrides Function CreateViewInfo() As DevExpress.XtraEditors.ViewInfo.BaseStyleControlViewInfo
			Return New LinkLabelControlViewInfo(Me)
		End Function

		Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
			MyBase.OnMouseMove(e)
			If AllowHtmlString Then
				SetCursor(e)
			End If
		End Sub

		Private Sub SetCursor(ByVal e As MouseEventArgs)
			If GetLink(e) IsNot Nothing Then
				Cursor.Current = Cursors.Hand
			Else
				Cursor.Current = Cursors.Default
			End If
		End Sub

		Private Function GetLink(ByVal e As MouseEventArgs) As LinkBlock
			Dim text As String = GetLinkText(e)
			If (Not text.Equals(String.Empty)) Then
				For Each bl As LinkBlock In Links
					If bl.LinkText = text Then
						Return bl
					End If
				Next bl
			End If
			Return Nothing
		End Function

		Private Function GetLinkText(ByVal e As MouseEventArgs) As String
			Dim pr As PropertyInfo = ViewInfo.StringInfo.GetType().GetProperty("Blocks", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
			Dim blocks As List(Of StringBlock) = TryCast(pr.GetValue(ViewInfo.StringInfo, Nothing), List(Of StringBlock))
			pr = ViewInfo.StringInfo.GetType().GetProperty("BlocksBounds", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
			Dim blocksBounds As List(Of Rectangle) = TryCast(pr.GetValue(ViewInfo.StringInfo, Nothing), List(Of Rectangle))
			For i As Integer = 0 To blocksBounds.Count - 1
				If blocksBounds(i).Contains(e.Location) Then
					Return blocks(i).Text
				End If
			Next i
			Return String.Empty
		End Function


		Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
			MyBase.OnMouseDown(e)
			If AllowHtmlString Then
				Dim bl As LinkBlock = GetLink(e)
				If bl IsNot Nothing Then
					PressedLink = bl
				End If
			End If
		End Sub

		Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
			MyBase.OnMouseUp(e)
			If PressedLink IsNot Nothing Then
				OpenLink()
				PressedLink.IsVisitedLink = True
				PressedLink = Nothing
			End If
		End Sub

		Private Sub OpenLink()
			Try
				Process.Start(PressedLink.Link.Trim())
			Catch exc As Exception
				XtraMessageBox.Show(exc.Message)
			End Try
		End Sub


		Public Overrides Function GetPreferredSize(ByVal proposedSize As Size) As Size
			Dim mode As LabelAutoSizeMode = RealAutoSizeMode
			If mode = LabelAutoSizeMode.Horizontal Then
				If proposedSize.Width = 1 Then
					proposedSize.Width = 0
				End If
				If proposedSize.Height = 1 Then
					proposedSize.Height = 0
				End If
			ElseIf mode = LabelAutoSizeMode.Vertical Then
				If proposedSize.Width = Integer.MaxValue OrElse proposedSize.Width = 1 Then
					proposedSize.Width = Width
				End If
			End If
			ViewInfo.UpdatePaintAppearance()
			Dim size As Size = ViewInfo.CalcContentSizeByTextSize(ViewInfo.CalcTextSize(ViewInfo.DisplayText, True, mode, proposedSize.Width))
			size.Width += Padding.Left + Padding.Right
			size.Height += Padding.Top + Padding.Bottom
			size = ConstrainByMinMax(size)
			If mode = LabelAutoSizeMode.None Then
				Return New Size(proposedSize.Width, size.Height)
			End If
			If mode = LabelAutoSizeMode.Horizontal Then
				Return size
			End If
			If mode = LabelAutoSizeMode.Vertical Then
				Return New Size(proposedSize.Width, size.Height)
			End If
			Return MyBase.GetPreferredSize(size)
		End Function

		Private Function ConstrainByMinMax(ByVal size As Size) As Size
			If MaximumSize.Width > 0 Then
				size.Width = Math.Min(MaximumSize.Width, size.Width)
			End If
			If MaximumSize.Height > 0 Then
				size.Height = Math.Min(MaximumSize.Height, size.Height)
			End If
			size.Width = Math.Max(MinimumSize.Width, size.Width)
			size.Height = Math.Max(MinimumSize.Height, size.Height)
			Return size
		End Function

		Protected Shadows ReadOnly Property ViewInfo() As LinkLabelControlViewInfo
			Get
				Return TryCast(MyBase.ViewInfo, LinkLabelControlViewInfo)
			End Get
		End Property
	End Class

	Public Class LinkLabelControlViewInfo
		Inherits LabelControlViewInfo
		Public Sub New(ByVal control As BaseStyleControl)
			MyBase.New(control)
		End Sub

		Public Overrides ReadOnly Property DisplayText() As String
			Get
				Dim text As String = MyBase.DisplayText
				If OwnerControl.Links IsNot Nothing Then
					For Each bl As LinkBlock In OwnerControl.Links
						If bl.Equals(OwnerControl.PressedLink) Then
							text = text.Replace(LinkLabelControl.StartLinkTag + bl.Link & ">", "<u><color=red>")
						ElseIf bl.IsVisitedLink Then
							text = text.Replace(LinkLabelControl.StartLinkTag + bl.Link & ">", "<u><color=128,0,128>")
						Else
							text = text.Replace(LinkLabelControl.StartLinkTag + bl.Link & ">", "<u><color=blue>")
						End If
						text = text.Replace(LinkLabelControl.EndLinkTag, "</color></u>")
					Next bl
				End If
				Return text
			End Get
		End Property

		Public Shadows ReadOnly Property OwnerControl() As LinkLabelControl
			Get
				Return TryCast(MyBase.OwnerControl, LinkLabelControl)
			End Get
		End Property

		Public Shadows Function CalcTextSize(ByVal Text As String, ByVal useHotkeyPrefix As Boolean, ByVal mode As LabelAutoSizeMode, ByVal predWidth As Integer) As Size
			Return MyBase.CalcTextSize(Text, useHotkeyPrefix, mode, predWidth)
		End Function
	End Class

	Friend Class LinkBlock
		Private linkText_Renamed, link_Renamed As String
		Private isVisitedLink_Renamed As Boolean

		Public Sub New(ByVal linkText As String, ByVal link As String, ByVal isVisitedLink As Boolean)
			Me.linkText_Renamed = linkText
			Me.link_Renamed = link
			Me.isVisitedLink_Renamed = isVisitedLink
		End Sub

		Public ReadOnly Property LinkText() As String
			Get
				Return linkText_Renamed
			End Get
		End Property

		Public ReadOnly Property Link() As String
			Get
				Return link_Renamed
			End Get
		End Property

		Public Property IsVisitedLink() As Boolean
			Get
				Return isVisitedLink_Renamed
			End Get
			Set(ByVal value As Boolean)
				If isVisitedLink_Renamed <> value Then
					isVisitedLink_Renamed = value
				End If
			End Set
		End Property
	End Class
End Namespace

