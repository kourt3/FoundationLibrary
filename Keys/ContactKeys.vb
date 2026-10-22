Namespace Keys.Contacts
    Public Interface IHasPhone(Of TKey)
        Property Phone As TKey
    End Interface
    Public Interface IHasEmail(Of TKey)
        Property Email As TKey
    End Interface
    Public Interface IHasDiscord(Of TKey)
        Property Discord As TKey
    End Interface
    Public Interface IHasFacebook(Of TKey)
        Property Facebook As TKey
    End Interface
    Public Interface IHasInstagram(Of Tkey)
        Property Instagram As Tkey
    End Interface
    Public Interface IHasTwitter(Of TKey)
        Property Twitter As TKey
    End Interface
    Public Interface IHasReddit(Of Tkey)
        Property Reddit As Tkey
    End Interface
    Public Interface IHasTwitch(Of Tkey)
        Property Twitch As Tkey
    End Interface

End Namespace