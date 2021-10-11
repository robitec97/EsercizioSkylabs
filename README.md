# EsercizioSkylabs
Soluzione esercizio backend per Roberto Pillitteri implementata in Asp .Net Core 5

Nella cartella Models sono presenti due classi Records che è mappata direttamente sulla tabella records presente nel db e RecordsDenormalized che è mappata con la view
creata nel db per evitare di fare la query con tante join e rendere il tutto più leggibile. In particolare RecordsDenormalized ritorna il dato denormalizzato.

Nella cartella Repositories viene creata un'interfaccia e poi implementantata IRecordsRepository e RecordsRepository in modo da esporre in maniera chiara i metodi che possono
essere eseguiti sul dbcontext.
Ci sono due controller RecordsController che espone /records per il download in csv di tutti i record denormalizzati e /record/{count}/{offset} per il ritorno di un tot di record
denormalizzati, essendo questi ultimi già ordinati per id la paginazione viene facile da realizzare.

StatsController che espone la route /stats/{aggregationType}/{aggregationFilter} che ritorna le statistiche secondo documentazione, eseguendo delle query tramite LINQ sul dbcontext
di entityframework, per questo è stato necessario mappare anche Records, e che mette i dati in una classe di appoggio Stats e ritorna tutto.

NB: Utilizzare il Db già presente nella cartella e non quello fornito originariamente in quanto non dispone della vista.
E' possibile anche trovare il file "Soluzioni Pillitteri.pdf" dove vi sono le mie risposte agli esercizi teorici (e risposte alle domande).

Nuget Packes utilizzati: 
- Microsoft.EntityFrameworkCore.Sqlite
- CsvHelper
