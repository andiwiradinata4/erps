Public Class frmTraDeliveryPrint

#Region "Properties"

    Private enumType As VO.Delivery.PrintType = VO.Delivery.PrintType.None

    Public ReadOnly Property pubType As VO.Delivery.PrintType
        Get
            Return enumType
        End Get
    End Property

#End Region

    Private Sub prvPreview()
        Dim strTipe As String = "None"
        If rdDefault.Checked Then
            enumType = VO.Delivery.PrintType.Plat
            strTipe = "Plat"
        ElseIf rdSKBDN.Checked Then
            enumType = VO.Delivery.PrintType.Coil
            strTipe = "Coil"
        End If

        If Not UI.usForm.frmAskQuestion("Cetak Surat Jalan Tipe " & strTipe & "?") Then Exit Sub
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub frmTraDeliveryPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.usForm.SetIcon(Me, "MyLogo")
        ToolBar.SetIcon(Me)
    End Sub

    Private Sub ToolBar_ButtonClick(sender As Object, e As ToolBarButtonClickEventArgs) Handles ToolBar.ButtonClick
        Select Case e.Button.Text.Trim
            Case "Print" : prvPreview()
            Case "Tutup" : Me.Close()
        End Select
    End Sub

#End Region

End Class