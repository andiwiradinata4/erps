Namespace VO
    Public Class Journal
        Inherits Common
        Property ID As String
        Property JournalDate As DateTime
        Property ReferencesID As String
        Property TotalAmount As Decimal
        Property IsAutoGenerate As Boolean
        Property IsClosedPeriod As Boolean
        Property ClosedPeriodBy As String
        Property ClosedPeriodDate As DateTime
        Property Remarks As String
        Property StatusID As Integer
        Property JournalNo As String
        Property Initial As String = ""
        Property Detail As New List(Of JournalDet)
        Property Save As VO.Save.Action

        Class InitialValue
            Private Key As String

            Public Shared ReadOnly Sales As InitialValue = New InitialValue("JL")
            Public Shared ReadOnly Receive As InitialValue = New InitialValue("BY")
            Public Shared ReadOnly Journal As InitialValue = New InitialValue("ADJ")

            Private Sub New(key As String)
                Me.Key = key
            End Sub

            Public Overrides Function ToString() As String
                Return Me.Key
            End Function
        End Class

        Enum Value
            PiutangUsaha = 2
            HutangUsaha = 4
            ModalUsaha = 5
            PanjarPembelian = 12
            PanjarPenjualan = 13
            Penjualan = 14
        End Enum


    End Class
End Namespace

