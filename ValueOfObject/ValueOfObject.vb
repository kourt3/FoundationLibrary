Imports FoundationLibrary.Interfaces.Keys
Imports FoundationLibrary.ValueOfObject.Bases
Imports FoundationLibrary.Interfaces.Validation.Structures

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
        Implements IObjectOfString, IHasColumnDB(Of IColumnsDB(Of String)), IHasValue(Of String)

        Private Str As String

        Public Property ColumnForDB As IColumnsDB(Of String) Implements IHasColumnDB(Of IColumnsDB(Of String)).ColumnDB
        Public Property MinLength As Integer Implements IObjectOfString.MinLength
        Public Property MaxLength As Integer Implements IObjectOfString.MaxLength
        Public Property AvailableWhiteSpace As Boolean Implements IObjectOfString.AvailableWhiteSpace
        Public Property AvailableNothin As Boolean Implements IObjectOfString.AvailableNothin
        Public Property ValidNumber As Boolean Implements IObjectOfString.ValidNumber
        Public Property ValidSymbols As Boolean Implements IObjectOfString.ValidSymbols
        Public Property ValidStrings As String() Implements IObjectOfString.ValidStrings
        Public Property ValidChars As Char() Implements IObjectOfString.ValidChars
        Public Property ExceptionChars As Char() Implements IObjectOfString.ExceptionChars
        Public Property Cases As IObjectOfString.EnumsStringCase Implements IObjectOfString.Cases
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
                If ValidNumber = True Then
                    For i = 0 To Val.Length - 1
                        If Char.IsDigit(Val(i)) Then
                            If ExceptionChars.Contains(Val(i)) = False Then
                                Throw New Exception("Δεν μπορει να περιέχει αριθμό.")
                            End If
                        End If
                    Next
                End If
                If ValidSymbols = True Then
                    For i = 0 To Val.Length - 1
                        If Char.IsSymbol(Val(i)) Then
                            If ExceptionChars.Contains(Val(i)) = False Then
                                Throw New Exception("Δεν μπορει να περιέχει Σύμβολο.")
                            End If
                        End If
                    Next
                End If
                If ValidStrings IsNot Nothing AndAlso ValidStrings.Count > 0 Then
                    For i = 0 To ValidStrings.Count - 1
                        If Val.Contains(ValidStrings(i)) Then
                            Throw New Exception("Δεν επιτρέπονται οι συλαβες." & ValidStrings.ToList.ToString)
                        End If
                    Next
                End If
                If ValidChars IsNot Nothing AndAlso ValidChars.Count > 0 Then
                    For i = 0 To ValidChars.Count - 1
                        If Val.Contains(ValidChars(i)) Then
                            Throw New Exception("Δεν Επιτρέπονται οι Χαρακτήρες." & ValidChars.ToList.ToString)
                        End If
                    Next
                End If
                Str = Val
            End Set
        End Property



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
        Implements IObjectOfInteger, IHasValue(Of Integer), IHasColumnDB(Of IColumnsDB(Of Integer))

        Private Str As Integer
        Public Property ColumnForDB As IColumnsDB(Of Integer) Implements IHasColumnDB(Of IColumnsDB(Of Integer)).ColumnDB
        Public Property StartNumber As Integer? Implements IObjectOfInteger.StartNumber
        Public Property EndNumber As Integer? Implements IObjectOfInteger.EndNumber
        Public Property ValidNumberChars As Integer() Implements IObjectOfInteger.ValidNumberChars
        Public Property Value As Integer Implements IHasValue(Of Integer).Value
            Get
                Return Str
            End Get
            Set(value As Integer)
                If value < StartNumber Then
                    If ValidNumberChars.Contains(value) = False Then
                        Throw New Exception("Δεν επιτρέπεται μικρότερος αριθμος από : " & StartNumber)
                    End If
                End If
                If value > EndNumber Then
                    If ValidNumberChars.Contains(value) = False Then
                        Throw New Exception("Δεν επιτρέπεται μεγαλύτερος αριθμός από: " & EndNumber)
                    End If
                End If
                Str = value
            End Set
        End Property
        Sub New()
        End Sub
        Sub New(iValue As Integer, Optional OpStartNumber As Integer? = Nothing, Optional OpEndNumber As Integer? = Nothing)

            ColumnForDB = New ColumnForDB(Of Integer)
            Value = iValue
            StartNumber = OpStartNumber
            EndNumber = OpEndNumber
        End Sub

    End Class

    Public Class OBjectOfDate
        Implements IObjectOfDate, IHasValue(Of Date), IHasColumnDB(Of IColumnsDB(Of Date)), IHasValueF(Of Date)

        Private Str As Date

        Public Property ColumnForDB As IColumnsDB(Of Date) Implements IHasColumnDB(Of IColumnsDB(Of Date)).ColumnDB
        Public Property FormatDate As String Implements IObjectOfDate.FormatDate
        Public Property StarDate As Date? Implements IObjectOfDate.StarDate
        Public Property EndDate As Date? Implements IObjectOfDate.EndDate
        Public Property ValidDate As Date() Implements IObjectOfDate.ValidDate
        Public Property Value As Date Implements IHasValue(Of Date).Value
            Get
                Return Str
            End Get
            Set(value As Date)
                If value < StarDate Then
                    If ValidDate.Contains(value) Then
                        Throw New Exception("Δεν επιτρέπεται η ημερομμηνια να ειναι μικρότερη απο: " & StarDate)
                    End If
                End If
                If value > EndDate Then
                    If ValidDate.Contains(value) Then
                        Throw New Exception("Δεν επιτρέπεται η ημερομμηνια να ειναι μεγαλύτερη απο: " & EndDate)
                    End If
                End If
                Str = value
            End Set
        End Property

        Public Property ValueF As Date Implements IHasValueF(Of Date).ValueF

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
        Implements IObjectOfBoolean, IHasValue(Of Boolean), IHasColumnDB(Of IColumnsDB(Of Boolean)), IHasValueF(Of String)

        Public Property Column As IColumnsDB(Of Boolean) Implements IHasColumnDB(Of IColumnsDB(Of Boolean)).ColumnDB
        Public Property TypeFormatBool As String Implements IObjectOfBoolean.TypeFormatBool
        Public Property FormatBoolTrue As String Implements IObjectOfBoolean.FormatBoolTrue
        Public Property FormatBoolFalse As String Implements IObjectOfBoolean.FormatBoolFalse
        Public Property Value As Boolean Implements IHasValue(Of Boolean).Value
        Public Property ValueF As String Implements IHasValueF(Of String).ValueF
            Get
                If Value = True Then
                    Return FormatBoolTrue
                Else
                    Return FormatBoolFalse
                End If
            End Get
            Set(value As String)
                If value = FormatBoolTrue Then
                    Me.Value = True
                ElseIf value = FormatBoolFalse Then
                    Me.Value = False
                Else
                    Me.Value = value
                End If
            End Set
        End Property
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
        Implements IObjectOfDouble, IHasValue(Of Double), IHasValueF(Of Double), IHasColumnDB(Of IColumnsDB(Of Double))

        Public Property Column As IColumnsDB(Of Double) Implements IHasColumnDB(Of IColumnsDB(Of Double)).ColumnDB
        Public Property FormatDouble As String Implements IObjectOfDouble.FormatDouble
        Public Property StartNumber As Double Implements IObjectOfDouble.StartNumber
        Public Property EndNumber As Double Implements IObjectOfDouble.EndNumber
        Public Property ValidNumber As Double() Implements IObjectOfDouble.ValidNumber
        Public Property Value As Double Implements IHasValue(Of Double).Value
        Public Property ValueF As Double Implements IHasValueF(Of Double).ValueF

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
