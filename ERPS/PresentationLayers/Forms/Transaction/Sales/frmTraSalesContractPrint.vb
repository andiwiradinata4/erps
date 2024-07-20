Public Class frmTraSalesContractPrint

    Private enumType As VO.SalesContract.PrintType = VO.SalesContract.PrintType.None

    Public ReadOnly Property pubType As VO.SalesContract.PrintType
        Get
            Return enumType
        End Get
    End Property

    Private Sub prvPreview()
        Dim strTipe As String = "None"
        If rdDefault.Checked Then
            enumType = VO.SalesContract.PrintType.DefaultValue
            strTipe = "Default"
        ElseIf rdSKBDN.Checked Then
            enumType = VO.SalesContract.PrintType.SKBDN
            strTipe = "SKBDN"
        End If

        If Not UI.usForm.frmAskQuestion("Cetak Kontrak Penjualan Tipe " & strTipe & "?") Then Exit Sub
        Me.Close()
    End Sub

#Region "Form Handle"

    Private Sub frmTraSalesContractPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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