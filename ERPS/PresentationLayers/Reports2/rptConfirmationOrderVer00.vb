Imports DevExpress.XtraPrinting

Public Class rptConfirmationOrderVer00

    Protected Overrides Sub AfterReportPrint()
        MyBase.AfterReportPrint()
        Dim a As DataRowView = MyBase.GetCurrentRow()
        For Each p As DevExpress.XtraPrinting.Page In Me.Pages
            If p.Index > 0 Then

                Dim bolIsEmpty As Boolean = p.Document.IsEmpty
                Dim a1 As String = ""

            End If
        Next
    End Sub

    'Private Sub rptConfirmationOrderVer00_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
    '    Dim myPage As PageList = report.Pages()

    'End Sub

    Private Sub sbItemHeader_AfterPrint(sender As Object, e As EventArgs)
        'Dim a As DataRowView = MyBase.IsDetail.GetCurrentRow()
        'Dim a1 As String = ""

    End Sub
End Class