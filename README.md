# Data Processing
Deze git bevat code die ik geschreven heb voor het vak Data Processing in periode 3 van jaar 2.

Het doel was een REST API te ontwikkelen die gebruik maakt van XML en JSON.

Deze API moet dan geconsumeerd worden in een client applicatie die kan schakelen tussen de 2 dataformats.

## Projecten
### DataProcessingClient
Dit project is de client applicatie gemaakt in C# die de REST API consumeerd. 
Voor het uitvoeren van webrequests heb ik de RESTSharp plugin gebruikt

### DataProcessingDataImporter
Dit project kan de data van de gekozen datasets importeren in de lokale database. (Dit programma is alleen nodig bij het
bij het installeren van de API)

### DataProcessingWebAPI
Dit project bevat de source code van de REST API, 
in de huidige configuratie werkt deze via IISExpress maar hij kan geconfigureerd worden om in IIS zelf te werken.
Hiervoor moet dan wel ASP 4.8 en ASP.NET 4.8 voor worden ingeschakeld
