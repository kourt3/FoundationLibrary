Namespace Database.Tools
    Public Class DataRow
        Public Column As String
        Public Value As String
    End Class
    Public Class Command
        Public ReadOnly DataRows As New List(Of DataRow)
        Friend ReadOnly Bash As String
        Friend ReadOnly Thesh As String
        Default ReadOnly Property Item(Column As String) As DataRow
            Get
                For i = 0 To DataRows.Count - 1
                    If DataRows(i).Column = Column Then
                        Return DataRows(i)
                    End If
                Next
                Return Nothing
            End Get
        End Property
        Sub New(BashLink As String, Optional TheshLink As String = Nothing)
            Bash = BashLink
            Thesh = TheshLink
        End Sub

        Public Sub AddComand(Column As String, Value As String)
            DataRows.Add(New DataRow With {.Column = Column, .Value = Value})
        End Sub

    End Class
End Namespace

