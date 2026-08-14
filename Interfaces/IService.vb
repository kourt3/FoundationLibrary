Imports FoundationLibrary.Interfaces.Keys
Imports FoundationLibrary.Interfaces.ValMsg
Namespace Interfaces.Service
    ''' <summary>
    ''' Τα βασικά κλειδια που θα χρειαστεις για να διμιουργήσεις Service
    ''' </summary>
    ''' <typeparam name="TRef">Η αναγνώρηση του κλιδειου(PK)</typeparam>
    ''' <typeparam name="TReturn">Τι να επιστρέψει μεσο του <seealso cref="IvalMsg(Of TReturn)"/></typeparam>
    Public Interface IKeysServices(Of TRef, TReturn)
        ''' <summary>
        ''' Κάνει έλενχο αν υπάρχει στο αποθετήριο η σηγκεκριμένη εγραφή και αν το επιτρέπεται να επιστραφή η εγραφή.
        ''' </summary>
        ''' <param name="Ref">Data</param>
        ''' <returns>Επιστρέφει <seealso cref="ValMsg.IValMsg(Of TReturn)"/></returns>
        Function Exist(Ref As TRef) As IValMsg(Of TReturn)
        ''' <summary>
        ''' ο Service κάνει έλενχο αν μπορει και αν επιτρέπεται να κανει εγραφή στο Αποθετήριο περνώντας τα δεδομένα απο το DTO.
        ''' </summary>
        ''' <typeparam name="DTO">Data Transfer Object</typeparam>
        ''' <param name="RegisterDTO">Register Data Transfer Object</param>
        ''' <returns>Επιστρέφει <seealso cref="IValMsg(Of TReturn)"/></returns>
        Function Register(Of DTO)(RegisterDTO As DTO) As IValMsg(Of TReturn)
        ''' <summary>
        ''' ο Service κάνει έλενχο αμα μπορει και επιτρέπεται να να κανει καποια αλλαγή μεσα στα δεδομένα.
        ''' </summary>
        ''' <typeparam name="DTO"></typeparam>
        ''' <param name="Ref"></param>
        ''' <param name="ChangeDTO"></param>
        ''' <returns>Επιστρέφει <seealso cref="IValMsg"/></returns>
        Function Change(Of DTO)(Ref As TRef, ChangeDTO As DTO) As IValMsg
        ''' <summary>
        ''' o Service Κανει ελενχο αν μπορει να διαγραφή η συγκεκριμένη εγραφή.
        ''' </summary>
        ''' <param name="Ref">DATA</param>
        ''' <returns>Επιστρέφει <seealso cref="IValMsg"/></returns>
        Function Remove(Ref As TRef) As IValMsg
        ''' <summary>
        ''' o Service Ελέχνει αμα μπορει να δωσει όλες της εγραφες στον χρήστη.
        ''' </summary>
        ''' <returns>Επιστρέφει <seealso cref="IValMsg(Of List(Of TReturn))"/></returns>
        Function Get_All() As IValMsg(Of List(Of TReturn))

    End Interface


    ''' <summary>
    ''' <Title>Service που Επιστρέφει Model</Title>
    ''' <para>O service έλενχει αν επιτρέπεται να κανει καποια ενεργεια στην Βάση δεδομένων.</para>
    ''' </summary>
    ''' <typeparam name="TModel">Model</typeparam>
    ''' <typeparam name="TData">Data</typeparam>
    Public Interface IService(Of TData, TModel)
        Inherits IKeysServices(Of TData, TModel)
    End Interface

    ''' <summary>
    ''' <Title>Service που Επιστρέφει το ιδιο Entity</Title>
    ''' <para>O service έλενχει αν επιτρέπεται να κανει καποια ενεργεια στην Βάση δεδομένων.</para>
    ''' </summary>
    ''' <typeparam name="TData">Data"/></typeparam>
    Public Interface IService(Of TData)
        Inherits IKeysServices(Of TData, TData)
    End Interface
End Namespace
