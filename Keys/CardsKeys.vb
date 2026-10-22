Namespace Keys.Cards
    Public Enum BankCardType
        Unknown = 0
        Debit = 1
        Credit = 2
        Prepaid = 3
        ATM = 4
        Charge = 5
    End Enum

    Public Interface IHasBankCardType
        Property CardType As BankCardType
    End Interface
    Public Interface IHasNumberCard
        Property NumberCard As String
    End Interface
    Public Interface IHasCVV
        Property CVV As Integer
    End Interface
    Public Interface IHasPIN
        Property PIN As Integer
    End Interface
    Public Interface IHasExpDate
        Property ExpDate As Date
    End Interface


End Namespace