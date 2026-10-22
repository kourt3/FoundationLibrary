Imports FoundationLibrary.Errors
Namespace Validation.Types
    Public Interface ICheckerKey(Of TType)
        Function Check(Value As TType, Optional NameObj As String = Nothing) As Results.IErrResult(Of List(Of IErrors))
    End Interface


    Public Interface IValidString
        Inherits ICheckerKey(Of String)

        Enum EnumsStringCase
            None
            Up
            Down
        End Enum
        Property Cases As EnumsStringCase
        Property MinLength As Integer?
        Property MaxLength As Integer?
        Property AvailableWhiteSpace As Boolean
        Property AvailableNothin As Boolean
        Property ValidNumber As Boolean
        Property ValidSymbols As Boolean
        Property ValidStrings As String()
        Property ValidChars As Char()
        Property ExceptionChars As Char()


    End Interface

    Public Interface IValidInteger
        Inherits ICheckerKey(Of Integer)

        Property StartNumber As Integer?
        Property EndNumber As Integer?
        Property ValidNumberChars As Integer()


    End Interface

    Public Interface IValidDate
        Inherits ICheckerKey(Of Date)

        Property FormatDate As String
        Property StarDate As Date?
        Property EndDate As Date?
        Property ExceptionsDate As Date()


    End Interface


    Public Interface IValidBoolean
        Inherits ICheckerKey(Of Boolean)
        Property TypeFormatBool As String
        Property FormatBoolTrue As String
        Property FormatBoolFalse As String


    End Interface


    Public Interface ITypeDouble
        Inherits ICheckerKey(Of Double)
        Property FormatDouble As String
        Property StartNumber As Double?
        Property EndNumber As Double?
        Property ValidNumber As Double()

    End Interface

End Namespace

