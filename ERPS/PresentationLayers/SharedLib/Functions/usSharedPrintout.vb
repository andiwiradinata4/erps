Namespace SharedLib
    Public Class usSharedPrintout
        Public Sub PrintCostBankOut(ByVal frm As Form, ByVal strID As String, ByVal dtSource As DataTable)
            Dim crReport As New rptCostBankOutVer00
            crReport.DataSource = dtSource
            crReport.CreateDocument(True)
            crReport.ShowPreviewMarginLines = False
            crReport.ShowPrintMarginsWarning = False

            Dim dxHelper As New DX.usDXHelper
            dxHelper.SetSubReportDataSource(crReport, "xsAttachment", BL.Cost.PrintCostBankOutAttachment(strID))
            Dim frmDetail As New frmReportPreview
            With frmDetail
                .docViewer.DocumentSource = crReport
                .pgExportButton.Enabled = True
                .Text = frm.Text & " - " & VO.Reports.PrintOut
                .WindowState = FormWindowState.Maximized
                .Show()
            End With
        End Sub
    End Class
End Namespace