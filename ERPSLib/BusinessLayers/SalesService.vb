Namespace BL
 
    Public Class SalesService

#Region "Main"

        Public Shared Function ListData(ByVal intProgramID As Integer, ByVal intCompanyID As Integer,
                                        ByVal dtmDateFrom As DateTime, ByVal dtmDateTo As DateTime,
                                        ByVal intStatusID As Integer, ByVal strSelectedItemType As String) As DataTable
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesService.ListData(sqlCon, Nothing, intProgramID, intCompanyID, dtmDateFrom, dtmDateTo, intStatusID, strSelectedItemType)
            End Using
        End Function

        Public Shared Function GetNewID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction,
                                        ByVal dtmTransDate As DateTime, ByVal intCompanyID As Integer,
                                        ByVal intProgramID As Integer, ByVal intServiceType As VO.ServiceType.Value) As String
            Dim clsCompany As VO.Company = DL.Company.GetDetail(sqlCon, sqlTrans, intCompanyID)
            Dim strServiceTypeInitial As String = "SS"
            If intServiceType = VO.ServiceType.Value.Transport Then strServiceTypeInitial = "SST"
            If intServiceType = VO.ServiceType.Value.Cutting Then strServiceTypeInitial = "SSC"
            Dim strNewID As String = strServiceTypeInitial & Format(dtmTransDate, "yyyyMMdd") & "-" & clsCompany.CompanyInitial & "-" & Format(intProgramID, "00") & "-"
            strNewID &= Format(DL.SalesContract.GetMaxID(sqlCon, sqlTrans, strNewID) + 1, "0000")
            Return strNewID
        End Function

        Public Shared Function SaveData(ByVal bolNew As Boolean, ByVal clsData As VO.SalesService) As String
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                    If bolNew Then
                        clsData.ID = GetNewID(sqlCon, sqlTrans, clsData.TransDate, clsData.CompanyID, clsData.ProgramID, clsData.ServiceType)
                        If clsData.TransNumber.Trim = "" Then clsData.TransNumber = clsData.ID
                    Else
                        DL.SalesService.DeleteDataDetail(sqlCon, sqlTrans, clsData.ID)
                    End If
                    Dim intStatusID As Integer = DL.SalesContract.GetStatusID(sqlCon, sqlTrans, clsData.ID)
                    If intStatusID = VO.Status.Values.Approved Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di approve")
                    ElseIf intStatusID = VO.Status.Values.Submit Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data telah di submit")
                    ElseIf DL.SalesContract.IsDeleted(sqlCon, sqlTrans, clsData.ID) Then
                        Err.Raise(515, "", "Data tidak dapat disimpan. Dikarenakan data sudah pernah dihapus")
                    ElseIf DL.SalesContract.DataExists(sqlCon, sqlTrans, clsData.SCNumber, clsData.ID) Then
                        Err.Raise(515, "", "Tidak dapat disimpan. Nomor " & clsData.SCNumber & " sudah ada.")
                    End If

                    DL.SalesService.SaveData(sqlCon, sqlTrans, bolNew, clsData)

                    Dim intCount As Integer = 1
                    For Each cls As VO.SalesServiceDet In clsData.Detail
                        cls.ParentID = clsData.ID
                        cls.ID = clsData.ID & Format(intCount, "000")
                        DL.SalesService.SaveDataDetail(sqlCon, sqlTrans, cls)
                        intCount += 1
                    Next

                    '# Save Data Status
                    BL.SalesService.SaveDataStatus(sqlCon, sqlTrans, clsData.ID, IIf(bolNew, "BARU", "EDIT"), ERPSLib.UI.usUserApp.UserID, clsData.Remarks)

                    If clsData.Save = VO.Save.Action.SaveAndSubmit Then Submit(sqlCon, sqlTrans, clsData.ID, clsData.Remarks)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
            Return clsData.ID
        End Function

        Public Shared Function GetDetail(ByVal strID As String) As VO.SalesService
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Return DL.SalesService.GetDetail(sqlCon, Nothing, strID)
            End Using
        End Function

        Public Shared Sub DeleteData(ByVal strID As String)
            BL.Server.ServerDefault()
            Using sqlCon As SqlConnection = DL.SQL.OpenConnection
                Dim sqlTrans As SqlTransaction = sqlCon.BeginTransaction
                Try

                    'If DL.SalesService.XXX(sqlCon, sqlTransstrID) Then 
                    '    Err.Raise(515,"","Cannot Delete. Data already used at XXX") 
                    'End If 

                    DL.SalesService.DeleteData(sqlCon, sqlTrans, strID)

                    sqlTrans.Commit()
                Catch ex As Exception
                    sqlTrans.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

#End Region
    End Class 

End Namespace

