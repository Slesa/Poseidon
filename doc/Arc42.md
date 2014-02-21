#Arc 42 Template


## Einführung und Zielsetzung
(engl.: Introduction and Goals) Als Einführung in das Architekturdokument gehören hierher die treibenden Kräfte, die Software-Architekten bei Ihren Entscheidungen berücksichtigen müssen: Einerseits die Erfüllung bestimmter fachlicher Aufgabenstellungen der Stakeholder, darüber hinaus aber die Erfüllung oder Einhaltung der vorgegebenen Randbedingungen (required constraints) unter Berücksichtigung der Architekturziele.


### Aufgabenstellung
(engl.: Requirements Overview) Kurzbeschreibung der fachlichen Aufgabenstellung, Extrakt (oder Abstract) der Anforderungsdokumente. Verweis auf ausführliche Anforderungsdokumente (mit Versionsbezeichnungen und Ablageorten). Eine kompakte Zusammenfassung des fachlichen Umfelds des Systems. Beantwortet (etwa) folgende Fragen:

- Was geschieht im Umfeld des Systems?
- Warum soll es das System geben? Was macht das System wertvoll oder wichtig? Welche Probleme löst das System?

Aus Sicht der späteren Nutzer ist die Unterstützung einer fachlichen Aufgaben der eigentliche Beweggrund, ein neues (oder modifiziertes) System zu schaffen. Obwohl die Qualität der Architektur oft eher an der Erfüllung von nicht-funktionalen Anforderungen hängt, darf diese wesentliche Architekturtreiber nicht vernachlässigt werden. Kurze textuelle Beschreibung, eventuell in tabellarischer Use-Case Form. In jedem Fall sollte der fachliche Kontext Verweise auf die entsprechenden Anforderungsdokumente enthalten. Kurzbeschreibung der wichtigsten:

- Geschäftsprozessen,
- funktionalen Anforderungen,
- nichtfunktionalen Anforderungen und andere Randbedingungen (die wesentlichen müssen bereits als Architekturziele formuliert sein oder tauchen als Randbedingungen auf) oder
- Mengengerüste.
- Hintergründe Hier können Sie aus den Anforderungsdokumenten wiederverwenden - halten Sie diese Auszüge so knapp wie möglich und wägen Sie Lesbarkeit und Redundanzfreiheit gegeneinander ab.


### Qualitätsziele
(engl.: Quality Goals) Die Hitparade (Top-3 oder Top-5) der Architekturziele und/oder Randbedingungen, deren Erfüllung oder Einhaltung den maßgeblichen Stakeholdern besonders wichtig sind. Gemeint sind hier wirklich Architekturziele, nicht die Ziele des Projekts. Beachten Sie den Unterschied. Qualitätsziele könnten beispielsweise sein:

- Verfügbarkeit (availability)
- Änderbarkeit (modifiability)
- Performanz (performance)
- Sicherheit (security)
- Testbarkeit (testability)
- Bedienbarkeit (usability)

Wenn Sie als Architekt nicht wissen, woran Ihre Arbeit gemessen wird, können Sie während der Entwicklung kaum bestimmen, ob Ihre Lösung bereits gut genug ist oder nicht...

Mittel: Einfache tabellarische Darstellung, geordnet nach Prioritäten

Beginnen Sie NIEMALS mit einer Architekturentwicklung, wenn diese Ziele nicht schriftlich festgelegt und von den maßgeblichen Stakeholdern akzeptiert sind.

Quellen: Im DIN/ISO 9126 Standard finden Sie eine umfangreiche Sammlung möglicher Qualitätsziele. Für alle, die es nicht so genau wissen wollen: ein lesbarer Auszug davon ist im Buch "Agile Software- Entwicklung für Embedded Real-Time Systems mit der UML" (Hruschka, Rupp, Carl- Hanser-Verlag, 2002 auf Seite 9 zu finden.

Die Details zu diesem Abschnitt stehen in Kapitel 10 (Bewertungsszenarien).	


### Stakeholder
Eine Liste der wichtigsten Personen oder Organisationen, die von der Architektur betroffen sind oder zur Gestaltung beitragen können. Sie sollten die Projektbeteiligten und -betroffenen kennen, sonst erleben Sie später im Entwicklungsprozess Überraschungen. EInfache Tabelle mit Rollennamen, Personennamen, deren Kenntnisse, die für die Architektur relevant sind, deren Verfügbarkeit, etc. siehe z.B. VOLERE-Stakeholdertabelle.




## Randbedingungen

(engl.: Architecture Constraints) Nach den Architekturtreiber im Kapitel 1 sollten Sie hier alle Fesseln festhalten, die Software-Architekten in ihren Freiheiten bezüglich des Entwurfs oder des Entwicklungsprozesses einschränken.

Architekten sollten klar wissen, wo Ihre Freiheitsgrade bezüglich Entwurfsentscheidungen liegen und wo sie Randbedingungen beachten müssen. Randbedingungen können vielleicht noch verhandelt werden, zunächst sind sie aber da.

Nutzen Sie informelle Listen, gegliedert nach den Unterpunkten dieses Kapitels.
Im Idealfall sind Randbedingungen durch die Anforderungen vorgegeben, spätestens die Architekten müssen sich dieser Randbedingungen bewusst sein. 


### Technische Randbedingungen
(engl.: Technical Constraints) Tragen Sie hier alle technischen Randbedingungen ein. Zu dieser Kategorie gehören Hard- und Software-Infrastruktur, eingesetzte Technologien (Betriebssysteme, Middleware, Datenbanken, Programmiersprachen, ...).

Beispiele:

- Hardware-Infrastruktur: Prozessoren, Speicher, Netzwerke, Firewalls und andere relevante Elemente der Hardware- Infrastruktur
- Software-Infrastruktur: Betriebssysteme, Datenbanksysteme, Middleware, Kommunikationssysteme, Transaktionsmonitor, Webserver, Verzeichnisdienste
- Systembetrieb: Batch- oder Onlinebetrieb des Systems oder notwendiger externer Systeme?
- Verfügbarkeit der Laufzeitumgebung:	Rechenzentrum mit 7x24h Betriebszeit? Gibt es Wartungs- oder Backupzeiten mit eingeschränkter Verfügbarkeit des Systems oder wichtiger Systemteile?
- Grafische Oberfläche: Existieren Vorgaben hinsichtlich grafischer Oberfläche (Style Guide)?
- Bibliotheken, Frameworks und Komponenten: Sollen bestimmte „Software-Fertigteile“ eingesetzt werden?
- Programmiersprachen: Objektorientierte, strukturierte, deklarative oder Regelsprachen, kompilierte oder interpretierte Sprachen?
- Referenzarchitekturen: Gibt es in der Organisation vergleichbare oder übertragbare Referenzprojekte?
- Analyse- und Entwurfsmethoden: Objektorientierte oder strukturierte Methoden?
- Datenstrukturen: Vorgaben für bestimmte Datenstrukturen, Schnittstellen zu bestehenden Datenbanken oder Dateien
- Programmierschnittstellen: Schnittstellen zu bestehenden Programmen
- Programmiervorgaben: Programmierkonventionen, fester Programmaufbau
- Technische Kommunikation: Synchron oder asynchron, Protokolle
- Betriebssystem und Middleware: Vorgegebene Betriebssysteme oder Middleware


### Organisatorische Randbedingungen
(engl.: Organizational Constraints) Tragen Sie hier alle organisatorischen, strukturellen und ressourcenbezogenen Randbedingungen ein. Zu dieser Kategorie gehören auch Standards, die Sie einhalten müssen, sowie juristische und gesetzliche Randbedingungen.

Mögliche Kategorien:

- Organisation und Struktur
- Ressourcen (Budget, Zeit, Personal)
- Organisatorische Standards
- Juristische und gesetzliche Faktoren

Beispiele für Organisation und Struktur

- Organisationsstruktur beim Auftraggeber: Droht Änderung von Verantwortlichkeiten? Änderung von Ansprechpartnern?
- Organisationsstruktur des Projektteams: mit/ohne Unterauftragnehmer, Entscheidungsbefugnis der Projektleiterin
- Entscheidungsträger: Erfahrung mit ähnlichen Projekten, Risiko-/Innovationsfreude
- Bestehende Partnerschaften oder Kooperationen:	Hat die Organisation bestehende Kooperationen mit bestimmten Softwareherstellern? Solche Partnerschaften geben oftmals Produktentscheidungen (unabhängig von Systemanforderungen) vor.
- Eigenentwicklung oder externe Vergabe: Selbst entwickeln oder an externe Dienstleister vergeben?
- Entwicklung als Produkt oder zur eigenen Nutzung? Dies bedingt andere Prozesse bei Anforderungsanalyse und Entscheidungen. Im Fall der Produktentwicklung: Neues Produkt für neuen Markt? Verbessertes Produkt für bestehenden Markt? Vermarktung eines bestehenden (eigenen) Systems? Entwicklung ausschließlich zur eigenen Nutzung?

Beispiele für Ressourcen (Budget, Zeit, Personal)

- Festpreisprojekt oder Abrechnung nach Zeit und Aufwand?
- Zeitplan: Wie flexibel ist der Zeitplan? Gibt es einen festen Endtermin? Welche Stakeholder bestimmen den Endtermin?
- Zeitplan und Funktionsumfang: Was ist höher priorisiert, der Termin oder der Funktionsumfang?
- Release-Plan: Zu welchen Zeitpunkten soll welcher Funktionsumfang in Releases/Versionen zur Verfügung stehen?
- Projektbudget: Fest oder variabel? In welcher Höhe verfügbar?
- Budget für technische Ressourcen: Kauf oder Miete von Entwicklungswerkzeugen (Hardware und Software)?
- Team: Anzahl der Mitarbeiter und deren Qualifikation, kontinuierliche Verfügbarkeit.

Beispiele für organisatorische Standards

- Vorgehensmodell: Vorgaben bezüglich Vorgehensmodell? Hierzu gehören auch interne Standards zu Modellierung, Dokumentation und Implementierung.
- Qualitätsstandards: Fällt die Organisation oder das System in den Geltungsbereich von Qualitätsnormen (wie ISO-9000)?
- Entwicklungswerkzeuge: Vorgaben bezüglich der Entwicklungswerkzeuge (etwa: CASE-Tool, Datenbank, Integrierte - Entwicklungsumgebung, Kommunikationssoftware, Middleware, Transaktionsmonitor).
- Konfigurations- und Versionsverwaltung: Vorgaben bezüglich Prozessen und Werkzeugen
- Testwerkzeuge und -prozesse: Vorgaben bezüglich Prozessen und Werkzeugen
- Abnahme- und Freigabeprozesse (für Datenmodellierung und Datenbankdesign, Benutzeroberflächen, Geschäftsprozesse/Workflows, Nutzung externer Systeme, etwa: schreibender Zugriff bei externen Datenbanken)
- Service Level Agreements: Gibt es Vorgaben oder Standards hinsichtlich Verfügbarkeiten oder einzuhaltender Service-Levels?

Beispiele für juristische Faktoren

- Haftungsfragen (Hat die Nutzung oder der Betrieb des Systems mögliche rechtliche Konsequenzen? Kann das System Auswirkung auf Menschenleben oder Gesundheit besitzen? Kann das System Auswirkungen auf Funktionsfähigkeit externer Systeme oder Unternehmen besitzen?)
- Datenschutz: Speichert oder bearbeitet das System „schutzwürdige“ Daten?
- Nachweispflichten: Bestehen für bestimmte Systemaspekte juristische Nachweispflichten? Hinsichtlich der SOX-Diskussion der letzten Jahre gewinnt dieser Punkt stetig an Bedeutung!
- Internationale Rechtsfragen: Wird das System international eingesetzt? Gelten in anderen Ländern eventuell andere juristische Rahmenbedingungen für den Einsatz (Beispiel: Nutzung von Verschlüsselungsverfahren)? 


### Konventionen
Fassen Sie unter dieser Überschrift alle Konventionen zusammen, die für die Entwicklung der Software-Architektur relevant sind.
Entweder die Konventionen als Kapitel hier direkt einhängen oder aber auf entsprechende Dokumente verweisen.

- Programmierrichtlinien
- Dokumentationsrichtlinien
- Richtlinien für Versions- und Konfigurationsmanagement
- Namenskonventionen



## Kontextabgrenzung
(engl.: Scope of Product*)
Die Kontextabgrenzung grenzt das System oder das Produkt, für das Sie die Architektur entwickeln, von allen Nachbarsystemen ab. Sie legt damit die wesentlichen externen Schnittstellen fest.

Stellen Sie sicher, dass die Schnittstellen mit allen relevanten Aspekten (was wird übertragen, in welchem Format wird übertragen, welches Medium wird verwendet, ...) spezifiziert wird, auch wenn einige populäre Diagramme (wie z.B. das UML Use-Case Diagramm) nur ausgewählte Aspekte der Schnittstelle darstellen.

Die Festlegung der Schnittstellen zu Nachbarsystemen gehört zu den kritischsten Aspekten eines Projektes. Stellen Sie rechtzeitig sicher, dass Sie diese komplett verstanden haben.

Die folgenden Unterkapitel zeigen die logische und physische Einbettung Ihres Systems in seine Umgebung.


### Fachlicher Kontext
Hier werden alle Nachbarsysteme des betrachteten Systems festgelegt und alle fachlich-logischen Daten, die mit diesen ausgetauscht werden. Zusätzlich evtl. Datenformate und Protokolle der Kommunikation mit Nachbarsystemen und der Umwelt (falls diese nicht erst bei den spezifischen Bausteinen präzisiert wird.

Dieses Kapitel soll klar und unmissverständlich aufzeigen, welche (logischen) Informationen mit Nachbarsystemen (in welcher Form) ausgetauscht werden.

Wir sind an vielen Stellen im Dokument zu Pragmatismus bereit: hier jedoch bestehen wir auf der vollständigen Auflistung aller (a-l-l-e-r) Nachbarsysteme. Zu viele Projekte sind daran gescheitert, dass sie ihre Nachbarn nicht kannten :-(

Als Notation können Sie das gute, alte Kontextdiagramm aus der Strukturierten Analyse verwenden. Bei Nutzung von UML simulieren Sie dieses durch ein Klassendiagramm, ein Use Case Diagramme erweitert um die Ein-/Ausgaben oder ein Kommunikationsdiagramm - kurz durch irgendein Diagramm, das das System als Black Box darstellen und die Schnittstellen zu den Nachbarsystemen (mehr oder weniger ausführlich) beschreibt. Auch Tabellen aller Nachbarsysteme mit Erwähnung der jeweiligen Ein-/Ausgaben erfüllen den Zweck.


### Verteilungskontext
Hier legen Sie die physischen Kanäle zwischen Ihrem System und allen Nachbarsystemen fest, über die die logischen Ein-/Ausgaben von und zu Nachbarsystemen kommuniziert werden.
 
Das Kapitel soll aufzeigen, über welche Medien Informationen mit Nachbarsystemen bzw. der Umwelt ausgetauscht werden.
 
Als Form bietet sich z.B. ein UML Deploymentdiagramm mit den Kanälen zu Nachbarsystemen an. Sie ergänzen es um eine Mappingtabelle der logischen Ein-/Ausgaben aus Kapitel 3.1 auf die hier spezifizierten Kanäle.



## Lösungsstrategie
(engl.: Solution Strategy)
Kurzer Überblick über Ihre grundlegenden Entscheidungen und Lösungsansätze, die jeder, der mit der Architektur zu tun hat, verstanden haben sollte.

**Motivation**

Dieses Kapitel motiviert übergreifend die zentralen Gestaltungskriterien für Ihre Architektur. Beschränken Sie sich hier auf das Wesentliche. Detailentscheidungen können immer noch bei den einzelnen Bausteinen oder im Kapitel 10 festgehalten werden. Das Kapitel soll Ihren Lesern die gewählte Strategie verdeutlichen.

**Form**

Fassen Sie (kurz!) die Beweggründe für zentrale Entwurfsentscheidungen zusammen. Motivieren Sie ausgehend von Aufgabenstellung, Qualitätszielen und Randbedingungen, was Sie entschieden haben und warum Sie so entschieden haben. Verweisen Sie – wo nötig - auf weitere Erklärungen, Konzepte, Strukturen oder Entscheidungen in Folgekapiteln.