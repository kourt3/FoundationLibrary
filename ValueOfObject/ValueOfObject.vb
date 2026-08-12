Imports FoundationLibrary.Interfaces.Keys
Imports FoundationLibrary.ValueOfObject.Bases

Namespace ValueOfObject
    Friend Class ColumnForDB(Of T)
        Implements Bases.IColumnsDB(Of T)

        Public Property Column As String Implements IColumnsDB(Of T).Column
        Public Property IndexOfColumn As Integer Implements IColumnsDB(Of T).IndexOfColumn
        Public Property Type As String Implements IColumnsDB(Of T).Type
        Public Property Format As String Implements IColumnsDB(Of T).Format
        Public Property Value As T Implements IHasValue(Of T).Value


        Public Overrides Function ToString() As String
            Return " Column: " & Column &
                " Index Of Column: " & IndexOfColumn &
                " Type: " & Type &
                " Format: " & Format &
                " Value: " & CType(Value, Object)
        End Function
    End Class

    Public Class ObectOfString
        Implements ValueOfObject.Bases.IObjectOfString

        Private Str As String
        Public Property ColumnForDB As IColumnsDB(Of String) Implements IObjectOfString.ColumnForDB
        Public Property ValidNumber As Boolean Implements IObjectOfString.ValidNumber
        Public Property ValidSymbols As Boolean Implements IObjectOfString.ValidSymbols
        Public Property ValidStrings As String() Implements IObjectOfString.ValidStrings
        Public Property ValidChars As Char() Implements IObjectOfString.ValidChars
        Public Property ExceptionChars As Char() Implements IObjectOfString.ExceptionChars
        Public Property Value As String Implements IHasValue(Of String).Value
            Get
                Return Str
            End Get
            Set(value As String)
                Dim Val As String
                If Cases = IObjectOfString.EnumsStringCase.Up Then
                    Val = value.ToUpper
                ElseIf Cases = IObjectOfString.EnumsStringCase.Down Then
                    Val = value.ToLower
                Else
                    Val = value
                End If

                ColumnForDB.Value = Val
            End Set
        End Property
        Public Property Cases As IObjectOfString.EnumsStringCase Implements IObjectOfString.Cases


        Sub New()
        End Sub

        Sub New(sValue As String, Optional OptionValidNumber As Boolean = False, Optional OptionValidSymbol As Boolean = False)
            ColumnForDB = New ColumnForDB(Of String)
            ValidNumber = OptionValidNumber
            ValidSymbols = OptionValidSymbol
            Value = sValue

        End Sub

    End Class

    Public Class ObjectOfInteger
        Implements ValueOfObject.Bases.IObjectOfInteger

        Public Property ColumnForDB As IColumnsDB(Of Integer) Implements IObjectOfInteger.ColumnForDB
        Public Property ValidStartEndDate As Boolean Implements IObjectOfInteger.ValidStartEndDate
        Public Property StartNumber As Integer? Implements IObjectOfInteger.StartNumber
        Public Property EndNumber As Integer? Implements IObjectOfInteger.EndNumber
        Public Property ValidNumberChars As Char() Implements IObjectOfInteger.ValidNumberChars
        Public Property Value As Integer Implements IHasValue(Of Integer).Value
        Sub New()
        End Sub
        Sub New(iValue As Integer, Optional OpStartNumber As Integer = Nothing, Optional OpEndNumber As Integer = Nothing)

            ColumnForDB = New ColumnForDB(Of Integer)
            Value = iValue
            StartNumber = OpStartNumber
            EndNumber = OpEndNumber
        End Sub

    End Class

    Public Class OBjectOfDate
        Implements Bases.IObjectOfDate

        Public Property ColumnForDB As IColumnsDB(Of Date) Implements IObjectOfDate.ColumnForDB
        Public Property FormatDate As String Implements IObjectOfDate.FormatDate
        Public Property StarDate As Date? Implements IObjectOfDate.StarDate
        Public Property EndDate As Date? Implements IObjectOfDate.EndDate
        Public Property ValidDate As Date() Implements IObjectOfDate.ValidDate
        Public Property Value As Date Implements IHasValue(Of Date).Value
        Public Property ValueF As Date Implements IObjectOfDate.ValueF

        Sub New()
        End Sub

        Sub New(dValue As Date, Optional opStartDate As Date = Nothing, Optional opEndDate As Date = Nothing)
            ColumnForDB = New ColumnForDB(Of Date)
            Value = dValue
            StarDate = opStartDate
            EndDate = opEndDate
        End Sub

    End Class

    Public Class ObjectOfBoolean
        Implements Bases.IObjectOfBoolean

        Public Property Column As IColumnsDB(Of Boolean) Implements IObjectOfBoolean.Column
        Public Property ValueF As String Implements IObjectOfBoolean.ValueF
        Public Property TypeFormatBool As String Implements IObjectOfBoolean.TypeFormatBool
        Public Property FormatBoolTrue As String Implements IObjectOfBoolean.FormatBoolTrue
        Public Property FormatBoolFalse As String Implements IObjectOfBoolean.FormatBoolFalse
        Public Property Value As Boolean Implements IHasValue(Of Boolean).Value
        Sub New()

        End Sub
        Sub New(bValue As Boolean, Optional FboolTrue As String = Nothing, Optional FboolFalse As String = Nothing)
            Column = New ColumnForDB(Of Boolean)
            Value = bValue
            FormatBoolTrue = FboolTrue
            FormatBoolFalse = FboolFalse
        End Sub
    End Class

    Public Class ObjectOfDouble
        Implements Bases.IObjectOfDouble

        Public Property Column As IColumnsDB(Of Double) Implements IObjectOfDouble.Column
        Public Property FormatDouble As String Implements IObjectOfDouble.FormatDouble
        Public Property StartNumber As Double Implements IObjectOfDouble.StartNumber
        Public Property EndNumber As Double Implements IObjectOfDouble.EndNumber
        Public Property ValidNumber As Double() Implements IObjectOfDouble.ValidNumber
        Public Property Value As Double Implements IHasValue(Of Double).Value
        Public Property ValueF As Double Implements IObjectOfDouble.ValueF

        Sub New()
        End Sub
        Sub New(dValue As Double, Optional OpStart As Double = Nothing, Optional opEnd As Double = Nothing)
            Column = New ColumnForDB(Of Double)
            Value = dValue
            StartNumber = OpStart
            EndNumber = opEnd
        End Sub
    End Class
End Namespace
