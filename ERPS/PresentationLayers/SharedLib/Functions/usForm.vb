Imports System.IO
Imports DevExpress.XtraReports.UI

Namespace UI

    Public Class usForm

        Public Shared Sub SetIcon(ByVal frmMe As Form, ByVal strIconName As String)
            frmMe.Icon = New Icon(frmMe.GetType(), strIconName & ".ico")
        End Sub

        Public Shared Sub frmMessageBox(ByVal strMessage As String, Optional ByVal strCaption As String = "Pesan")
            MessageBox.Show(strMessage, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub

        Public Shared Function frmAskQuestion(ByVal strQuestion As String) As Boolean
            If MessageBox.Show(strQuestion, "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Shared Sub frmOpen(ByRef f As Object, ByVal fT As String, ByRef fMe As Form)
            Dim s_fT As String = fMe.GetType.Namespace & "." & fT
            fMe.Cursor = Cursors.WaitCursor
            If Not IsNothing(f) Then
                If Not f.IsDisposed Then
                    f.WindowState = FormWindowState.Normal
                    f.BringToFront()
                    f.WindowState = FormWindowState.Maximized
                Else
                    f = Activator.CreateInstance(Type.GetType(s_fT))
                    f.MdiParent = fMe
                    f.Show()
                End If
            Else
                f = Activator.CreateInstance(Type.GetType(s_fT))
                f.MdiParent = fMe
                f.Show()
            End If
            fMe.Cursor = Cursors.Arrow
        End Sub

        Public Shared Sub SetToolBar(ByRef frmMe As Form, ByVal tobToolBar As ToolBar, ByVal strIcon As String)
            Dim iltImageList As New ImageList
            Dim Icon() = Split(strIcon, ",")
            Dim bteI, bteJ As Byte
            tobToolBar.ImageList = iltImageList
            With iltImageList
                .ImageSize = New Size(20, 20)
                .ColorDepth = ColorDepth.Depth32Bit
                bteI = 1
                While bteI <= UBound(Icon)
                    .Images.Add(New Icon(frmMe.GetType(), Icon(bteI) + ".ico"))
                    bteI += 2
                End While
                bteI = 0 : bteJ = 0
                While bteI < UBound(Icon)
                    tobToolBar.Buttons(CByte(Icon(bteI))).ImageIndex = bteJ
                    bteI += 2 : bteJ += 1
                End While
            End With
        End Sub

        Public Shared Sub SetGrid(ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                  ByVal strFieldName As String, _
                                  ByVal strCaption As String, _
                                  ByVal intColoumnWidth As Integer, _
                                  ByVal intColoumnType As Integer, _
                                  Optional ByVal bolVisible As Boolean = True, _
                                  Optional ByVal bolReadonly As Boolean = True)

            Dim grdNewColumn As New DevExpress.XtraGrid.Columns.GridColumn
            With grdNewColumn
                .Name = strFieldName
                .FieldName = strFieldName
                .Caption = strCaption
                .Width = intColoumnWidth

                .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                .AppearanceCell.Options.UseTextOptions = True


                Select Case intColoumnType
                    Case usDefGrid.gBoolean
                        .DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    Case usDefGrid.gFullDate
                        .DisplayFormat.FormatString = usDefCons.DateFull
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    Case usDefGrid.gIntNum
                        .DisplayFormat.FormatString = usDefCons.IntNum
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    Case usDefGrid.gReal1Num
                        .DisplayFormat.FormatString = usDefCons.Real1Num
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    Case usDefGrid.gReal2Num
                        .DisplayFormat.FormatString = usDefCons.Real2Num
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    Case usDefGrid.gReal3Num
                        .DisplayFormat.FormatString = usDefCons.Real3Num
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    Case usDefGrid.gReal4Num
                        .DisplayFormat.FormatString = usDefCons.Real4Num
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    Case usDefGrid.gReal5Num
                        .DisplayFormat.FormatString = usDefCons.Real5Num
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    Case usDefGrid.gReal6Num
                        .DisplayFormat.FormatString = usDefCons.Real6Num
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    Case usDefGrid.gSmallDate
                        .DisplayFormat.FormatString = usDefCons.DateSmall
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    Case usDefGrid.gString
                        .DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    Case usDefGrid.gDateMonth
                        .DisplayFormat.FormatString = usDefCons.DateMonth
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    Case usDefGrid.gDateMonthYear
                        .DisplayFormat.FormatString = usDefCons.DateMonthYear
                        .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                End Select

                .Visible = bolVisible
                .VisibleIndex = IIf(bolVisible, grdView.Columns.Count, -1)

                .OptionsColumn.AllowEdit = Not bolReadonly
                .OptionsColumn.ReadOnly = bolReadonly

            End With
            grdView.Columns.Add(grdNewColumn)
            grdView.OptionsNavigation.AutoMoveRowFocus = False
            grdView.OptionsSelection.EnableAppearanceFocusedCell = False
            grdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

        End Sub

        Public Shared Sub GridMoveRow(ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal strColoumnName As String, ByVal strSearch As Object)
            If strSearch = "" Then Exit Sub

            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = grdView.Columns(strColoumnName)
            Dim Pos As Integer = grdView.LocateByValue(0, Col, strSearch)
            Dim strSelectedValue As String = ""
            If grdView.GroupCount > 0 Then
                grdView.ExpandAllGroups()
                For i As Integer = 0 To grdView.RowCount - 1
                    strSelectedValue = grdView.GetRowCellValue(i, strColoumnName)
                    If Not strSelectedValue Is Nothing Then
                        If strSelectedValue.Trim() = strSearch.ToString.Trim() Then
                            grdView.FocusedRowHandle = i
                            Exit For
                        End If
                    End If
                Next
            Else
                grdView.MoveBy(Pos)
            End If
        End Sub

        Public Shared Sub GridFocusedRow(ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal strColoumnName As String, ByVal strSearch As Object)
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = grdView.Columns(strColoumnName)
            Dim Pos As Integer = grdView.LocateByValue(0, Col, strSearch)
            grdView.FocusedRowHandle = Pos
        End Sub

        Public Shared Sub FillComboBox(ByRef usComboBox As usComboBox, ByVal dtSource As DataTable, ByVal valueMember As String, ByVal displayMember As String, _
                                       Optional ByVal bolSortDisplayMember As Boolean = False, Optional ByVal intSelectedIndex As Integer = -1)
            If bolSortDisplayMember Then dtSource.DefaultView.Sort = displayMember & " ASC"
            With usComboBox
                .MaxDropDownItems = dtSource.Rows.Count + 5
                .DataSource = dtSource
                .ValueMember = valueMember
                .DisplayMember = displayMember
                .SelectedIndex = intSelectedIndex
            End With
        End Sub

        Public Shared Sub FillComboBoxEdit(ByRef usComboBoxEdit As usComboBoxEdit, ByVal dtSource As DataTable, ByVal valueMember As String, ByVal displayMember As String, Optional ByVal initialMember As String = "",
                                           Optional ByVal bolSortData As Boolean = False, Optional ByVal allColumnInfo As List(Of DevExpress.XtraEditors.Controls.LookUpColumnInfo) = Nothing)
            Dim col As DevExpress.XtraEditors.Controls.LookUpColumnInfo = New DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember, initialMember)
            If bolSortData Then col.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

            With usComboBoxEdit
                .Properties.Columns.Clear()
                .Properties.DataSource = dtSource
                .Properties.ValueMember = valueMember
                .Properties.DisplayMember = displayMember
                If allColumnInfo Is Nothing Then
                    .Properties.Columns.Add(col)
                Else
                    .Properties.Columns.AddRange(allColumnInfo.ToArray)
                End If
                .SelectedText = ""
            End With
        End Sub

        Public Shared Function ChooseImage() As String
            Dim strReturn As String = ""
            Dim ofd As New OpenFileDialog
            With ofd
                .Filter = "(Image Files)|*.jpeg;*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg, | *.jpg|Png, | *.png|Bmp, |*.bmp|Gif, | *.gif|Ico | *.ico|Jpeg, | *.jpeg"
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    strReturn = .FileName.Trim
                End If
            End With
            Return strReturn
        End Function

        Public Shared Sub LoadImage(ByRef pictureBoxEdit As DevExpress.XtraEditors.PictureEdit, ByVal strPath As String)
            Dim fs As New FileStream(strPath, FileMode.Open, FileAccess.Read)
            Dim bytImage As Byte() = New Byte(fs.Length - 1) {}
            fs.Read(bytImage, 0, System.Convert.ToInt32(fs.Length))
            pictureBoxEdit.Image = Image.FromStream(fs)
            fs.Close()
        End Sub

        Public Shared Function ConvertBytetoImage(ByVal bytImage As Byte()) As Image
            Dim img As Image
            Dim ms As New IO.MemoryStream(CType(bytImage, Byte()))
            img = Image.FromStream(ms)
            Return img
        End Function

        Public Shared Function GetLogoCompanyByInitial(ByVal strCompanyInitial As String) As Image
            Return Image.FromFile(System.IO.Path.Combine(Application.StartupPath, strCompanyInitial & ".Logo.png"))
        End Function

        Public Shared Sub SaveGridControlLayout(ByVal strFormName As String, ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView,
                                                Optional ByVal strUserID As String = "")
            Dim stream As New System.IO.MemoryStream
            grdView.SaveLayoutToStream(stream)
            stream.Seek(0, System.IO.SeekOrigin.Begin)
            Dim streamReader As New System.IO.StreamReader(stream)
            Dim strConfigData As String = streamReader.ReadToEnd
            Try
                BL.UserConfig.SaveData(New VO.UserConfig With
                                       {
                                            .ID = strFormName & "_" & IIf(strUserID.Trim = "", ERPSLib.UI.usUserApp.UserID, strUserID) & "_GridControl",
                                            .UserID = IIf(strUserID.Trim = "", ERPSLib.UI.usUserApp.UserID, strUserID),
                                            .ConfigData = strConfigData
                                       })
            Catch ex As Exception
                UI.usForm.frmMessageBox(ex.Message, "Save Grid Control Layout")
                Throw ex
            End Try
        End Sub

        Public Shared Sub RestoreGridControlLayout(ByVal strFormName As String, ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView,
                                                   Optional ByVal strUserID As String = "")
            Try
                Dim strConfigData As String = BL.UserConfig.GetDetailConfigData(strFormName & "_" & IIf(strUserID.Trim = "", ERPSLib.UI.usUserApp.UserID, strUserID) & "_GridControl")
                If strConfigData.Trim <> "" Then
                    Dim byteArray As Byte() = System.Text.Encoding.ASCII.GetBytes(strConfigData)
                    Dim stream As New System.IO.MemoryStream(byteArray)
                    grdView.RestoreLayoutFromStream(stream)
                    grdView.ClearColumnsFilter()
                End If
            Catch ex As Exception
                UI.usForm.frmMessageBox(ex.Message, "Restore Grid Control Layout")
                Throw ex
            End Try
        End Sub

        Public Shared Sub DeleteGridControlLayout(ByVal strFormName As String, ByVal grdView As DevExpress.XtraGrid.Views.Grid.GridView,
                                                  Optional ByVal strUserID As String = "")
            Try
                BL.UserConfig.DeleteData(strFormName & "_" & IIf(strUserID.Trim = "", ERPSLib.UI.usUserApp.UserID, strUserID) & "_GridControl")
            Catch ex As Exception
                UI.usForm.frmMessageBox(ex.Message, "Delete Grid Control Layout")
                Throw ex
            End Try
        End Sub

        Public Shared Sub SavePivotGridControlLayout(ByVal strFormName As String, ByVal pivotGrid As DevExpress.XtraPivotGrid.PivotGridControl,
                                                     Optional ByVal strUserID As String = "")
            Dim stream As System.IO.Stream
            stream = New System.IO.MemoryStream()
            pivotGrid.SaveLayoutToStream(stream)
            stream.Seek(0, System.IO.SeekOrigin.Begin)
            Dim streamReader As New System.IO.StreamReader(stream)
            Dim strConfigData As String = streamReader.ReadToEnd
            Try
                BL.UserConfig.SaveData(New VO.UserConfig With
                                       {
                                            .ID = strFormName & "_" & IIf(strUserID.Trim = "", ERPSLib.UI.usUserApp.UserID, strUserID) & "_PivotGridControl",
                                            .UserID = IIf(strUserID.Trim = "", ERPSLib.UI.usUserApp.UserID, strUserID),
                                            .ConfigData = strConfigData
                                       })
            Catch ex As Exception
                UI.usForm.frmMessageBox(ex.Message, "Save Grid Control Layout")
                Throw ex
            End Try
        End Sub

        Public Shared Sub RestorePivotGridControlLayout(ByVal strFormName As String, ByRef pivotGrid As DevExpress.XtraPivotGrid.PivotGridControl,
                                                        Optional ByVal strUserID As String = "")
            Try
                Dim strConfigData As String = BL.UserConfig.GetDetailConfigData(strFormName & "_" & IIf(strUserID.Trim = "", ERPSLib.UI.usUserApp.UserID, strUserID) & "_PivotGridControl")
                If strConfigData.Trim <> "" Then
                    Dim byteArray As Byte() = System.Text.Encoding.ASCII.GetBytes(strConfigData)
                    Dim stream As New System.IO.MemoryStream(byteArray)
                    pivotGrid.RestoreLayoutFromStream(stream)
                    stream.Seek(0, System.IO.SeekOrigin.Begin)
                    pivotGrid.BestFitColumnArea()
                    pivotGrid.BestFitRowArea()
                    pivotGrid.BestFit()
                End If
            Catch ex As Exception
                UI.usForm.frmMessageBox(ex.Message, "Restore Grid Control Layout")
                Throw ex
            End Try
        End Sub


    End Class

End Namespace

