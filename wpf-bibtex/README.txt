- Solūcijas mapē iekopēju teksta failu ar uzdevuma nosacījumiem; ar katru ierakstu git sistēmā tiek arī izdzēsti nosacījumi, kas ar šo ierakstu ir izpildīti - ērti var redzēt git ierakstu vēsturē

======================================= TODO:
- pievienot jaunus bibliogrāfiskos vienumus
- rediģēt esošus
- ielasīt bibliogrāfiskos vienumus no BibTex faila
- eksportēt vienumus BibTeX failā

no https://en.wikipedia.org/wiki/BibTeX jāatbalsta: 
book, 
masterthesis, 
phdthesis,
article

Mājas darbā jāatbalsta tie BibTex vienumu lauki, kas atbilst zemāk minētajiem klašu laukiem.
Pārejos drīkst ignorēt (bet programma nedrīkst nosprāgt ar tādiem saskaroties.)


Izveidot iespēju norādīt bibliogrāfiskā vienuma Autoru/Autorus. Šeit Jūs paši varat izvēlēties: kā norādīt Autoru un/vai Autorus, kādus datu tipus izvēlēties, kur norādīt autorus virsklasē vai apakšklasēs utt.
Izveidot virtuālu (virtual) metodi: “Izdrukat()”, kas atgriež visu īpašību vērtības kā BibTeX tekstu.


2. Izveidot klasei „ Bibliogrāfiskais vienums” apakšklasi „Grāmata”
Grāmatai papildus jāvar norādīt “izdevēju”, “izdevēja adresi”;
Grāmatai var būt viens vai vairāki Autori;
Izveidot konstruktoru, kas saņem sekojošus parametrus:
string “autori” (Ar komatiem atdalīts autoru saraksts, var pieņemt, ka autoram ir vārds un uzvārds, kas ir atdalīts ar atstarpēm, piemēram “Paul Deitel, Harvey Deitel”);
string “nosaukums”;
string “izdevnieciba”;
int “gads”;
string “iIzdevniecības adrese”; (var arī nenorādīt)
Pārdefinēt metodi: “Izdrukat()”, kas atgriež visu īpašību vērtības kā BibTeX tekstu.

3. Izveidot pārskaitāmo tipu (Enum) “Noslēguma darba veids” ar vērtībām: “Maģistra darbs”, “Doktora disertācija”. Ja vēlaties varat pievienot arī citas pārskaitāmā tipa vērtības, piemēram, “Kvalifikācijas darbs”.

4. Izveidot klasei „Bibliogrāfiskais vienums” apakšklasi „Noslēguma darbs”
Noslēguma darbam papildus jāvar norādīt “Noslēguma darba veidu” 
(Jūsu definētais pārskaitāmais tips (Enum)), “izglītības iestādi”;
Noslēguma darbam var būt tikai viens autors;
Izveidot konstruktoru, kas saņem sekojošus parametrus:
string “autora vārds”;
string “autora uzvārds”
string “nosaukums”;
EnumXXX “noslēguma darba veids”; (Tips ir Jūsu definētais pārskaitāmais tips)
string “izglītības iestādes nosaukums”;
int “gads”;
Pārdefinēt metodi: “Izdrukat()”, kas atgriež visu īpašību vērtības kā BibTeX tekstu. Ņemiet vērā, ka atkarībā no noslēguma darba veida mainās arī BibTeX vienuma veids, attiecīgi masterthesis vai phdthesis.


5.  Papildus:
 Izveidot Jūsu izvēlētajam (vēl vienam) bibliogrāfiskā vienuma veidam un autoru apstrādei atbilstošas klases ar atbilstošiem atribūtiem, īpašībām un metodēm.
 Ja nepieciešams, pēc saviem ieskatiem varat veidot vēl citas klases un iepriekš minētās (1.,2.,4. punktā minētās) papildināt ar jauniem laukiem, īpašībām un metodēm.
 Izveidot vienu statisku (static) lauku (field) un statisku (static) metodi (method);

6. Izveidot globālu(as) kolekciju(as) vai masīvu(s) (collection vai array), kas saturētu “Bibliogrāfiskos vienumus”.
Nodrošināt izveidoto “Bibliogrāfisko vienumu” pievienošanu kolekcijai(ām)/masīvam(iem).

7.Izveidot lietotni (application) ar lietotāja interfeisu (user interface) un funkcionalitāti:
Jauna bibliogrāfiskā vienuma izveidei;
Izvēlēta bibliogrāfiskā vienuma datu apskatei un arī rediģēšanai; (Izvēle var notikt, piemēram, norādot ieraksta kārtas numuru kolekcijā.)
Kolekcijās (masīvos) (skat. 6. punktu) esošo datu saglabāšanai BibTeX  failā. (Ja fails atrodas mapē „C:\Temp\”, tad faila vārdu var „iešūt” kodā. Protams, var arī lietotājam prasīt norādīt faila vārdu.) ;
Kolekcijas datu ielasīšanu no BibTeX teksta faila. (Faila vārdu var “iešūt” kodā, skat. iepriekšējo punktu.) Jāvar ielasīt piemērā doto BibTeX failu (vai līdzīgs) un Jūsu programmas veidotos BibTeX failus (skat. iepriekšējo punktu);

8. Lietotnē: 
Jāveido darba virsmas lietotne (desktop application) (var izmantot WPF vai Windows Forms)
Jālieto vismaz 4 dažādi vadīklu(kontroļu) veidi.
Jālieto ievadāmajiem datiem atbilstošas vadīklas (kontroļi).
Lietotāja saskarnei jābūt sakārtotai: vadīklām(kontroļiem) jābūt izlīdzinātiem, ar vienādām atstarpēm. Līdzīgā vadiklās (kontroļiem) jābūt ar vienādiem izmēriem.
Jālieto gan modālā (modal), gan nemodālā formu atvēršana.
Kodā nodemonstrēt visu klašu metožu izsaukumus un īpašību uzstādīšanu.

P.S.  Pēdiņās norādītajiem lauku, klašu utt. nosaukumiem ir tikai informatīvs raksturs, drīkst dot citus nosaukumus, bet tiem jābūt saprotamiem bez papildus komentāriem. Tāpēc ieteicams atstāt esošos nosaukumus aizstājot atstarpes ar pasvītrojumu, bet mīkstos un garos  burtus ar tādiem pašiem latīņu alfabēta burtiem.

P.S2. Var pieņemt, ka BibTeX lauki nesatur speciālos simbolus (vienīgais izņēmumi: komats autoru laukā, kas atdala vairākus autorus vienu no otra un punkti datuma laukā) t.i. pārējo (izņēmums autori un datums) lauku vērtības satur tikai burtus, ciparus un atstarpes.

BibTex faila piemērs:

@BOOK{RattzFreeman2010,
  title = {Pro LINQ  Language Integrated Query in C 2010},
  publisher = {Apress},
  year = {2010},
  author = {Joeseph Rattz, Adam Freeman},
  address = {New York},
  owner = {User},
  timestamp = {2015.09.25}
}
 
@BOOK{Johnson2012,
  title = {Professional Visual Studio 2012},
  publisher = {John Wiley and Sons},
  year = {2012},
  author = {Bruce Johnson},
  owner = {User},
  timestamp = {2015.09.25}
}
 
@PHDTHESIS{Kalnina2011,
  author = {Elina Kalnina},
  title = {MODEL TRANSFORMATION DEVELOPMENT USING MOLA MAPPINGS AND TEMPLATE
                MOLA},
  school = {University of Latvia},
  year = {2011},
  owner = {User},
  timestamp = {2015.09.25}
}
 
@MASTERSTHESIS{Apse2015,
  author = {Nils Apse},
  title = {Mans darbs},
  school = {University of Latvia},
  year = {2015},
  owner = {User},
  timestamp = {2015.09.25}
}
 
@BOOK{DeitelDeitel2014,
  title = {Visual C 2012 How to Program},
  publisher = {Prentice Hall},
  year = {2014},
  author = {Paul Deitel, Harvey Deitel},
  edition = {5},
  owner = {User},
  timestamp = {2015.09.25}
}
 
@BOOK{Sharp2013,
  title = {Microsoft Visual C 2012 Step by Step},
  publisher = {Microsoft Press},
  year = {2013},
  author = {John Sharp},
  address = {Redmond WA},
  owner = {User},
  timestamp = {2015.09.25}
}