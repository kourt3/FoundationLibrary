Imports FoundationLibrary.Interfaces.Keys

Namespace Interfaces.Repository
    ''' <summary>
    ''' <strong>To Αποθετήριο μιας βάση δεδομένων</strong><br/>
    ''' όλες οι εντολες που θα χρειάστεις για να κανεις ενα αποθετήριο βάση δεδομένων.
    ''' </summary>
    ''' <remarks><em>Σε ένα Αποθετήριο για την αναγνώριση,επιλογή και έλεγχο των δεδομένων σε μια βάση θα χρειαστεί σε ενα πεδιο των δεδομένων να ορήσεις <see cref="IHasPrimaryKey(Of T)"/></em></remarks>
    ''' <typeparam name="Tkey">Τον τύπο του PK(Primary Key)</typeparam>
    ''' <typeparam name="TEntity">Βάση Δεδομένων</typeparam>
    Public Interface IRepository(Of Tkey, TEntity As IHasPrimaryKey(Of Tkey))
        ''' <summary>
        ''' Δημιουργει ενα κλειδί για το πεδίο <see cref="IHasPrimaryKey(Of T).PrimaryKey"/>
        ''' </summary>
        ''' <returns>Την τιμή του κλειδίου</returns>
        Function GeneredID() As Tkey
        ''' <summary>
        ''' Δημιουργει και συμπληρώνει μια τιμή για το <see cref="IHasPrimaryKey(Of T).PrimaryKey">PK(Primary key)</see> και προσθέτει αυτόματα την <paramref name="Entity"/> στο αποθετήριο.
        ''' </summary>
        ''' <param name="Entity">Βάση δεδομένων</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function Create(Entity As TEntity) As Boolean
        ''' <summary>
        ''' Προσθέτει την <paramref name="Entity">Βάση δεδομένων</paramref> στο αποθετήριο.
        ''' </summary>
        ''' <example>
        ''' </example>
        ''' <param name="Entity">Βάση δεδομένων</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function Add(Entity As TEntity) As Boolean
        ''' <summary>
        ''' Βάζεις Χειροκίνητα το ID
        ''' </summary>
        ''' <param name="Entity">Βάση δεδομένον</param>
        ''' <param name="PK">Πεδίο του PK</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function TryCreate(Entity As TEntity, PK As Tkey) As Boolean
        ''' <summary>
        ''' 1) <inheritdoc cref="GeneredID()"/> Επιστρέφει την τιμή στο <paramref name="PK"/><br/>
        ''' 2) <inheritdoc cref="Add(TEntity)"/><br/>
        ''' </summary>
        ''' <param name="Entity">Βάση δεδομένον</param>
        ''' <param name="PK"> Πεδίο του PK</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function CreateAndReturnID(Entity As TEntity, ByRef PK As Tkey) As Boolean
        ''' <summary>
        ''' Μεσο του <paramref name="PK"/> αναζηταει στην λιστα που βρίσκεται το πεδιο και αντικατασταει τα δεδομένα μεσο του <paramref name="Entity"/>.
        ''' </summary>
        ''' <param name="PK">To ID τον δεδομένων.</param>
        ''' <param name="Entity">Τα καινούργια δεδομένα</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function Update(PK As Tkey, Entity As TEntity) As Boolean
        ''' <summary>
        ''' Μεσο του <paramref name="index"/> που βρίσκεται στην λίστα αντικατασταει τα δεδομένα μεσο του <paramref name="Entity"/>.
        ''' </summary>
        ''' <param name="index">Τον αριθμο της καταριθμημένης λίστας</param>
        ''' <param name="Entity">Τα καινούργια δεδομένα</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function UpdateAt(index As Integer, Entity As TEntity) As Boolean
        ''' <summary>
        ''' Μεσο του <paramref name="Match"/> Βρίσκει αμα τα δεδομένα ταιριαζουν μεταξή τους και τα αντικαταστάει με τον συνδεσμο [Deligate] <paramref name="Update"/>.
        ''' </summary>
        ''' <param name="Match"></param>
        ''' <param name="Update"></param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function UpdateWhere(Match As Predicate(Of TEntity), Update As Func(Of TEntity, TEntity)) As Boolean
        ''' <summary>
        ''' Βρίσκει ενα απο δεδομενα που πέρασες μεσο <paramref name="Entity"/> αν τερίαζουν και τα διαγράφει.
        ''' </summary>
        ''' <param name="Entity">Δεδομένα</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function Delete(Entity As TEntity) As Boolean
        ''' <summary>
        ''' Βρίσκει το <paramref name="PK"/> του πεδιου σε μια λιστά δεδομένων και διαγραφει τα δεδομένα.
        ''' </summary>
        ''' <param name="PK">Το πεδίο PK</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function Delete(PK As Tkey) As Boolean
        ''' <summary>
        ''' Πηγαίνει στον αριθμό μεσο του <paramref name="Index"/> της καταριθμημενης λιστας  και διαγράφει τα δεδομένα της επιλογής.
        ''' </summary>
        ''' <param name="Index">Ο αριθμός επιλογης της καταριθμημενης λίστας.</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function DeleteAt(Index As Integer) As Boolean

        ''' <summary>
        ''' Αναζητάει την αντιστήχηση τον δεδομένον μεσο του <paramref name="Match"/> και διαγράφει τα δεδομένα αν αυτο ειναι εφικτο.
        ''' </summary>
        ''' <param name="Match">Αντιστήχηση δεδομένον</param>
        ''' <returns>Αν εκτελέστηκε με επιτυχία</returns>
        Function DeleteWhere(Match As Predicate(Of TEntity)) As Boolean
        ''' <summary>
        ''' Επιλέγει ολα τα δεδομένα.
        ''' </summary>
        ''' <returns>τα δεδομένα που επιλέχτηκαν.</returns>
        Function Read_All() As List(Of TEntity)
        ''' <summary>
        ''' Επιλέγει το δεδομένο που περιεχει το ιδιο πεδιο με <paramref name="PK"/>.
        ''' </summary>
        ''' <param name="PK">Το Πεδιο του PK</param>
        ''' <returns>τα δεδομένα που επιλέκτηκαν.</returns>
        Function Read_Item(PK As Tkey) As TEntity
        ''' <summary>
        ''' Επιλέγει τα δεδομενα με τον αριθμο που καταμετρήθηκε στην αριθμημενη λιστα μεσο του <paramref name="Index"/>
        ''' </summary>
        ''' <param name="Index">O Αριθμος της καταμέτρησης στην αριθμημενης λίστας.</param>
        ''' <returns>τα δεδομένα που επιλέκτηκαν.</returns>
        Function Read_ItemAt(Index As Integer) As TEntity
        ''' <summary>
        ''' Ελέγχει αν τον <paramref name="PK"/> Υπάρχει στην λίστα.
        ''' </summary>
        ''' <param name="PK">Το PK της λίστας.</param>
        ''' <returns>Αν Βρέθηκε στην λίστα.</returns>
        Function Exist(PK As Tkey) As Boolean
        ''' <summary>
        ''' Ελέγχει αν καποιο απο την λίστα πληρη ολα τα κριτίρια μεσο <paramref name="Creteria"/>.
        ''' </summary>
        ''' <typeparam name="TCreteria">Τον δεδομένα τον κριτιριον.</typeparam>
        ''' <param name="Creteria">Τα κριτίρια</param>
        ''' <returns>Αν βρέθηκαν τα Κριτίρια στην λιστα δεδομένων</returns>
        Function Exist(Of TCreteria)(Creteria As TCreteria) As Boolean
        ''' <summary>
        ''' Ελέγχει αν καποιο απο την λίστα πλήρη ολα τα κριτιρια μεσο του <paramref name="Match"/>
        ''' </summary>
        ''' <param name="Match">[Deligate] Κριτίρια</param>
        ''' <returns>Αν βρέθηκαν τα Κριτίρια στην λιστα δεδομένων</returns>
        Function Exist(Match As Predicate(Of TEntity)) As Boolean
        ''' <summary>
        ''' Eπιλέγει <b>ένα απο τα Δεδομενα της λιστας</b> εφώσον πληρη τα κριτιρια μεσο <paramref name="Creteria"/>.
        ''' </summary>
        ''' <typeparam name="TCreteria">Τον δεδομένα τον κριτιριον.</typeparam>
        ''' <param name="Creteria">Τα κριτίρια</param>
        ''' <returns>Τα επιλεγμένα δεδομένα μεσα απο την λίστα δεδομένον.</returns>
        Function Find(Of TCreteria)(Creteria As TCreteria) As TEntity
        ''' <summary>
        ''' Eπιλέγει <b>ενα απο τα Δεδομενα της λιστας</b> εφώσον πληρη τα κριτιρια μεσο <paramref name="Match"/>.
        ''' </summary>
        ''' <param name="Match">Τα κριτίτα μεσο Delegate</param>
        ''' <returns>Τα επιλεγμένα δεδομένα μεσα απο την λίστα δεδομένον.</returns>
        Function Find(Match As Predicate(Of TEntity)) As TEntity
        ''' <summary>
        ''' Επιλέγει <b>όλα τα Δεδομένα της λίστας</b> εφώσον πληρουν τα κριτιρια μεσο <paramref name="Creteria"/>.
        ''' </summary>
        ''' <typeparam name="TCreteria">Τον δεδομένα τον κριτιριον.</typeparam>
        ''' <param name="Creteria">Τα κριτιρια.</param>
        ''' <returns>Τα επιλεγμένα δεδομένα μεσα απο την λίστα δεδομένον.</returns>
        Function Search(Of TCreteria)(Creteria As TCreteria) As List(Of TEntity)

        ''' <summary>
        ''' Επιλέγει <b>όλα τα Δεδομένα της λίστας</b> εφώσον πληρουν τα κριτιρια μεσο <paramref name="Matches"/>.
        ''' </summary>
        ''' <param name="Matches">Τα κριτιρια μεσο Deligate.</param>
        ''' <returns>Τα επιλεγμένα δεδομένα μεσα απο την λίστα δεδομένον.</returns>
        Function Search(Matches As Predicate(Of TEntity)) As List(Of TEntity)
        ''' <summary>
        ''' Διαγράφη ολα τα δεδομένα της λίστας δεδομένων.
        ''' </summary>
        Sub RemoveAll()
    End Interface
End Namespace

