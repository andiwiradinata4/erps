Namespace DL
 
    Public Class Claim
 
        Public Shared Function ListData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) As DataTable
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText = 
"
SELECT 
	A.ID, A.ProgramID, A.CompanyID, A.ClaimType, A.ClaimNumber, A.ClaimDate, A.BPID, 
	A.ReferencesID, A.PlatNumber, A.Driver, A.ReferencesNumber, A.PPN, A.PPH, 
	A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, 
	A.IsDeleted, A.Remarks, A.StatusID, StatusInfo='Join to tour Master Status', A.SubmitBy, A.SubmitDate, A.CreatedBy, 
	A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.TotalPayment, 
	A.JournalID, A.IsUseSubItem, A.DPAmountPPN, A.DPAmountPPH, A.TotalPaymentPPN, A.TotalPaymentPPH
FROM traClaim A
WHERE 
	1=1 
"

            End With
            Return SQL.QueryDataTable(sqlcmdExecute, sqlTrans)
        End Function

        Public Shared Sub SaveData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal bolNew as Boolean, ByVal clsData As VO.Claim)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                If bolNew Then
                    .CommandText = 
"
INSERT INTO traClaim
	(ID, ProgramID, CompanyID, ClaimType, ClaimNumber, ClaimDate, BPID, 
	 ReferencesID, PlatNumber, Driver, ReferencesNumber, PPN, PPH, 
	 TotalQuantity, TotalWeight, TotalDPP, TotalPPN, TotalPPH, RoundingManual, 
	 IsDeleted, Remarks, StatusID, SubmitBy, SubmitDate, CreatedBy, 
	 CreatedDate, LogBy, LogDate, DPAmount, TotalPayment, JournalID, 
	 IsUseSubItem, DPAmountPPN, DPAmountPPH, TotalPaymentPPN, TotalPaymentPPH)
VALUES 
	(@ID, @ProgramID, @CompanyID, @ClaimType, @ClaimNumber, @ClaimDate, @BPID, 
	 @ReferencesID, @PlatNumber, @Driver, @ReferencesNumber, @PPN, @PPH, 
	 @TotalQuantity, @TotalWeight, @TotalDPP, @TotalPPN, @TotalPPH, @RoundingManual, 
	 @IsDeleted, @Remarks, @StatusID, @SubmitBy, @SubmitDate, @LogBy, 
	 GETDATE(), @LogBy, GETDATE(), @DPAmount, @TotalPayment, @JournalID, 
	 @IsUseSubItem, @DPAmountPPN, @DPAmountPPH, @TotalPaymentPPN, @TotalPaymentPPH)
"
                Else
                    .CommandText = 
"
UPDATE traClaim SET 
	ProgramID=@ProgramID, 
	CompanyID=@CompanyID, 
	ClaimType=@ClaimType, 
	ClaimNumber=@ClaimNumber, 
	ClaimDate=@ClaimDate, 
	BPID=@BPID, 
	ReferencesID=@ReferencesID, 
	PlatNumber=@PlatNumber, 
	Driver=@Driver, 
	ReferencesNumber=@ReferencesNumber, 
	PPN=@PPN, 
	PPH=@PPH, 
	TotalQuantity=@TotalQuantity, 
	TotalWeight=@TotalWeight, 
	TotalDPP=@TotalDPP, 
	TotalPPN=@TotalPPN, 
	TotalPPH=@TotalPPH, 
	RoundingManual=@RoundingManual, 
	IsDeleted=@IsDeleted, 
	Remarks=@Remarks, 
	StatusID=@StatusID, 
	SubmitBy=@SubmitBy, 
	SubmitDate=@SubmitDate, 
	LogInc=LogInc+1, 
	LogBy=@LogBy, 
	LogDate=GETDATE(), 
	DPAmount=@DPAmount, 
	TotalPayment=@TotalPayment, 
	JournalID=@JournalID, 
	IsUseSubItem=@IsUseSubItem, 
	DPAmountPPN=@DPAmountPPN, 
	DPAmountPPH=@DPAmountPPH, 
	TotalPaymentPPN=@TotalPaymentPPN, 
	TotalPaymentPPH=@TotalPaymentPPH
WHERE
	ID=@ID
"
                End If

                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = clsData.ID
                .Parameters.Add("@ProgramID", SqlDbType.int).Value = clsData.ProgramID
                .Parameters.Add("@CompanyID", SqlDbType.int).Value = clsData.CompanyID
                .Parameters.Add("@ClaimType", SqlDbType.int).Value = clsData.ClaimType
                .Parameters.Add("@ClaimNumber", SqlDbType.varchar, 100).Value = clsData.ClaimNumber
                .Parameters.Add("@ClaimDate", SqlDbType.datetime).Value = clsData.ClaimDate
                .Parameters.Add("@BPID", SqlDbType.int).Value = clsData.BPID
                .Parameters.Add("@ReferencesID", SqlDbType.varchar, 100).Value = clsData.ReferencesID
                .Parameters.Add("@PlatNumber", SqlDbType.varchar, 100).Value = clsData.PlatNumber
                .Parameters.Add("@Driver", SqlDbType.varchar, 100).Value = clsData.Driver
                .Parameters.Add("@ReferencesNumber", SqlDbType.varchar, 100).Value = clsData.ReferencesNumber
                .Parameters.Add("@PPN", SqlDbType.decimal).Value = clsData.PPN
                .Parameters.Add("@PPH", SqlDbType.decimal).Value = clsData.PPH
                .Parameters.Add("@TotalQuantity", SqlDbType.decimal).Value = clsData.TotalQuantity
                .Parameters.Add("@TotalWeight", SqlDbType.decimal).Value = clsData.TotalWeight
                .Parameters.Add("@TotalDPP", SqlDbType.decimal).Value = clsData.TotalDPP
                .Parameters.Add("@TotalPPN", SqlDbType.decimal).Value = clsData.TotalPPN
                .Parameters.Add("@TotalPPH", SqlDbType.decimal).Value = clsData.TotalPPH
                .Parameters.Add("@RoundingManual", SqlDbType.decimal).Value = clsData.RoundingManual
                .Parameters.Add("@IsDeleted", SqlDbType.bit).Value = clsData.IsDeleted
                .Parameters.Add("@Remarks", SqlDbType.varchar, 250).Value = clsData.Remarks
                .Parameters.Add("@StatusID", SqlDbType.int).Value = clsData.StatusID
                .Parameters.Add("@SubmitBy", SqlDbType.varchar, 20).Value = clsData.SubmitBy
                .Parameters.Add("@SubmitDate", SqlDbType.datetime).Value = clsData.SubmitDate
                .Parameters.Add("@LogBy", SqlDbType.varchar, 20).Value = clsData.LogBy
                .Parameters.Add("@DPAmount", SqlDbType.decimal).Value = clsData.DPAmount
                .Parameters.Add("@TotalPayment", SqlDbType.decimal).Value = clsData.TotalPayment
                .Parameters.Add("@JournalID", SqlDbType.varchar, 100).Value = clsData.JournalID
                .Parameters.Add("@IsUseSubItem", SqlDbType.bit).Value = clsData.IsUseSubItem
                .Parameters.Add("@DPAmountPPN", SqlDbType.decimal).Value = clsData.DPAmountPPN
                .Parameters.Add("@DPAmountPPH", SqlDbType.decimal).Value = clsData.DPAmountPPH
                .Parameters.Add("@TotalPaymentPPN", SqlDbType.decimal).Value = clsData.TotalPaymentPPN
                .Parameters.Add("@TotalPaymentPPH", SqlDbType.decimal).Value = clsData.TotalPaymentPPH

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans)
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetDetail(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As VO.Claim
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim voReturn As New VO.Claim
            Try
                With sqlcmdExecute
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText =  
"
SELECT TOP 1 
	A.ID, A.ProgramID, A.CompanyID, A.ClaimType, A.ClaimNumber, A.ClaimDate, A.BPID, 
	A.ReferencesID, A.PlatNumber, A.Driver, A.ReferencesNumber, A.PPN, A.PPH, 
	A.TotalQuantity, A.TotalWeight, A.TotalDPP, A.TotalPPN, A.TotalPPH, A.RoundingManual, 
	A.IsDeleted, A.Remarks, A.StatusID, A.SubmitBy, A.SubmitDate, A.CreatedBy, 
	A.CreatedDate, A.LogInc, A.LogBy, A.LogDate, A.DPAmount, A.TotalPayment, 
	A.JournalID, A.IsUseSubItem, A.DPAmountPPN, A.DPAmountPPH, A.TotalPaymentPPN, A.TotalPaymentPPH
	
FROM traClaim A
WHERE
	ID=@ID
"
                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = strID

                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute) 
                With sqlrdData 
                    If .HasRows Then 
                        .Read() 
                        voReturn.ID = .Item("ID")
                        voReturn.ProgramID = .Item("ProgramID")
                        voReturn.CompanyID = .Item("CompanyID")
                        voReturn.ClaimType = .Item("ClaimType")
                        voReturn.ClaimNumber = .Item("ClaimNumber")
                        voReturn.ClaimDate = .Item("ClaimDate")
                        voReturn.BPID = .Item("BPID")
                        voReturn.ReferencesID = .Item("ReferencesID")
                        voReturn.PlatNumber = .Item("PlatNumber")
                        voReturn.Driver = .Item("Driver")
                        voReturn.ReferencesNumber = .Item("ReferencesNumber")
                        voReturn.PPN = .Item("PPN")
                        voReturn.PPH = .Item("PPH")
                        voReturn.TotalQuantity = .Item("TotalQuantity")
                        voReturn.TotalWeight = .Item("TotalWeight")
                        voReturn.TotalDPP = .Item("TotalDPP")
                        voReturn.TotalPPN = .Item("TotalPPN")
                        voReturn.TotalPPH = .Item("TotalPPH")
                        voReturn.RoundingManual = .Item("RoundingManual")
                        voReturn.IsDeleted = .Item("IsDeleted")
                        voReturn.Remarks = .Item("Remarks")
                        voReturn.StatusID = .Item("StatusID")
                        voReturn.SubmitBy = .Item("SubmitBy")
                        voReturn.SubmitDate = .Item("SubmitDate")
                        voReturn.CreatedBy = .Item("CreatedBy")
                        voReturn.CreatedDate = .Item("CreatedDate")
                        voReturn.LogInc = .Item("LogInc")
                        voReturn.LogBy = .Item("LogBy")
                        voReturn.LogDate = .Item("LogDate")
                        voReturn.DPAmount = .Item("DPAmount")
                        voReturn.TotalPayment = .Item("TotalPayment")
                        voReturn.JournalID = .Item("JournalID")
                        voReturn.IsUseSubItem = .Item("IsUseSubItem")
                        voReturn.DPAmountPPN = .Item("DPAmountPPN")
                        voReturn.DPAmountPPH = .Item("DPAmountPPH")
                        voReturn.TotalPaymentPPN = .Item("TotalPaymentPPN")
                        voReturn.TotalPaymentPPH = .Item("TotalPaymentPPH")
                    End If 
                End With 
            Catch ex As Exception 
                Throw ex 
            Finally 
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return voReturn 
        End Function 

        Public Shared Sub DeleteData(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String)
            Dim sqlcmdExecute As New SqlCommand
            With sqlcmdExecute
                .Connection = sqlCon
                .Transaction = sqlTrans
                .CommandText = 
"
DELETE FROM traClaim
WHERE
	ID=@ID
"
                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = strID

            End With
            Try
                SQL.ExecuteNonQuery(sqlcmdExecute, sqlTrans) 
            Catch ex As SqlException
                Throw ex
            End Try
        End Sub

        Public Shared Function GetMaxID(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction) AS Integer
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing 
            Dim intReturn As Integer = 0 
            Try 
                With sqlcmdExecute 
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText = 
"
SELECT TOP 1
	ID=ISNULL(MAX(ID),0)
FROM traClaim
"
                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute) 
                With sqlrdData 
                    If .HasRows Then 
                        .Read() 
                        intReturn = .Item("ID") + 1
                    End If 
                End With 
            Catch ex As Exception 
                Throw ex 
            Finally 
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return intReturn 
        End Function 

        Public Shared Function DataExists(ByRef sqlCon As SqlConnection, ByRef sqlTrans As SqlTransaction, ByVal strID As String) As Boolean
            Dim sqlcmdExecute As New SqlCommand, sqlrdData As SqlDataReader = Nothing
            Dim bolExists As Boolean = False 
            Try 
                With sqlcmdExecute 
                    .Connection = sqlCon 
                    .Transaction = sqlTrans 
                    .CommandText = 
"
SELECT TOP 1
	ID
FROM traClaim
WHERE 
	ID=@ID
"
                .Parameters.Add("@ID", SqlDbType.varchar, 100).Value = strID

                End With
                sqlrdData = SQL.ExecuteReader(sqlCon, sqlcmdExecute) 
                With sqlrdData 
                    If .HasRows Then 
                        .Read() 
                        bolExists = True
                    End If 
                End With 
            Catch ex As Exception 
                Throw ex 
            Finally 
                If sqlrdData IsNot Nothing Then sqlrdData.Close() 
            End Try 
            Return bolExists 
        End Function 

    End Class 

End Namespace

