Namespace SharedLib
    Public Class Math

        Public Shared Function Round(ByVal decValue As Decimal, ByVal intDigits As Integer) As Decimal
            Return System.Math.Round(decValue, intDigits, MidpointRounding.AwayFromZero)
        End Function

        Public Shared Function Ceil(ByVal decValue As Decimal) As Decimal
            Return System.Math.Ceiling(decValue)
        End Function

        Public Shared Function Floor(ByVal decValue As Decimal) As Decimal
            Return System.Math.Floor(decValue)
        End Function

        Public Shared Function NumberToString(ByVal decParam As Decimal) As String
            Dim strResult As String = "", strNum As String = "", strChkNum As String = ""
            Dim intChkLen As Integer = 0, intModLen As String = 0
            Dim bolBelas As Boolean = False

            '# Check decimal and Insert to Array
            Dim cekSelisih As Decimal = decParam - SharedLib.Math.Floor(decParam)
            Dim strParam() As String
            ReDim strParam(IIf(cekSelisih <> 0, 1, 0))
            strParam(0) = CStr(SharedLib.Math.Floor(decParam))
            If strParam.Length > 1 Then
                strParam(1) = CStr(SharedLib.Math.Round(cekSelisih * IIf(cekSelisih.ToString.Length = 3, 10, 100), 0))
            End If

            '# Loop Start
            For intY As Integer = 0 To strParam.Length - 1
                strNum = strParam(intY)
                strChkNum = ""
                intChkLen = strNum.Length
                intModLen = 0
                bolBelas = False

                If intY > 0 Then
                    strResult += "Koma "
                End If

                For intI As Integer = 0 To strNum.Length - 1
                    strChkNum = strNum.Substring(intI, 1)
                    intModLen = intChkLen Mod 3

                    If bolBelas Then
                        Select Case strChkNum
                            Case 0 : strResult += "Sepuluh "
                            Case 1 : strResult += "Sebelas "
                            Case 2 : strResult += "Dua Belas "
                            Case 3 : strResult += "Tiga Belas "
                            Case 4 : strResult += "Empat Belas"
                            Case 5 : strResult += "Lima Belas "
                            Case 6 : strResult += "Enam Belas "
                            Case 7 : strResult += "Tujuh Belas "
                            Case 8 : strResult += "Delapan Belas "
                            Case 9 : strResult += "Sembilan Belas "
                        End Select
                        bolBelas = False
                    Else
                        Select Case strChkNum
                            Case 1 : If intModLen = 1 Then
                                    strResult += "Satu "
                                ElseIf intModLen = 0 Then
                                    strResult += "Se"
                                End If
                            Case 2 : strResult += "Dua "
                            Case 3 : strResult += "Tiga "
                            Case 4 : strResult += "Empat "
                            Case 5 : strResult += "Lima "
                            Case 6 : strResult += "Enam "
                            Case 7 : strResult += "Tujuh "
                            Case 8 : strResult += "Delapan "
                            Case 9 : strResult += "Sembilan "
                        End Select
                    End If

                    If strChkNum <> "0" Then
                        Select Case intModLen
                            Case 0 : strResult += "ratus "
                            Case 2 : If strChkNum <> "1" Then strResult += "puluh " Else bolBelas = True
                        End Select
                    End If

                    If (intChkLen = 13 Or intChkLen = 10 Or intChkLen = 7 Or intChkLen = 4) AndAlso _
                        (strNum.Substring(intI, 1) <> "0" Or _
                         (intI - 1 >= 0 AndAlso _
                          strNum.Substring(intI - 1, 1) <> "0") Or (intI - 2 >= 0 AndAlso strNum.Substring(intI - 2, 1) <> "0")) Then
                        Select Case intChkLen
                            Case 13 : strResult += "Trilyun "
                            Case 10 : strResult += "Milyar "
                            Case 7 : strResult += "Juta "
                            Case 4 : strResult += "Ribu "
                        End Select
                    End If
                    intChkLen -= 1
                Next

            Next
            Return strResult.ToUpper & "Rupiah".ToUpper
        End Function

    End Class
End Namespace