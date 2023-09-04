Module modSharedForm

    'Public Function ShowSplitReceive(ByVal strID As String, ByVal intSplitNumber As Integer, ByVal clsCS As VO.CS) As Boolean
    '    Dim bolReturn As Boolean = False
    '    Dim frmDetail As New frmTraReceiveSplit
    '    With frmDetail
    '        .pubCS = clsCS
    '        .pubReceiveID = strID
    '        .pubSplitNumber = intSplitNumber
    '        .StartPosition = FormStartPosition.CenterScreen
    '        .ShowDialog()
    '        bolReturn = .pubIsSave
    '    End With
    '    Return bolReturn
    'End Function

    'Public Function ShowInputSplitNumber() As Integer
    '    Dim intReturn As Integer = 0
    '    Dim frmDetail As New frmTraReceiveSplitInputNumber
    '    With frmDetail
    '        .StartPosition = FormStartPosition.CenterScreen
    '        .ShowDialog()
    '        intReturn = .pubSplitNumber
    '    End With
    '    Return intReturn
    'End Function

    'Public Function ShowSplitReceiveVer2(ByVal strID As String, ByVal dtData As DataTable, ByVal clsCS As VO.CS) As Boolean
    '    Dim bolReturn As Boolean = False
    '    Dim frmDetail As New frmTraReceiveSplitVer2
    '    With frmDetail
    '        .pubCS = clsCS
    '        .pubReceiveID = strID
    '        .pubData = dtData
    '        .StartPosition = FormStartPosition.CenterScreen
    '        .ShowDialog()
    '        bolReturn = .pubIsSave
    '    End With
    '    Return bolReturn
    'End Function

    'Public Function ShowInputSplitNumberVer2() As DataTable
    '    Dim dtReturn As New DataTable
    '    Dim frmDetail As New frmTraReceiveSplitInputNumber
    '    With frmDetail
    '        .StartPosition = FormStartPosition.CenterScreen
    '        .ShowDialog()
    '        dtReturn = .pubDataReturn
    '    End With
    '    Return dtReturn
    'End Function

End Module
