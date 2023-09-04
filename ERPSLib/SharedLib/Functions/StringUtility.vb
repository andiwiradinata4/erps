﻿Namespace SharedLib
    Public Class StringUtility

        Public Shared Function RemoveWhiteSpace(ByVal strFullString As String) As String
            Return New String(strFullString.Where(Function(e) Not Char.IsWhiteSpace(e)).ToArray())
        End Function

        'Public Shared Function ConvertNumIndo(ByVal Input As Decimal) As String 'Call this function passing the number you desire to be changed
        '    Dim output As String = Nothing
        '    Dim longInput As Long = CLng(Input)
        '    Dim different As Decimal = Input - longInput

        '    Input = CLng(Input)
        '    If Input < 1000 Then
        '        output = FindNumberIndo(Input)
        '    ElseIf Input = 1000 Then
        '        output = "Seribu"
        '    Else
        '        Dim nparts() As String 'used to break the number up into 3 digit parts
        '        Dim n As String = Input 'string version of the number
        '        Dim i As Long = Input.ToString.Length 'length of the string to help break it up

        '        Do Until i - 3 <= 0
        '            n = n.Insert(i - 3, ".") 'insert commas to use as splitters
        '            i = i - 3 'this insures that we get the correct number of parts
        '        Loop
        '        nparts = n.Split(".") 'split the string into the array

        '        i = Input.ToString.Length 'return i to initial value for reuse
        '        Dim p As Integer = 0 'p for parts, used for finding correct suffix

        '        'handle thousands
        '        If nparts.Length = 2 AndAlso nparts(0).Length = 1 AndAlso nparts(0) = 1 Then
        '            output = "Seribu"
        '            Dim strLast As String = nparts(1)
        '            ReDim nparts(0)
        '            nparts(0) = strLast
        '        End If

        '        For Each s As String In nparts
        '            Dim x As Long = CLng(s) 'x is used to compare the part value to other values
        '            p = p + 1
        '            If p = nparts.Length Then 'if p = number of elements in the array then we need to do something different
        '                If x <> 0 Then
        '                    If CLng(s) < 100 Then
        '                        output = output & " " & FindNumberIndo(CLng(s)) ' look up the number, no suffix 
        '                    Else                                                ' required as this is the last part
        '                        output = output & " " & FindNumberIndo(CLng(s))
        '                    End If
        '                End If
        '            Else 'if its not the last element in the array
        '                If x <> 0 Then
        '                    If output = Nothing Then 'we have to check this so we don't add a leading space
        '                        output = output & FindNumberIndo(CLng(s)) & " " & FindSuffixIndo(i, CLng(s)) 'look up the number and suffix
        '                    Else 'spaces must go in the right place
        '                        output = output & " " & FindNumberIndo(CLng(s)) & " " & FindSuffixIndo(i, CLng(s)) 'look up the snumber and suffix
        '                    End If
        '                End If
        '            End If
        '            i = i - 3 'reduce the suffix counter by 3 to step down to the next suffix
        '        Next
        '    End If
        '    If different > 0 Then output = output & " Koma " & FindNumberIndo(different * 100) 'get decimal string
        '    Return output.ToUpper & " Rupiah".ToUpper
        'End Function

        Private Shared Function FindNumberIndo(ByVal Number As Long) As String
            Dim Words As String = Nothing
            Dim Digits() As String = {"Nol", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", _
          "Delapan", "Sembilan", "Sepuluh"}
            Dim Teens() As String = {"", "Sebelas", "Dua Belas", "Tiga Belas", "Empat Belas", "Lima Belas", "Enam Belas", "Tujuh Belas", _
           "Delapan Belas", "Sembilan Belas"}

            If Number < 11 Then
                Words = Digits(Number)

            ElseIf Number < 20 Then
                Words = Teens(Number - 10)

            ElseIf Number = 20 Then
                Words = "Dua Puluh"

            ElseIf Number < 30 Then
                Words = "Dua Puluh " & Digits(Number - 20)

            ElseIf Number = 30 Then
                Words = "Tiga Puluh"

            ElseIf Number < 40 Then
                Words = "Tiga Puluh " & Digits(Number - 30)

            ElseIf Number = 40 Then
                Words = "Empat Puluh"

            ElseIf Number < 50 Then
                Words = "Empat Puluh " & Digits(Number - 40)

            ElseIf Number = 50 Then
                Words = "Lima Puluh"

            ElseIf Number < 60 Then
                Words = "Lima Puluh " & Digits(Number - 50)

            ElseIf Number = 60 Then
                Words = "Enam Puluh"

            ElseIf Number < 70 Then
                Words = "Enam Puluh " & Digits(Number - 60)

            ElseIf Number = 70 Then
                Words = "Tujuh Puluh"

            ElseIf Number < 80 Then
                Words = "Tujuh Puluh " & Digits(Number - 70)

            ElseIf Number = 80 Then
                Words = "Delapan Puluh"

            ElseIf Number < 90 Then
                Words = "Delapan Puluh " & Digits(Number - 80)

            ElseIf Number = 90 Then
                Words = "Sembilan Puluh"

            ElseIf Number < 100 Then
                Words = "Sembilan Puluh " & Digits(Number - 90)

            ElseIf Number < 1000 Then
                Words = Number.ToString
                Words = Words.Insert(1, ",")
                Dim wparts As String() = Words.Split(",")
                If wparts(0) = 1 Then
                    Words = "Seratus"
                Else
                    Words = FindNumberIndo(wparts(0)) & " " & "Ratus"
                End If
                Dim n As String = FindNumberIndo(wparts(1))
                If CLng(wparts(1)) <> 0 Then
                    Words = Words & " " & n
                End If
            End If

            Return Words
        End Function

        Private Shared Function FindSuffixIndo(ByVal Length As Long, ByVal l As Long) As String
            Dim word As String

            If l <> 0 Then
                If Length > 12 Then
                    word = "Triliun"
                ElseIf Length > 9 Then
                    word = "Milyar"
                ElseIf Length > 6 Then
                    word = "Juta"
                ElseIf Length > 3 Then
                    word = "Ribu"
                ElseIf Length > 2 Then
                    word = "Ratus"
                Else
                    word = ""
                End If
            Else
                word = ""
            End If

            Return word
        End Function

        Public Shared Function ConvertNumEnglish(ByVal Input As Long) As String 'Call this function passing the number you desire to be changed
            Dim output As String = Nothing
            If Input < 1000 Then
                output = FindNumberEnglish(Input) 'if its less than 1000 then just look it up
            Else
                Dim nparts() As String 'used to break the number up into 3 digit parts
                Dim n As String = Input 'string version of the number
                Dim i As Long = Input.ToString.Length 'length of the string to help break it up

                Do Until i - 3 <= 0
                    n = n.Insert(i - 3, ",") 'insert commas to use as splitters
                    i = i - 3 'this insures that we get the correct number of parts
                Loop
                nparts = n.Split(",") 'split the string into the array

                i = Input.ToString.Length 'return i to initial value for reuse
                Dim p As Integer = 0 'p for parts, used for finding correct suffix
                For Each s As String In nparts
                    Dim x As Long = CLng(s) 'x is used to compare the part value to other values
                    p = p + 1
                    If p = nparts.Length Then 'if p = number of elements in the array then we need to do something different
                        If x <> 0 Then
                            If CLng(s) < 100 Then
                                output = output & " And " & FindNumberEnglish(CLng(s)) ' look up the number, no suffix 
                            Else                                                ' required as this is the last part
                                output = output & " " & FindNumberEnglish(CLng(s))
                            End If
                        End If
                    Else 'if its not the last element in the array
                        If x <> 0 Then
                            If output = Nothing Then 'we have to check this so we don't add a leading space
                                output = output & FindNumberEnglish(CLng(s)) & " " & FindSuffixEnglish(i, CLng(s)) 'look up the number and suffix
                            Else 'spaces must go in the right place
                                output = output & " " & FindNumberEnglish(CLng(s)) & " " & FindSuffixEnglish(i, CLng(s)) 'look up the snumber and suffix
                            End If
                        End If
                    End If
                    i = i - 3 'reduce the suffix counter by 3 to step down to the next suffix
                Next
            End If
            Return output
        End Function

        Private Shared Function FindNumberEnglish(ByVal Number As Long) As String
            Dim Words As String = Nothing
            Dim Digits() As String = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", _
          "Eight", "Nine", "Ten"}
            Dim Teens() As String = {"", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", _
           "Eighteen", "Nineteen"}

            If Number < 11 Then
                Words = Digits(Number)

            ElseIf Number < 20 Then
                Words = Teens(Number - 10)

            ElseIf Number = 20 Then
                Words = "Twenty"

            ElseIf Number < 30 Then
                Words = "Twenty " & Digits(Number - 20)

            ElseIf Number = 30 Then
                Words = "Thirty"

            ElseIf Number < 40 Then
                Words = "Thirty " & Digits(Number - 30)

            ElseIf Number = 40 Then
                Words = "Fourty"

            ElseIf Number < 50 Then
                Words = "Fourty " & Digits(Number - 40)

            ElseIf Number = 50 Then
                Words = "Fifty"

            ElseIf Number < 60 Then
                Words = "Fifty " & Digits(Number - 50)

            ElseIf Number = 60 Then
                Words = "Sixty"

            ElseIf Number < 70 Then
                Words = "Sixty " & Digits(Number - 60)

            ElseIf Number = 70 Then
                Words = "Seventy"

            ElseIf Number < 80 Then
                Words = "Seventy " & Digits(Number - 70)

            ElseIf Number = 80 Then
                Words = "Eighty"

            ElseIf Number < 90 Then
                Words = "Eighty " & Digits(Number - 80)

            ElseIf Number = 90 Then
                Words = "Ninety"

            ElseIf Number < 100 Then
                Words = "Ninety " & Digits(Number - 90)

            ElseIf Number < 1000 Then
                Words = Number.ToString
                Words = Words.Insert(1, ",")
                Dim wparts As String() = Words.Split(",")
                Words = FindNumberEnglish(wparts(0)) & " " & "Hundred"
                Dim n As String = FindNumberEnglish(wparts(1))
                If CLng(wparts(1)) <> 0 Then
                    Words = Words & " And " & n
                End If
            End If

            Return Words
        End Function

        Private Shared Function FindSuffixEnglish(ByVal Length As Long, ByVal l As Long) As String
            Dim word As String

            If l <> 0 Then
                If Length > 12 Then
                    word = "Trillion"
                ElseIf Length > 9 Then
                    word = "Billion"
                ElseIf Length > 6 Then
                    word = "Million"
                ElseIf Length > 3 Then
                    word = "Thousand"
                ElseIf Length > 2 Then
                    word = "Hundred"
                Else
                    word = ""
                End If
            Else
                word = ""
            End If

            Return word
        End Function

    End Class
End Namespace
