Imports FoundationLibrary.Interfaces.Keys
Imports FoundationLibrary.Interfaces.ValMsg
Namespace Interfaces.Service
    ''' <summary>
    ''' <para>O service έλενχει αν επιτρέπεται να κανει καποια ενεργεια στην Βάση δεδομένων.</para>
    ''' <em>Για να λειτουργείσει ο Service και να επικοινωνηση με το Αποθετήριο θα πρέπει στην βάση Δεδομένων να υπαρχει το αντιστοιχο κλειδι <see cref="Interfaces.Keys.IHasPrimaryKey(Of T)"/></em>
    ''' </summary>
    ''' <typeparam name="Tkey">Τύπος PK</typeparam>
    ''' <typeparam name="TData">Data με αναφορα κλειδιου <see cref="Interfaces.Keys.IHasPrimaryKey(Of T)"/></typeparam>
    Public Interface IService(Of Tkey, TData As IHasPrimaryKey(Of Tkey))
        ''' <summary>
        ''' Κάνει έλενχο αν υπάρχει στο αποθετήριο η σηγκεκριμένη εγραφή και αν το επιτρέπεται να επιστραφή η εγραφή.
        ''' </summary>
        ''' <param name="Ref">Data</param>
        ''' <returns>Επιστρέφει <seealso cref="ValMsg.IValMsg(Of IModel)"/></returns>
        Function Exist(Ref As TData) As IValMsg(Of TData)
        ''' <summary>
        ''' ο Service κάνει έλενχο αν μπορει και αν επιτρέπεται να κανει εγραφή στο Αποθετήριο περνώντας τα δεδομένα απο το DTO.
        ''' </summary>
        ''' <typeparam name="DTO">Data Transfer Object</typeparam>
        ''' <param name="RegisterDTO">Register Data Transfer Object</param>
        ''' <returns>Επιστρέφει <seealso cref="IValMsg(Of IModel)"/></returns>
        Function Register(Of DTO)(RegisterDTO As DTO) As IValMsg(Of TData)
        ''' <summary>
        ''' ο Service κάνει έλενχο αμα μπορει και επιτρέπεται να να κανει καποια αλλαγή μεσα στα δεδομένα.
        ''' </summary>
        ''' <typeparam name="DTO"></typeparam>
        ''' <param name="Ref"></param>
        ''' <param name="ChangeDTO"></param>
        ''' <returns>Επιστρέφει <seealso cref="IValMsg"/></returns>
        Function Change(Of DTO)(Ref As TData, ChangeDTO As DTO) As IValMsg
        ''' <summary>
        ''' o Service Κανει ελενχο αν μπορει να διαγραφή η συγκεκριμένη εγραφή.
        ''' </summary>
        ''' <param name="Ref">DATA</param>
        ''' <returns>Επιστρέφει <seealso cref="IValMsg"/></returns>
        Function Remove(Ref As TData) As IValMsg
        ''' <summary>
        ''' o Service Ελέχνει αμα μπορει να δωσει όλες της εγραφες στον χρήστη.
        ''' </summary>
        ''' <returns>Επιστρέφει <seealso cref="IValMsg"/></returns>
        Function Get_All() As IValMsg(Of List(Of TData))
    End Interface
End Namespace
