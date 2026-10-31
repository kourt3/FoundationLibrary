Namespace Database.Queries
    Public Module Queries
        Function QInsert(Bash As String, Columns As String, Thmes() As String) As String
            Dim times As String = Nothing
            For i = 0 To Thmes.Count - 1
                times += Thmes(i)

                If Not i = Thmes.Count - 1 Then
                    times += "','"
                End If
            Next
            Return "INSERT INTO " & Bash & " (" & Columns & ") VALUES ('" & times & "');"
        End Function
        Function QInsert(bash As String, colthmes() As String, thmes() As String) As String
            Dim times As String = Nothing
            Dim Col As String = Nothing
            For i = 0 To thmes.Count - 1
                times += thmes(i)

                If Not i = thmes.Count - 1 Then
                    times += "','"
                End If
            Next

            For i = 0 To colthmes.Count - 1
                Col += colthmes(i)

                If Not i = colthmes.Count - 1 Then
                    Col += ","
                End If

            Next

            Return "INSERT INTO " & bash & " (" & Col & ") VALUES ('" & times & "');"
        End Function
        Function QSelect(bash As String) As String
            Return "SELECT * FROM " & bash & ";"
        End Function
        Function QSelectWhere(bash As String, thesh As String) As String
            Return "SELECT * FROM " & bash & " WHERE " & thesh
        End Function

        Function QUpdate(bash As String, thesh As String, colnames() As String, thmes() As String) As String
            Dim times As String = Nothing
            For i = 0 To colnames.Count - 1
                times += colnames(i)
                times += " ='"
                times += thmes(i)
                times += "'"
                If Not i = colnames.Count - 1 Then
                    times += ","
                End If
            Next
            Return "UPDATE " & bash & " SET " & times & " WHERE " & thesh & ";"
        End Function


        Function QUpdate(bash As String, thesh As String, colnames As String, thmes() As String) As String
            Dim times As String = Nothing
            Dim col() As String = Split(colnames, ",")
            For i = 0 To col.Count - 1
                times += col(i)
                times += " ='"
                times += thmes(i)
                times += "'"
                If Not i = col.Count - 1 Then
                    times += ","
                End If
            Next
            Return "UPDATE " & bash & " SET " & times & " WHERE " & thesh & ";"
        End Function
        Function QDelete(bash As String, thesh As String) As String
            Return "DELETE FROM " & bash & " WHERE " & thesh
        End Function
        Function QDelete(bash As String) As String
            Return "DELETE FROM " & bash & ";"
        End Function
    End Module
End Namespace
