Namespace Keys.Address
    Public Interface ICountry(Of TKey)
        Property Country As TKey
    End Interface

    Public Interface IRegion(Of TKey)
        Property Region As TKey
    End Interface

    Public Interface IRegionalUnit(Of TKey)
        Property RegionalUnit As TKey
    End Interface

    Public Interface IPostalCode(Of TKey)
        Property PostalCodeID As TKey
    End Interface

    Public Interface IMunicipality(Of TKey)
        Property Municipality As TKey
    End Interface

    Public Interface IAddress(Of TKey)
        Property Address As TKey
    End Interface

    Public Interface IStreetNumber(Of TKey)
        Property StreetNumber As TKey
    End Interface

    Public Interface IHasFullAddress
        ReadOnly Property FullAddress As String
    End Interface
End Namespace

