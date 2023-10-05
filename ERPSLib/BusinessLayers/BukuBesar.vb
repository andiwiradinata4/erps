Namespace BL
    Public Class BukuBesar
        Public Shared Function ListData(ByVal intCompanyID As Integer, ByVal intProgramID As Integer, _
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime, _
                                        Optional ByVal intCOAIDParent As Integer = 0) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.BukuBesar.ListData(sqlCon, Nothing, intCompanyID, intProgramID, dtmDateFrom, dtmDateTo, intCOAIDParent)
            End Using
        End Function

        Private Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                         ByVal intCompanyID As Integer, ByVal intProgramID As Integer,
                                         ByVal dtmDate As DateTime)
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strReturn As String = "BB" & Format(dtmDate, "yyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strReturn = strReturn & Format(DL.BukuBesar.GetMaxID(sqlCon, sqlTrans, strReturn), "00000")
            Return strReturn
        End Function

        Public Shared Function SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.BukuBesar) As String
            clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.CompanyID, clsData.ProgramID, clsData.TransactionDate)
            'If Format(clsData.TransactionDate, "yyyyMMdd") <= DL.PostGL.LastPostedDate(clsData.CompanyID, clsData.ProgramID) Then
            '    Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan tanggal transaksi lebih kecil atau sama dengan tanggal Posting Transaksi")
            'End If
            DL.BukuBesar.SaveData(sqlCon, sqlTrans, clsData)
            Return clsData.ID
        End Function

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal clsData As VO.BukuBesar)
            DL.BukuBesar.DeleteData(sqlCon, sqlTrans, clsData.ID)
        End Sub

    End Class

End Namespace

