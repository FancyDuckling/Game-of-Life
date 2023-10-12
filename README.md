# Game-of-Life
 inlämning

Jag började med att göra en grid och med modulus placera ut "celler" (en sprite square) som då fungerade som "tiles" i ett schackbräde för att få en visuell uppfattning om hur det skulle se ut, varannan cell/tile fick en svart färg och de andra lila (som nu är blå), satte sedan random range och en spawn procentage. Färgen bestäms i Inspektorn. 

Jag tyckte även det var lättare att jobba med en bestämd width och height så de värderna bestämde jag i början så de skulle passa 1920x1080. För att göra det ännu tydligare la jag till att man i herarkin kunde se vilka x och y kordinater som varje cell/tile hade. För att kunna kolla om cellen var levande och skulle leva vidare i nästa generation gjorde jag en public bool för de båda.

Hade lite problem när jag skulle fixa nästa generation, hade först 2 arrays som ställde till det och det blev för många som levde, visade sig att allt löste sig med en array grid och lite omstrukturering av koden. 

