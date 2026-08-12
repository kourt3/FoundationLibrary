Namespace ObjectOfValue.Bases
    Public Interface IColumnsDB(Of T)
        Inherits Interfaces.Keys.IHasValue(Of T)
        Property Column As String
        Property IndexOfColumn As Integer
        Property Type As String
        Property Format As String

    End Interface
    Public Interface IObjectOfString
        Inherits Interfaces.Keys.IHasValue(Of String)
        Enum EnumsStringCase
            None
            Up
            Down
        End Enum
        Property ColumnForDB As IColumnsDB(Of String)
        Property Cases As EnumsStringCase
        Property ValidNumber As Boolean
        Property ValidSymbols As Boolean
        Property ValidStrings As String()
        Property ValidChars As Char()
        Property ExceptionChars As Char()
    End Interface

    Public Interface IObjectOfInteger
        Inherits Interfaces.Keys.IHasValue(Of Integer)
        Property ColumnForDB As IColumnsDB(Of Integer)

        Property ValidStartEndDate As Boolean
        Property StartNumber As Integer?
        Property EndNumber As Integer?
        Property ValidNumberChars As Char()

    End Interface

    Public Interface IObjectOfDate

        Inherits Interfaces.Keys.IHasValue(Of Date)
        Property ColumnForDB As IColumnsDB(Of Date)

        Property ValueF As Date
        Property FormatDate As String
        Property StarDate As Date?
        Property EndDate As Date?
        Property ValidDate As Date()
    End Interface

    Public Interface IObjectOfBoolean
        Inherits Interfaces.Keys.IHasValue(Of Boolean)
        Property Column As IColumnsDB(Of Boolean)

        Property ValueF As String
        Property TypeFormatBool As String
        Property FormatBoolTrue As String
        Property FormatBoolFalse As String

    End Interface

    Public Interface IObjectOfDouble
        Inherits Interfaces.Keys.IHasValue(Of Double)
        Property Column As IColumnsDB(Of Double)

        Property ValueF As Double
        Property FormatDouble As String
        Property StartNumber As Double
        Property EndNumber As Double
        Property ValidNumber As Double()

    End Interface
End Namespace
